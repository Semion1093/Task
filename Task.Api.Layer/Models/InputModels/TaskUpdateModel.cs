﻿namespace TestTask.API.Layer.Models
{
    public class TaskUpdateModel : TaskInputModel
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
    }
}
