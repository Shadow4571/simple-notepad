using Notepad.Source.Commands;
using Notepad.Source.Main;
using Notepad.Source.Persistent;

namespace Notepad.Source.Commands.Command {
    class UndoCommand : ICommand {
        private NotepadForm _form;

        public UndoCommand(NotepadForm form) {
            _form = form;
        }

        public void Execute() {
            try {
                Snapshot snapshot = PersistentManager.Current.GetSnapshot();
                _form.SetTextChangedEventState(false);
                _form.SetTextData(snapshot.Text);
                _form.SetTextChangedEventState(true);
            } catch {
                _form.SetTextData(new string[] { "" });
            }

            _form.SetCursorPositionToEnd();
        }
    }
}
