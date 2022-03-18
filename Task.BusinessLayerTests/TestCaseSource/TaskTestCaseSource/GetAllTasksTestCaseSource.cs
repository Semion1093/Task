using System;
using System.Collections;
using System.Collections.Generic;
using TestTask.BusinessLayer.Enums;
using TestTask.BusinessLayer.Models;

namespace TestTask.BusinessLayer.Tests.TestCaseSource
{
    public class GetAllTasksTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var expected = new List<TaskModel>()
            {
                new TaskModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Name1",
                    Description = "Description1",
                    Priority = 1,
                    Status = TaskStatus.InProgress
                },
                new TaskModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Name2",
                    Description = "Description2",
                    Priority = 2,
                    Status = TaskStatus.ToDo
                },
            };

            yield return new object[] { expected };
        }
    }
}
