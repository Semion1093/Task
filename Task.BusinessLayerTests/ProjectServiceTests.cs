using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestTask.BusinessLayer.Exeptions;
using TestTask.BusinessLayer.Interfaces;
using TestTask.BusinessLayer.Models;
using TestTask.BusinessLayer.Services;
using TestTask.BusinessLayer.Tests.TestCaseSource;

namespace TestTask.BusinessLayerTests
{
    public class ProjectServiceTests
    {
        private Mock<IProjectRepository> _projectRepositoryMock;
        private ProjectService _projectService;

        [SetUp]
        public void Setup()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
            _projectService = new ProjectService(_projectRepositoryMock.Object);
        }

        [Test]
        public void AddProjectTest()
        {
            //given
            var expected = Guid.NewGuid();
            _projectRepositoryMock.Setup(m => m.AddProject(It.IsAny<ProjectModel>())).ReturnsAsync(expected);

            //when 
            var actual = _projectService.AddProject(It.IsAny<ProjectModel>()).Result;

            //then
            _projectRepositoryMock.Verify(m => m.AddProject(It.IsAny<ProjectModel>()), Times.Once);
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(typeof(GetProjectByIdTestCaseSource))]
        public void GetProjectByIdTest(ProjectModel expected)
        {
            //given 
            _projectRepositoryMock.Setup(m => m.GetProjectById(It.IsAny<Guid>())).ReturnsAsync(expected);

            //when 
            var actual = _projectService.GetProjectById(It.IsAny<Guid>()).Result;

            //then
            Assert.AreEqual(actual, expected);
            _projectRepositoryMock.Verify(m => m.GetProjectById(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public void GetProjectByIdNegativeTest()
        {
            //given
            _projectRepositoryMock.Setup(m => m.GetProjectById(It.IsAny<Guid>())).ReturnsAsync((ProjectModel)null);
            var expectedMessage = "Project wasn't found";

            // when
            EntityNotFoundException? exception = Assert.ThrowsAsync<EntityNotFoundException>(() =>
            _projectService.GetProjectById(Guid.NewGuid()));

            // then
            Assert.That(exception?.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(GetAllProjectsTestCaseSource))]
        public void GetAllProjectsTest(List<ProjectModel> expected)
        {
            //given
            _projectRepositoryMock.Setup(m => m.GetAllProjects()).ReturnsAsync(expected);

            //when
            var actual = _projectService.GetAllProjects().Result;

            //then
            Assert.IsNotNull(actual);
            _projectRepositoryMock.Verify(m => m.GetAllProjects(), Times.Once);
        }

        [Test]
        public void UpdateProjectTest()
        {
            //given
            _projectRepositoryMock.Setup(x => x.GetProjectById(It.IsAny<Guid>())).ReturnsAsync(It.IsAny<ProjectModel>());

            //when
            _projectService.UpdateProject(It.IsAny<ProjectModel>());

            //then
            _projectRepositoryMock.Verify(y => y.UpdateProject(It.IsAny<ProjectModel>()), Times.Once);
        }

        [Test]
        public void DeleteProjectTest()
        {
            //given
            _projectRepositoryMock.Setup(m => m.DeleteProject(It.IsAny<ProjectModel>()));

            //when
            _projectService.DeleteProject(It.IsAny<ProjectModel>());

            //then
            _projectRepositoryMock.Verify(m => m.DeleteProject(It.IsAny<ProjectModel>()), Times.Once());
        }
    }
}
