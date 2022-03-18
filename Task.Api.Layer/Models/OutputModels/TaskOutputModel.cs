using TaskStatus = TestTask.BusinessLayer.Enums.TaskStatus;

namespace TestTask.API.Layer.Models
{
    public class TaskOutputModel
    {
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
