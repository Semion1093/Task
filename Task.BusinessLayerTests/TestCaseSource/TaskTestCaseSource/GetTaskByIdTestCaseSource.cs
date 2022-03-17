using System.Collections;
using Task.BusinessLayer.Enums;
using Task.BusinessLayer.Models;

namespace Task.BusinessLayer.Tests.TestCaseSource
{
    public class GetTaskByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var expected = new TaskModel
            {
                Id = 1,
                Name = "Name1",
                Description = "Description1",
                Priority = 1,
                Status = TaskStatus.InProgress
            };

            int id = 1;
            yield return new object[] { id, expected };

        }
    }
}
