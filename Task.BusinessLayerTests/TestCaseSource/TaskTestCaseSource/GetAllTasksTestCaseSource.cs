using System.Collections;
using System.Collections.Generic;
using Task.BusinessLayer.Enums;
using Task.BusinessLayer.Models;

namespace Task.BusinessLayer.Tests.TestCaseSource
{
    public class GetAllTasksTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var expected = new List<TaskModel>()
            {
                new TaskModel()
                {
                    Id = 1,
                    Name = "Name1",
                    Description = "Description1",
                    Priority = 1,
                    Status = TaskStatus.InProgress
                },
                new TaskModel()
                {
                    Id = 2,
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
