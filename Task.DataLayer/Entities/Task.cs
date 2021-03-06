using TaskStatus = TestTask.BusinessLayer.Enums.TaskStatus;

namespace TestTask.DataLayer.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public virtual Project Project { get; set;}
        public bool IsDeleted { get; set; }
    }
}
