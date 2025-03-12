using app.services.tasklist;
using Task = app.services.tasklist.Task;

namespace app.interfaces.tasklist;

public interface ITaskList
{
    void CreateNewTask(string taskName, string taskDescription);
    void SaveTasksInJsonFile(List<Task> tasks);
    List<Task> LoadTasks();
    void ListTaskByName(string taskName);
    void RemoveTask(int id);

    void MenuOptions();
}