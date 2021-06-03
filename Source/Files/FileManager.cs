using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Notepad.Source.Files {
    class FileManager {
        private string _path;
        private string _fileName;

        private Thread _thread;
        private object _locker;
        private bool _isRunning;

        private string[] _localData;
        private StringBuilder _localBuffer;

        private bool _isSave;
        private bool _isChangeBuffer;
        private bool _isResetPath;
        public bool IsSaveCurrent { get; private set; }

        private static FileManager _instance;

        public static FileManager Current => GetInstance();

        private FileManager(string path = null, string fileName = null) {
            _path = path;
            _fileName = fileName;
            _isRunning = true;

            _locker = new object();

            _localData = new string[0];
            _localBuffer = new StringBuilder();

            _isSave = false;
            _isChangeBuffer = false;
            _isResetPath = false;
            IsSaveCurrent = false;

            _thread = new Thread(Run, 1024);
            _thread.Start();
        }

        public void ResetPath() => SetPathWithFile(null, _fileName);
        public void SetPath(string path) => SetPathWithFile(path, _fileName);

        public void ResetFileName() => SetPathWithFile(_path, null);
        public void SetFileName(string fileName) => SetPathWithFile(_path, fileName);

        public void SetPathWithFile(string path, string fileName) {
            lock (_locker) {
                _path = path;
                _fileName = fileName;
                IsSaveCurrent = false;
            }
        }

        public void SetPathWithFile(string fullPath) {
            int lastSeparator = fullPath.LastIndexOf(Path.DirectorySeparatorChar);
            string path = fullPath.Substring(0, lastSeparator);
            string fileName = fullPath.Substring(lastSeparator + 1, fullPath.Length - lastSeparator - 1);
            SetPathWithFile(path, fileName);
        }

        public void ResetPathAndFile() {
            lock(_locker) {
                _isResetPath = true;
            }
        }

        public (string, string) GetPathAndFileName() {
            return (_path, _fileName);
        }

        private void Run() {
            while (_isRunning || _isSave) {
                if(_isChangeBuffer) {
                    SetLocalBuffer();
                }

                if(_isSave) {
                    SaveFile();
                }

                if(_isResetPath) {
                    ResetAll();
                }

                Thread.Sleep(500);
            }
        }

        private void ResetAll() {
            lock (_locker) {
                _path = null;
                _fileName = null;
                _isResetPath = false;
                IsSaveCurrent = false;
            }
        }

        private void SaveFile() {
            lock (_locker) {
                if(_path == null || _fileName == null) {
                    return;
                }

                if (!Directory.Exists(_path)) {
                    Directory.CreateDirectory(_path);
                }

                string filePath = Path.Combine(_path, _fileName);
                if (!File.Exists(filePath)) {
                    File.Create(filePath);
                } else {
                    File.WriteAllBytes(filePath, new byte[0]);
                }

                File.WriteAllText(filePath, _localBuffer.ToString());
                _isSave = false;
                IsSaveCurrent = true;
            }
        }

        public void Save() {
            if (_path == null) {
                throw new FileNotFoundException("Save directory not selected");
            }

            if (_fileName == null) {
                throw new FileNotFoundException("Save file not selected");
            }

            lock(_locker) {
                _isSave = true;
            }
        }

        private void SetLocalBuffer() {
            lock(_locker) {
                _localBuffer.Clear();

                foreach(string line in _localData) {
                    if (string.IsNullOrEmpty(line)) {
                        _localBuffer.Append(Environment.NewLine);
                    } else {
                        _localBuffer.AppendLine(line);
                    }
                }

                _isChangeBuffer = false;
            }
        }

        public void SetData(string[] data) {
            lock (_locker) {
                data = data ?? new string[0];

                if (_localData.Length != 0 || data.Length != 0) {
                    _isChangeBuffer = true;
                }

                _localData = data;

                IsSaveCurrent = false;
            }
        }

        public bool IsBufferNotEmpty() {
            lock (_locker) {
                return _localBuffer.Length > 0 || _isChangeBuffer;
            }
        }

        public void Dispose() {
            _isRunning = false;
        }

        public static FileManager GetInstance() {
            _instance = _instance ?? new FileManager();
            return _instance;
        }
    }
}
