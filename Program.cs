using System;
using System.IO;
using app.services.FolderOrganizer;

namespace app;

class Menu
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== Menu ===");
        Console.WriteLine("1. Organizar arquivos em uma pasta específica");
        Console.WriteLine("2. Sair");
        Console.WriteLine();
        Console.ResetColor();
        Console.Write("Escolha uma opção: ");
    }
    public void MenuOptions()
    {
        while (true)
        {
            ShowMenu();
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write(
                        "Digite o nome da pasta dentro de sua pasta de usuário (ex: Downloads, Documentos, Imagens): ");
                    string filePath = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(filePath))
                    {
                        Console.WriteLine("Nome da pasta inválido. Tente novamente.");
                        continue;
                    }

                    FileOrganizer organizer = new FileOrganizer(filePath);
                    organizer.OrganizeFiles();
                    Console.WriteLine("Ornanização concluida!");
                    break;
                case "2":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.MenuOptions();
    }
}