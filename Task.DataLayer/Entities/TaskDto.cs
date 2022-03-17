using TaskStatus = Task.BusinessLayer.Enums.TaskStatus;

namespace Task.DataLayer.Entities
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public virtual ProjectDto Project { get; set;}
        public bool IsDeleted { get; set; }
    }
}
