using System;
using System.Collections;
using Task.BusinessLayer.Enums;
using Task.BusinessLayer.Models;

namespace Task.BusinessLayer.Tests.TestCaseSource
{
    public class GetProjectByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var expected = new ProjectModel
            {
                Id = 1,
                Name = "Name1",
                Priority = 1,
                Status = ProjectStatus.Active,
                Start = DateTime.Now,
                Completion = DateTime.Now
            };

            int id = 1;
            yield return new object[] { id, expected };
        }

    }
}
