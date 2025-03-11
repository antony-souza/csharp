using System;
using System.IO;
using app.interfaces.FileOrganizer;

namespace app.services.FolderOrganizer;

class FileOrganizer : IFileOrganizer
{
    private readonly string _filePath;

    public FileOrganizer(string filePath)
    {
        //Verifica se _filePath existe dentro das pastas da "Home"
        _filePath = Path.Combine(Environment.GetFolderPath((Environment.SpecialFolder.UserProfile)), filePath);
    }

    public void OrganizeFiles()
    {
        if (!Directory.Exists(_filePath))
        {
            Console.WriteLine($"{_filePath} does not exist");
            return;
        }

        string[] files = Directory.GetFiles(_filePath);

        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).TrimStart('.').ToLower();

            //Ignora arquivos sem extensão, que não tenham nada após '.'
            if (string.IsNullOrEmpty(extension)) continue;

            string fileName = Path.Combine(_filePath, extension.ToUpper());

            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }

            string moveFileName = Path.Combine(_filePath, fileName);

            try
            {
                if (Directory.Exists(moveFileName))
                {
                    File.Move(file, moveFileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}