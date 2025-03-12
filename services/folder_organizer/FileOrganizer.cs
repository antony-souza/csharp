using System;
using System.IO;
using app.interfaces.FileOrganizer;

namespace app.services.FolderOrganizer;

class FileOrganizer : IFileOrganizer
{
    private readonly string _filePath;

    public FileOrganizer(string filePath)
    {
        // Verifica se _filePath existe dentro das pastas da "Home"
        _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), filePath);
    }

    public void OrganizeFiles()
    {
        if (!Directory.Exists(_filePath))
        {
            Console.WriteLine();
            Console.WriteLine($"Falha: {_filePath} não existe!");
            Console.WriteLine();
            return;
        }

        string[] files = Directory.GetFiles(_filePath);

        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).TrimStart('.').ToLower();
            
            if (string.IsNullOrEmpty(extension))
            {
                string filesNotExtension = Path.Combine(_filePath, "OUTROS");
                if (!Directory.Exists(filesNotExtension))
                {
                    Directory.CreateDirectory(filesNotExtension);
                }

                string newOthersPath = Path.Combine(filesNotExtension, Path.GetFileName(file));
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
            
            string extensionFolder = Path.Combine(_filePath, extension.ToUpper());
            if (!Directory.Exists(extensionFolder))
            {
                Directory.CreateDirectory(extensionFolder);
            }

            string moveFileName = Path.Combine(extensionFolder, Path.GetFileName(file));

            try
            {
                File.Move(file, moveFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao mover o arquivo {file}: {ex.Message}");
            }
        }
        Console.WriteLine("Arquivos organizados com sucesso! :)");
    }
}
