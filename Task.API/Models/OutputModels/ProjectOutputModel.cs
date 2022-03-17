﻿using Task.BusinessLayer.Enums;

namespace Task.API.Models
{
    public class ProjectOutputModel
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Completion { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public List<TaskUpdateModel> Tasks { get; set; }
    }
}