using app.interfaces.tasklist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace app.services.tasklist;

public class TaskList : ITaskList
{
    private readonly string _pathDesktopJson;
    private readonly string _fileNameWithType = "TaskList.json";

    public TaskList()
    {
        string initPathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        _pathDesktopJson = Path.Combine(initPathDesktop, _fileNameWithType);

        if (!File.Exists(_pathDesktopJson))
        {
            File.WriteAllText(_pathDesktopJson, "[]");
            Console.WriteLine("Arquivo JSON criado com sucesso!");
        }
    }

    public void CreateNewTask(string taskName, string taskDescription)
    {
        var tasks = LoadTasks();
        var idTask = tasks.Count + 1;
        var newTask = new Task
        {
            Id = idTask.ToString(),
            TaskName = taskName,
            TaskDescription = taskDescription,
        };

        tasks.Add(newTask);

        SaveTasksInJsonFile(tasks);
    }

    public void SaveTasksInJsonFile(List<Task> tasks)
    {
        string convertToJson = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_pathDesktopJson, convertToJson);
    }

    public List<Task> LoadTasks()
    {
        if (!File.Exists(_pathDesktopJson))
        {
            Console.WriteLine("⚠️ Nenhuma arquivo de tarefas encontrado.");
            return new List<Task>();
        }

        string jsonPath = File.ReadAllText(_pathDesktopJson);

        if (!string.IsNullOrEmpty(jsonPath) && jsonPath == "[]")
        {
            Console.WriteLine("⚠️ Nenhuma tarefa encontrada.");

            return new List<Task>();
        }
        
        List<Task> tasks = JsonSerializer.Deserialize<List<Task>>(jsonPath) ?? new List<Task>();

        Console.WriteLine("\n📋 Lista de Tarefas:");
        Console.WriteLine("==============================");

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"🆔 Tarefa #{tasks[i].Id}");
            Console.WriteLine($"📌 Nome: {tasks[i].TaskName}");
            Console.WriteLine($"📝 Descrição: {tasks[i].TaskDescription}");
            Console.WriteLine("==============================");
        }

        return tasks;
    }

    public void ListTaskByName(string taskName)
    {
    }

    public void RemoveTask(int id)
    {
    }

    public void MenuOptions()
    {
        bool continueMenu = true;

        while (continueMenu)
        {
            Console.Clear();
            Console.WriteLine("👨‍💻 Menu de Tarefas");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Listar todas as tarefas");
            Console.WriteLine("2. Criar nova tarefa");
            Console.WriteLine("3. Sair");
            Console.WriteLine("==============================");
            Console.Write("Escolha uma opção: ");
        
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    LoadTasks();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu de Tarefas...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("Digite o nome da tarefa: ");
                    string taskName = Console.ReadLine();

                    Console.Write("Digite a descrição da tarefa: ");
                    string taskDescription = Console.ReadLine();

                    CreateNewTask(taskName, taskDescription);
                    Console.WriteLine("✅ Tarefa criada com sucesso!");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.WriteLine("👋 Até logo!");
                    continueMenu = false;
                    break;
                default:
                    Console.WriteLine("⚠️ Opção inválida. Tente novamente.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

}