using TestTask.BusinessLayer.Enums;

namespace TestTask.DataLayer.Entities
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Start{ get; set; }
        public DateTime Completion { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public virtual ICollection<TaskDto> Tasks { get; set; }
        public bool IsDeleted { get; set; }
    }
}
