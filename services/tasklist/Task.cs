using System.Runtime.InteropServices.JavaScript;

namespace app.services.tasklist;

public class Task
{
    public string Id { get; set; } = String.Empty;
    public string TaskName { get; set; } = String.Empty;
    public string TaskDescription { get; set; } = String.Empty;
}