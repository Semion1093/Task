using System;
using System.Collections;
using System.Collections.Generic;
using TestTask.BusinessLayer.Enums;
using TestTask.BusinessLayer.Models;

namespace TestTask.BusinessLayer.Tests.TestCaseSource
{
    internal class GetAllProjectsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var expected = new List<ProjectModel>()
            {
                new ProjectModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Name1",
                    Priority = 1,
                    Status = ProjectStatus.Active,
                    Start = DateTime.Now,
                    Completion = DateTime.Now
                },
                new ProjectModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Name2",
                    Priority = 2,
                    Status = ProjectStatus.Completed,
                    Start = DateTime.UtcNow,
                    Completion = DateTime.UtcNow
                },
            };

            yield return new object[] { expected };
        }
    }
}
