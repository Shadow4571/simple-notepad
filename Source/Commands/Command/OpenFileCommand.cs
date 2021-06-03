using Notepad.Source.Files;
using Notepad.Source.Main;
using System;
using System.IO;
using System.Windows.Forms;

namespace Notepad.Source.Commands.Command {
    class OpenFileCommand : ICommand {
        private NotepadForm _form;

        public OpenFileCommand(NotepadForm form) {
            _form = form;
        }

        public void Execute() {
            if(!FileManager.Current.IsSaveCurrent) {
                _form.ShowOverlayChoisePanel(yesCallback, noCallback);
            } else {
                OpenFile();
            }
        }

        private void yesCallback(object sender, EventArgs e) {
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

            _form.HideOverlayChoisePanel();
            OpenFile();
        }

        private void noCallback(object sender, EventArgs e) {
            _form.HideOverlayChoisePanel();
            OpenFile();
        }

        private void OpenFile() {
            OpenFileDialog openFileSelector = new OpenFileDialog();
            openFileSelector.Title = "Открыть документ...";
            openFileSelector.Filter = "Файлы txt|*.txt|Все файлы|*.*";

            if(openFileSelector.ShowDialog() != DialogResult.OK) {
                return;
            }

            string fullPath = openFileSelector.FileName;
            string fileName = openFileSelector.SafeFileName;
            string path = fullPath.Replace(fileName, "");

            FileManager.Current.SetPathWithFile(path, fileName);
            try {
                _form.SetTextData(File.ReadAllText(fullPath));
            } catch {
                _form.SetTextData("");
            }
        }
    }
}
