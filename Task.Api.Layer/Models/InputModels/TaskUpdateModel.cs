using TestTask.API.Layer.Models;

namespace Task.API.Layer.Models.InputModels
{
    internal class TaskUpdateModel : TaskInputModel
    {
        public Guid Id { get; set; }
    }
}
