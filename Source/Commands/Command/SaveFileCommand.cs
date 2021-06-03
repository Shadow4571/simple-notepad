using Notepad.Source.Files;
using Notepad.Source.Main;
using System.IO;
using System.Windows.Forms;

namespace Notepad.Source.Commands.Command {
    class SaveFileCommand : ICommand {
        NotepadForm _form;

        public SaveFileCommand(NotepadForm form) {
            _form = form;
        }

        public void Execute() {
            FileManager.Current.SetData(_form.GetTextData());

            try {
                FileManager.Current.Save();
            } catch {
                SaveFileDialog newFileSelector = new SaveFileDialog();
                newFileSelector.Title = "Сохранить документ...";
                newFileSelector.Filter = "Файлы txt|*.txt|Все файлы|*.*";

                if(newFileSelector.ShowDialog() != DialogResult.OK) {
                    return;
                }

                File.Create(newFileSelector.FileName).Close();
                FileManager.Current.SetPathWithFile(newFileSelector.FileName);

                try {
                    FileManager.Current.Save();
                } catch { }
            }
        }
    }
}
