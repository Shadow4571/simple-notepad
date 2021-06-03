using Notepad.Source.Files;
using Notepad.Source.Main;
using System;
using System.IO;
using System.Windows.Forms;

namespace Notepad.Source.Commands.Command {
    class NewFileCommand : ICommand {
        private NotepadForm _form;

        public NewFileCommand(NotepadForm form) {
            _form = form;
        }

        public void Execute() {
            if(!FileManager.Current.IsSaveCurrent) {
                _form.ShowOverlayChoisePanel(yesChoise, noChoise);
            } else {
                newFile();
            }
        }

        private void yesChoise(object sender, EventArgs e) {
            FileManager.Current.SetData(_form.GetTextData());
            try {
                FileManager.Current.Save();
            } catch {
                SaveFileDialog newFileSelector = new SaveFileDialog();
                newFileSelector.Title = "Сохранить документ...";
                newFileSelector.Filter = "Файлы txt|*.txt|Все файлы|*.*";

                if (newFileSelector.ShowDialog() != DialogResult.OK) {
                    return;
                }

                File.Create(newFileSelector.FileName).Close();
                FileManager.Current.SetPathWithFile(newFileSelector.FileName);

                try {
                    FileManager.Current.Save();
                } catch { }
            }
            
            newFile();
        }

        private void noChoise(object sender, EventArgs e) {
            newFile();
        }

        private void newFile() {
            _form.SetTextData("");
            _form.HideOverlayChoisePanel();
            FileManager.Current.ResetPathAndFile();
        }
    }
}
