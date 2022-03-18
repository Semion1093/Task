using System;
using System.Collections;
using TestTask.BusinessLayer.Enums;
using TestTask.BusinessLayer.Models;

namespace TestTask.BusinessLayer.Tests.TestCaseSource
{
    public class GetProjectByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var expected = new ProjectModel
            {
                Id = Guid.NewGuid(),
                Name = "Name1",
                Priority = 1,
                Status = ProjectStatus.Active,
                Start = DateTime.Now,
                Completion = DateTime.Now
            };

            Guid id = Guid.NewGuid();

            yield return new object[] { id, expected };
        }

    }
}
