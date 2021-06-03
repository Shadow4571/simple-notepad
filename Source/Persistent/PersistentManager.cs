using System;
using System.Collections.Generic;

namespace Notepad.Source.Persistent {
    class PersistentManager {
        private static PersistentManager _instance;

        public static PersistentManager Current => GetInstance();

        private LinkedList<Snapshot> _history;
        private int _historyLength;

        private PersistentManager() {
            _history = new LinkedList<Snapshot>();
            _historyLength = 10;
        }

        public void AddSnapshot(Snapshot snapshot) {
            if(_history.Count >= _historyLength) {
                _history.RemoveFirst();
            }

            _history.AddLast(snapshot);
        }

        public Snapshot GetSnapshot() {
            if(_history.Count == 0) {
                throw new Exception("History is empty");
            }

            Snapshot snapshot = _history.Last.Value;
            _history.RemoveLast();

            return snapshot;
        }

        public static PersistentManager GetInstance() {
            _instance = _instance ?? new PersistentManager();
            return _instance;
        }
    }
}
