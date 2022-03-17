using TaskStatus = Task.BusinessLayer.Enums.TaskStatus;

namespace Task.BusinessLayer.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
