using System;
using app.services.FolderOrganizer;
using app.services.tasklist;

namespace app.utils;

public class MenuOptionsMain
{
    private void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Bem-Vindo ao DuckUtils ===");
        Console.WriteLine();
        Console.WriteLine("=== Menu Principal ===");
        Console.WriteLine();
        Console.WriteLine("1 - Gerenciar Organizador de Arquivos");
        Console.WriteLine("2 - Gerenciar Lista de Tarefas");
        Console.WriteLine("3 - Sair");
        Console.WriteLine();
        Console.Write("Escolha uma opção: ");
    }

    public void MenuOptions()
    {
        bool enabledMenu = true;

        while (enabledMenu)
        {
            ShowMenu();
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    HandleOrganizeFilesOption();
                    break;

                case "2":
                    HandleTaskListOption();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Obrigado por usar o DuckUtils! Até logo! 👋");
                    enabledMenu = false;
                    break;

                default:
                    Console.WriteLine("⚠️ Opção inválida, por favor escolha uma opção entre 1 e 3.");
                    break;
            }
        }
    }

    private void HandleOrganizeFilesOption()
    {
        Console.Clear();
        Console.Write(
            "Digite o nome da pasta onde deseja organizar os arquivos (ex: Downloads, Documentos, Pictures): ");
        
        string folderName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(folderName))
        {
            Console.WriteLine("⚠️ Nome de pasta inválido. Tente novamente e forneça um nome válido.");
            return;
        }

        FileOrganizer organizer = new FileOrganizer(folderName);
        organizer.OrganizeFiles();
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    private void HandleTaskListOption()
    {
        Console.Clear();
        TaskList taskList = new TaskList();
        taskList.MenuOptions();
        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu Principal...");
        Console.ReadKey();
    }
}