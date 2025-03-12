using System;
using System.IO;
using app.services.FolderOrganizer;
using app.services.tasklist;

namespace app;

class Menu
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== Menu ===");
        Console.WriteLine("1. Organizar arquivos em uma pasta específica");
        Console.WriteLine("2. Lista de Tarefas");
        Console.WriteLine("3. Sair");
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
                    string folderName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(folderName))
                    {
                        Console.WriteLine("Nome da pasta inválido. Tente novamente.");
                        continue;
                    }

                    FileOrganizer organizer = new FileOrganizer(folderName);
                    organizer.OrganizeFiles();
                    break;
                case "2":
                    TaskList taskList = new TaskList();
                    taskList.LoadTasks();
                    break;
                case "3":
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