using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Task.BusinessLayer.Exeptions;
using Task.BusinessLayer.Interfaces;
using Task.BusinessLayer.Models;
using Task.BusinessLayer.Services;
using Task.BusinessLayer.Tests.TestCaseSource;

namespace Task.BusinessLayerTests
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

        [TestCase(77)]
        public void AddProjectTest(int expected)
        {
            //given
            _projectRepositoryMock.Setup(m => m.AddProject(It.IsAny<ProjectModel>())).Returns(expected);

            //when 
            var actual = _projectService.AddProject(It.IsAny<ProjectModel>());

            //then
            _projectRepositoryMock.Verify(m => m.AddProject(It.IsAny<ProjectModel>()), Times.Once);
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(typeof(GetProjectByIdTestCaseSource))]
        public void GetProjectByIdTest(int id, ProjectModel expected)
        {
            //given 
            _projectRepositoryMock.Setup(m => m.GetProjectById(id)).Returns(expected);

            //when 
            var actual = _projectService.GetProjectById(id);

            //then
            Assert.AreEqual(actual, expected);
            _projectRepositoryMock.Verify(m => m.GetProjectById(id), Times.Once);
        }

        [TestCase(0)]
        public void GetProjectByIdNegativeTest(int id)
        {
            //given
            _projectRepositoryMock.Setup(m => m.GetProjectById(It.IsAny<int>())).Returns((ProjectModel)null);
            var expectedMessage = "Project wasn't found";

            // when
            EntityNotFoundException? exception = Assert.Throws<EntityNotFoundException>(() =>
            _projectService.GetProjectById(id));

            // then
            Assert.That(exception?.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(GetAllProjectsTestCaseSource))]
        public void GetAllProjectsTest(List<ProjectModel> expected)
        {
            //given
            _projectRepositoryMock.Setup(m => m.GetAllProjects()).Returns(expected);

            //when
            var actual = _projectService.GetAllProjects();

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count, expected.Count);
            _projectRepositoryMock.Verify(m => m.GetAllProjects(), Times.Once);
        }

        [Test]
        public void UpdateProjectTest()
        {
            //given
            _projectRepositoryMock.Setup(x => x.GetProjectById(It.IsAny<int>())).Returns(It.IsAny<ProjectModel>());

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
