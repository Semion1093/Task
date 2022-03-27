using TestTask.BusinessLayer.Enums;

namespace TestTask.API.Layer.Models
{
    public class ProjectOutputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Completion { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public List<TaskOutputModel> Tasks { get; set; }
    }
}
