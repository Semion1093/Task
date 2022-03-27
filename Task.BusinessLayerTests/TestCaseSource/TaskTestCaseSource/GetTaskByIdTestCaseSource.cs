using System;
using System.Collections;
using TestTask.BusinessLayer.Enums;
using TestTask.BusinessLayer.Models;

namespace TestTask.BusinessLayer.Tests.TestCaseSource
{
    public class GetTaskByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var expected = new TaskModel
            {
                Id = Guid.NewGuid(),
                Name = "Name1",
                Description = "Description1",
                Priority = 1,
                Status = TaskStatus.InProgress
            };

            yield return new object[] {expected };

        }
    }
}
