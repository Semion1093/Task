using TaskStatus = Task.BusinessLayer.Enums.TaskStatus;

namespace Task.API.Models
{
    public class TaskOutputModel
    {
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
