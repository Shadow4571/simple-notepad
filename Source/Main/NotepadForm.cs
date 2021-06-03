using notepad.Source.Commands.Command;
using Notepad.Source.Commands;
using Notepad.Source.Commands.Command;
using Notepad.Source.Hotkey;
using Notepad.Source.Persistent;
using Notepad.Source.Renderers;
using System;
using System.Windows.Forms;

namespace Notepad.Source.Main {
    public partial class NotepadForm : Form {
        private ICommand _newFileCommand;
        private ICommand _openFileCommand;
        private ICommand _saveFileCommand;
        private ICommand _saveFileAsCommand;
        private ICommand _undoCommand;
        private ICommand _printCommand;

        public delegate void OverlayCallback(object sender, EventArgs e);

        private OverlayCallback _yesCallback;
        private OverlayCallback _noCallback;

        private (int, int) _defaultSize;
        private (int, int) _yesButtonDefaultLocation;
        private (int, int) _noButtonDefaultLocation;
        private (int, int) _saveLabelDefaultLocation;

        public NotepadForm() {
            _defaultSize = (944, 655);
            
            InitializeComponent();

            _saveLabelDefaultLocation = (_defaultSize.Item1 / 2 - this.saveCurrentLabel.Size.Width / 2, 40);
            _yesButtonDefaultLocation = (_defaultSize.Item1 / 2 - this.choiseYesButton.Size.Width - 32, 112);
            _noButtonDefaultLocation = (_defaultSize.Item1 / 2 + 32, 112);

            this.saveCurrentLabel.Location = new System.Drawing.Point(_saveLabelDefaultLocation.Item1, _saveLabelDefaultLocation.Item2);
            this.choiseYesButton.Location = new System.Drawing.Point(_yesButtonDefaultLocation.Item1, _yesButtonDefaultLocation.Item2);
            this.choiseNoButton.Location = new System.Drawing.Point(_noButtonDefaultLocation.Item1, _noButtonDefaultLocation.Item2);

            this.SizeChanged += WindowSizeChanged;
            this.choiseYesButton.FlatAppearance.BorderSize = 0;
            this.choiseNoButton.FlatAppearance.BorderSize = 0;

            this.menuPanelsStrip.Renderer = new MenuButtonRenderer();
            this.fileMenuItem.MouseEnter += ButtonMouseEnter;
            this.fileMenuItem.MouseLeave += ButtonMouseLeave;
            this.editToolStripMenuItem.MouseEnter += ButtonMouseEnter;
            this.editToolStripMenuItem.MouseLeave += ButtonMouseLeave;

            this.mainTextBox.KeyPress += ProcessPressedKeys;

            _newFileCommand = new NewFileCommand(this);
            _openFileCommand = new OpenFileCommand(this);
            _saveFileCommand = new SaveFileCommand(this);
            _saveFileAsCommand = new SaveFileAsCommand(this, _saveFileCommand);
            _undoCommand = new UndoCommand(this);
            _printCommand = new PrintDocumentCommand(this);

            HotkeyManager.Initialize(this);
        }

        public string[] GetTextData() {
            return this.mainTextBox.Lines;
        }

        public string GetText() {
            return this.mainTextBox.Text;
        }

        public void SetTextData(string[] text) {
            this.mainTextBox.Lines = text;
        }

        public void SetTextData(string text) {
            this.mainTextBox.Text = text;
        }

        public void SetTextChangedEventState(bool state) {
            if (state) {
                this.mainTextBox.TextChanged += mainTextBox_TextChanged;
            } else {
                this.mainTextBox.TextChanged -= mainTextBox_TextChanged;
            }
        }

        public void SetCursorPositionToEnd() {
            this.mainTextBox.SelectionStart = this.mainTextBox.Text.Length;
        }

        public void ShowOverlayChoisePanel(OverlayCallback yesCallback, OverlayCallback noCallback) {
            this.overlayChoisePanel.Enabled = true;
            this.overlayChoisePanel.Visible = true;
            _yesCallback = yesCallback;
            _noCallback = noCallback;
        }

        public void HideOverlayChoisePanel() {
            this.overlayChoisePanel.Enabled = false;
            this.overlayChoisePanel.Visible = false;
            _yesCallback = null;
            _noCallback = null;
        }
        private void ProcessPressedKeys(object sender, KeyPressEventArgs e) {
            if (ModifierKeys.HasFlag(Keys.Control)) {
                HotkeyManager.ProcessKey(e);
            }
        }

        private void WindowSizeChanged(object sender, System.EventArgs e) {
            NotepadForm fromSender = (NotepadForm)sender;

            System.Drawing.Size menuPanelSize = new System.Drawing.Size(fromSender.ClientSize.Width, this.topPanel.Size.Height);
            System.Drawing.Size mainTextBoxlSize = new System.Drawing.Size(fromSender.ClientSize.Width, fromSender.ClientSize.Height - this.menuPanelsStrip.Size.Height);
            System.Drawing.Size overlaySelectSize = new System.Drawing.Size(fromSender.ClientSize.Width, this.overlaySelectPanel.Size.Height);

            System.Drawing.Point saveLabesLocation = new System.Drawing.Point(fromSender.ClientSize.Width / 2  - this.saveCurrentLabel.Size.Width / 2, _saveLabelDefaultLocation.Item2);
            System.Drawing.Point yesButtonLocation = new System.Drawing.Point(fromSender.ClientSize.Width / 2 - this.choiseYesButton.Size.Width - 32, _yesButtonDefaultLocation.Item2);
            System.Drawing.Point noButtonLocation = new System.Drawing.Point(fromSender.ClientSize.Width / 2 + 32, _noButtonDefaultLocation.Item2);

            this.mainTextBox.Size = mainTextBoxlSize;
            this.topPanel.Size = menuPanelSize;
            this.overlayChoisePanel.Size = fromSender.ClientSize;
            this.overlaySelectPanel.Size = overlaySelectSize;
            this.choiseYesButton.Location = yesButtonLocation;
            this.choiseNoButton.Location = noButtonLocation;
            this.saveCurrentLabel.Location = saveLabesLocation;
        }

        private void ButtonMouseEnter(object sender, System.EventArgs e) {
            System.Windows.Forms.ToolStripMenuItem fromSender = (System.Windows.Forms.ToolStripMenuItem)sender;

            fromSender.ForeColor = System.Drawing.Color.FromArgb(255, 200, 200, 200);
        }

        private void ButtonMouseLeave(object sender, System.EventArgs e) {
            System.Windows.Forms.ToolStripMenuItem fromSender = (System.Windows.Forms.ToolStripMenuItem)sender;

            fromSender.ForeColor = System.Drawing.Color.FromArgb(255, 235, 235, 235);
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e) {
            _newFileCommand.Execute();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e) {
            _openFileCommand.Execute();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e) {
            _saveFileCommand.Execute();
        }

        private void saveFileAsToolStripMenuItem_Click(object sender, EventArgs e) {
            _saveFileAsCommand.Execute();
        }

        private void mainTextBox_TextChanged(object sender, EventArgs e) {
            RichTextBox fromSender = (RichTextBox)sender;
            string text = fromSender.Text;

            if(!string.IsNullOrEmpty(text) && (text[text.Length - 1] == ' ' || text[text.Length - 1] == '\n')) {
                PersistentManager.Current.AddSnapshot(new Snapshot(fromSender.Lines));
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) {
            _undoCommand.Execute();
        }

        private void choiseYesButton_Click(object sender, EventArgs e) {
            _yesCallback?.Invoke(sender, e);
        }

        private void choiseNoButton_Click(object sender, EventArgs e) {
            _noCallback?.Invoke(sender, e);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) {
            _printCommand.Execute();
        }
    }
}
