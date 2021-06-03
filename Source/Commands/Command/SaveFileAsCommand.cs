using Notepad.Source.Files;
using Notepad.Source.Main;

namespace Notepad.Source.Commands.Command {
    class SaveFileAsCommand : ICommand {
        private NotepadForm _form;
        private ICommand _simpleSave;

        public SaveFileAsCommand(NotepadForm form, ICommand simpleSave) {
            _form = form;
            _simpleSave = simpleSave;
        }

        public void Execute() {
            FileManager.Current.ResetPathAndFile();
            _simpleSave.Execute();
        }
    }
}
