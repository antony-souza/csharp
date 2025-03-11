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
            Console.WriteLine($"{_filePath} não existe!");
            return;
        }

        string[] files = Directory.GetFiles(_filePath);

        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).TrimStart('.').ToLower();
            
            if (string.IsNullOrEmpty(extension))
            {
                string othersFolder = Path.Combine(_filePath, "OUTROS");
                if (!Directory.Exists(othersFolder))
                {
                    Directory.CreateDirectory(othersFolder);
                }
                
                string newOthersPath = Path.Combine(othersFolder, Path.GetFileName(file));
                try
                {
                    File.Move(file, newOthersPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao mover o arquivo {file}: {ex.Message}");
                }

                continue;
            }
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