﻿namespace TestTask.BusinessLayer.Exeptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
    }
}
