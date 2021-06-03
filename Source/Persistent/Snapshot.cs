using System;

namespace Notepad.Source.Persistent {
    class Snapshot {
        public string[] Text { get; private set; }

        public Snapshot(string[] text) {
            Text = new string[text.Length];
            Array.Copy(text, Text, text.Length);
        }
    }
}
