using System.IO;

namespace Tui.Assessment.FileReaders
{
    public partial class FileReader
    {
        public string ReadFile(string pathName)
        {
            return File.ReadAllText(path: pathName);
        }
    }
}