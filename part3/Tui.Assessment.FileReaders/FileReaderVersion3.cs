using System.IO;

namespace Tui.Assessment.FileReaders
{
    public partial class FileReader
    {
        // Added possibility to decode file via a custom file decoder, written by the library user.
        public string ReadEncodedFile(string pathName, IFileDecoder fileDecoder)
        {
            return fileDecoder.Decode(File.ReadAllText(path: pathName));
        }
    }

    public interface IFileDecoder
    {
        string Decode(string text);
    }
}