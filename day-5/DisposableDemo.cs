using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollectionDemo
{
    public class FileManager : IDisposable
    {
        private FileStream? _fileStream;
        private bool _disposed = false;
        public void OpenFile(string path)
        {
            _fileStream = new FileStream(path, FileMode.Open);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                // Dispose managed resources
                _fileStream?.Dispose();
            }
            // Dispose unmanaged resources here if any
            _disposed = true;
        }
        ~FileManager()
        {
            Dispose(false);
        }
    }
}