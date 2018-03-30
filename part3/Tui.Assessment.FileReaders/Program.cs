using System;

namespace Tui.Assessment.FileReaders
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic str = new FileReader().ReadFile("Tui.Assessment.FileReaders.csproj");
            Console.WriteLine(str);
        }
    }
}
