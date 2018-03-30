using System.IO;

namespace Tui.Assessment.FileReaders
{
    public partial class FileReader
    {
        public string ReadRoleBasedSecuredFile(string path, IRoleHandler handler)
        {
            if (handler.IsAuthorized())
                 return File.ReadAllText(path);
            return null;
        }
    }
    public interface IRoleHandler
    {
        bool IsAuthorized();
    }
}