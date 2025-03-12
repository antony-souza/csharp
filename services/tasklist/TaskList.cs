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

        // Converter JSON diretamente para um List de objetos
        List<Task> tasks = System.Text.Json.JsonSerializer.Deserialize<List<Task>>(jsonPath) ??
                           new List<Task>();

        Console.WriteLine("\n📋 Lista de Tarefas:");
        Console.WriteLine("==============================");

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"🆔 Tarefa #{i + 1}");
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
    }
}