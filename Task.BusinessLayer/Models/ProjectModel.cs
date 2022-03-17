using Task.BusinessLayer.Enums;

namespace Task.BusinessLayer.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Completion { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public List<TaskModel> Tasks { get; set; }
    }
}
