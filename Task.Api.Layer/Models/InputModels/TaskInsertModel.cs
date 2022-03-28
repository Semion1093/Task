namespace TestTask.API.Layer.Models
{
    public class TaskInsertModel : TaskInputModel
    {
        public Guid ProjectId { get; set; }
    }
}
