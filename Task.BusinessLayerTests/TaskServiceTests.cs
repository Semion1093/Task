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
    public class Tests
    {
        private Mock<ITaskRepository> _taskRepositoryMock;
        private TaskService _taskService;

        [SetUp]
        public void Setup()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskRepositoryMock.Object);
        }

        [TestCaseSource(typeof(GetTaskByIdTestCaseSource))]
        public void GetTaskByIdTest(int id, TaskModel expected)
        {
            //given 
            _taskRepositoryMock.Setup(m => m.GetTaskById(id)).Returns(expected);

            //when 
            var actual = _taskService.GetTaskById(id);

            //then
            Assert.AreEqual(actual, expected);
            _taskRepositoryMock.Verify(m => m.GetTaskById(id), Times.Once);
        }

        [TestCase(0)]
        public void GetTaskByIdNegativeTest(int id)
        {
            //given
            _taskRepositoryMock.Setup(m => m.GetTaskById(It.IsAny<int>())).Returns((TaskModel)null);
            var expectedMessage = "Task wasn't found";

            // when
            EntityNotFoundException? exception = Assert.Throws<EntityNotFoundException>(() =>
            _taskService.GetTaskById(id));

            // then
            Assert.That(exception?.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(GetAllTasksTestCaseSource))]
        public void GetAllTasksTest(List<TaskModel> expected)
        {
            //given
            _taskRepositoryMock.Setup(m => m.GetAllTasks()).Returns(expected);

            //when
            var actual = _taskService.GetAllTasks();

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count, expected.Count);
            _taskRepositoryMock.Verify(m => m.GetAllTasks(), Times.Once);
        }

        [Test]
        public void UpdateTaskTest()
        {
            //given
            _taskRepositoryMock.Setup(x => x.GetTaskById(It.IsAny<int>())).Returns(It.IsAny<TaskModel>());

            //when
            _taskService.UpdateTask(It.IsAny<TaskModel>());

            //then
            _taskRepositoryMock.Verify(y => y.UpdateTask(It.IsAny<TaskModel>()), Times.Once);
        }

        [Test]
        public void DeleteTaskTest()
        {
            //given
            _taskRepositoryMock.Setup(m => m.DeleteTask(It.IsAny<TaskModel>()));

            //when
            _taskService.DeleteTask(It.IsAny<TaskModel>());

            //then
            _taskRepositoryMock.Verify(m => m.DeleteTask(It.IsAny<TaskModel>()), Times.Once());
        }

        [Test]
        public void GetTaskByProjectIdTest()
        {
            //given
            _taskRepositoryMock.Setup(m => m.GetTasksByProjectId(It.IsAny<int>()));

            //when
            _taskService.GetTasksByProjectId(It.IsAny<int>());

            //then
            _taskRepositoryMock.Verify(m => m.GetTasksByProjectId(It.IsAny<int>()), Times.Once());
        }
    }
}