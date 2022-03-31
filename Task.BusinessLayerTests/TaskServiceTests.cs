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
    public class TaskServiceTests
    {
        private Mock<ITaskRepository> _taskRepositoryMock;
        private TaskService _taskService;

        [SetUp]
        public void Setup()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskRepositoryMock.Object);
        }

        [Test]
        public void AddTaskTest()
        {
            //given
            var expected = Guid.NewGuid();
            _taskRepositoryMock.Setup(m => m.AddTask(It.IsAny<TaskModel>())).ReturnsAsync(expected);

            //when 
            var actual = _taskService.AddTask(It.IsAny<TaskModel>()).Result;

            //then
            _taskRepositoryMock.Verify(m => m.AddTask(It.IsAny<TaskModel>()), Times.Once);
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(typeof(GetTaskByIdTestCaseSource))]
        public void GetTaskByIdTest(TaskModel expected)
        {
            //given 
            _taskRepositoryMock.Setup(m => m.GetTaskById(It.IsAny<Guid>())).ReturnsAsync(expected);

            //when 
            var actual = _taskService.GetTaskById(It.IsAny<Guid>()).Result;

            //then
            Assert.AreEqual(actual, expected);
            _taskRepositoryMock.Verify(m => m.GetTaskById(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public void GetTaskByIdNegativeTest()
        {
            //given
            _taskRepositoryMock.Setup(m => m.GetTaskById(It.IsAny<Guid>())).ReturnsAsync((TaskModel)null);
            var expectedMessage = "Task wasn't found";

            // when
            EntityNotFoundException? exception = Assert.ThrowsAsync<EntityNotFoundException>(() =>
            _taskService.GetTaskById(It.IsAny<Guid>()));

            // then
            Assert.That(exception?.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(GetAllTasksTestCaseSource))]
        public void GetAllTasksTest(List<TaskModel> expected)
        {
            //given
            _taskRepositoryMock.Setup(m => m.GetAllTasks()).ReturnsAsync(expected);

            //when
            var actual = _taskService.GetAllTasks().Result;

            //then
            Assert.IsNotNull(actual);
            _taskRepositoryMock.Verify(m => m.GetAllTasks(), Times.Once);
        }

        [Test]
        public void UpdateTaskTest()
        {
            //given
            _taskRepositoryMock.Setup(x => x.GetTaskById(It.IsAny<Guid>())).ReturnsAsync(It.IsAny<TaskModel>());

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
            _taskRepositoryMock.Setup(m => m.GetTasksByProjectId(It.IsAny<Guid>()));

            //when
            _taskService.GetTasksByProjectId(It.IsAny<Guid>());

            //then
            _taskRepositoryMock.Verify(m => m.GetTasksByProjectId(It.IsAny<Guid>()), Times.Once());
        }
    }
}