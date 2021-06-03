using Notepad.Source.Commands;
using Notepad.Source.Commands.Command;
using Notepad.Source.Main;
using System.Windows.Forms;

namespace Notepad.Source.Hotkey {
    static class HotkeyManager {
        private static ICommand _undoCommand;
        private static ICommand _saveFileCommand;

        public static void Initialize(NotepadForm form) {
            _undoCommand = new UndoCommand(form);
            _saveFileCommand = new SaveFileCommand(form);
        }

        public static void ProcessKey(KeyPressEventArgs e) {
            switch(e.KeyChar) {
                case '\u0013':
                _saveFileCommand.Execute();
                break;

                case '\u001a':
                _undoCommand.Execute();
                break;
            }
        }
    }
}
