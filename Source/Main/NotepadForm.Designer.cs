using Notepad.Source.Files;
using Notepad.Source.Hotkey;
using System.Drawing;
using System.Windows.Forms;

namespace Notepad.Source.Main {
    partial class NotepadForm {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            FileManager.Current.SetData(this.mainTextBox.Lines);

            if (FileManager.Current.IsBufferNotEmpty()) {
                _saveFileCommand.Execute();
            }

            FileManager.Current.Dispose();

            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotepadForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainTextBox = new System.Windows.Forms.RichTextBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.menuPanelsStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlayChoisePanel = new System.Windows.Forms.Panel();
            this.overlaySelectPanel = new System.Windows.Forms.Panel();
            this.choiseNoButton = new System.Windows.Forms.Button();
            this.choiseYesButton = new System.Windows.Forms.Button();
            this.saveCurrentLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.menuPanelsStrip.SuspendLayout();
            this.overlayChoisePanel.SuspendLayout();
            this.overlaySelectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(936, 27);
            this.mainPanel.TabIndex = 0;
            // 
            // mainTextBox
            // 
            this.mainTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.mainTextBox.Location = new System.Drawing.Point(0, 40);
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.Size = new System.Drawing.Size(928, 576);
            this.mainTextBox.TabIndex = 1;
            this.mainTextBox.Text = "";
            this.mainTextBox.TextChanged += new System.EventHandler(this.mainTextBox_TextChanged);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.topPanel.Controls.Add(this.menuPanelsStrip);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(928, 32);
            this.topPanel.TabIndex = 2;
            // 
            // menuPanelsStrip
            // 
            this.menuPanelsStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuPanelsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.editToolStripMenuItem});
            this.menuPanelsStrip.Location = new System.Drawing.Point(0, 0);
            this.menuPanelsStrip.Name = "menuPanelsStrip";
            this.menuPanelsStrip.Size = new System.Drawing.Size(928, 31);
            this.menuPanelsStrip.TabIndex = 0;
            this.menuPanelsStrip.Text = "Menu";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.saveFileAsToolStripMenuItem,
            this.printToolStripMenuItem});
            this.fileMenuItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.fileMenuItem.Size = new System.Drawing.Size(56, 27);
            this.fileMenuItem.Text = "File";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.newFileToolStripMenuItem.Text = "New file";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.openFileToolStripMenuItem.Text = "Open file";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.saveFileToolStripMenuItem.Text = "Save file";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // saveFileAsToolStripMenuItem
            // 
            this.saveFileAsToolStripMenuItem.Name = "saveFileAsToolStripMenuItem";
            this.saveFileAsToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.saveFileAsToolStripMenuItem.Text = "Save file as...";
            this.saveFileAsToolStripMenuItem.Click += new System.EventHandler(this.saveFileAsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 27);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // overlayChoisePanel
            // 
            this.overlayChoisePanel.AutoSize = true;
            this.overlayChoisePanel.BackColor = System.Drawing.Color.FromArgb(100, 20, 20, 20);
            this.overlayChoisePanel.Controls.Add(this.overlaySelectPanel);
            this.overlayChoisePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayChoisePanel.Enabled = false;
            this.overlayChoisePanel.Location = new System.Drawing.Point(0, 0);
            this.overlayChoisePanel.Margin = new System.Windows.Forms.Padding(100);
            this.overlayChoisePanel.Name = "overlayChoisePanel";
            this.overlayChoisePanel.Padding = new System.Windows.Forms.Padding(50);
            this.overlayChoisePanel.Size = new System.Drawing.Size(928, 616);
            this.overlayChoisePanel.TabIndex = 3;
            this.overlayChoisePanel.Visible = false;
            // 
            // overlaySelectPanel
            // 
            this.overlaySelectPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.overlaySelectPanel.Controls.Add(this.choiseNoButton);
            this.overlaySelectPanel.Controls.Add(this.choiseYesButton);
            this.overlaySelectPanel.Controls.Add(this.saveCurrentLabel);
            this.overlaySelectPanel.Location = new System.Drawing.Point(0, 200);
            this.overlaySelectPanel.Name = "overlaySelectPanel";
            this.overlaySelectPanel.Size = new System.Drawing.Size(928, 224);
            this.overlaySelectPanel.TabIndex = 0;
            // 
            // choiseNoButton
            // 
            this.choiseNoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.choiseNoButton.FlatAppearance.BorderSize = 0;
            this.choiseNoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choiseNoButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choiseNoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.choiseNoButton.Location = new System.Drawing.Point(552, 112);
            this.choiseNoButton.Name = "choiseNoButton";
            this.choiseNoButton.Size = new System.Drawing.Size(200, 40);
            this.choiseNoButton.TabIndex = 2;
            this.choiseNoButton.Text = "No";
            this.choiseNoButton.UseVisualStyleBackColor = false;
            this.choiseNoButton.Click += new System.EventHandler(this.choiseNoButton_Click);
            // 
            // choiseYesButton
            // 
            this.choiseYesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.choiseYesButton.FlatAppearance.BorderSize = 0;
            this.choiseYesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choiseYesButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choiseYesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.choiseYesButton.Location = new System.Drawing.Point(152, 112);
            this.choiseYesButton.Name = "choiseYesButton";
            this.choiseYesButton.Size = new System.Drawing.Size(200, 39);
            this.choiseYesButton.TabIndex = 1;
            this.choiseYesButton.Text = "Yes";
            this.choiseYesButton.UseVisualStyleBackColor = false;
            this.choiseYesButton.Click += new System.EventHandler(this.choiseYesButton_Click);
            // 
            // saveCurrentLabel
            // 
            this.saveCurrentLabel.AutoSize = true;
            this.saveCurrentLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveCurrentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.saveCurrentLabel.Location = new System.Drawing.Point(360, 40);
            this.saveCurrentLabel.Name = "saveCurrentLabel";
            this.saveCurrentLabel.Size = new System.Drawing.Size(190, 29);
            this.saveCurrentLabel.TabIndex = 0;
            this.saveCurrentLabel.Text = "Save Current File?";
            // 
            // NotepadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(928, 616);
            this.Controls.Add(this.overlayChoisePanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.mainTextBox);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(241)))), ((int)(((byte)(172)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NotepadForm";
            this.Text = "Notepad";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.menuPanelsStrip.ResumeLayout(false);
            this.menuPanelsStrip.PerformLayout();
            this.overlayChoisePanel.ResumeLayout(false);
            this.overlaySelectPanel.ResumeLayout(false);
            this.overlaySelectPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.RichTextBox mainTextBox;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.MenuStrip menuPanelsStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileAsToolStripMenuItem;
        private System.Windows.Forms.Panel overlayChoisePanel;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private Panel overlaySelectPanel;
        private Label saveCurrentLabel;
        private Button choiseNoButton;
        private Button choiseYesButton;
        private ToolStripMenuItem printToolStripMenuItem;
    }
}

