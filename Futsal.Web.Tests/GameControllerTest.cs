using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Core.Common.Contracts;
using Futsal.Business.Bootstrapper;
using Futsal.Business.Entities;
using Futsal.Business.Managers.Games;
using Futsal.Data;
using Futsal.Data.Contracts;
using Futsal.Web.Controllers;
using Futsal.Web.Tests.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using FluentAssertions;

namespace Futsal.Web.Tests
{
    public class GameControllerTest
    {
        private GameController _controller;
        private Mock<IGameRepository> _mockRepo;

        public GameControllerTest()
        {
            _mockRepo = new Mock<IGameRepository>();
            var mockUoW = new Mock<IUnitOfWork>();

            mockUoW.Setup(u => u.GetDataRepository<IGameRepository>()).Returns(_mockRepo.Object);
            _controller = new GameController(mockUoW.Object);
            _controller.MockUser("1", "taras");
        }

        [Fact]
        public void GetById_NoGameWithIdExists_ShouldReturnNotFound()
        {
            var result = _controller.GetById(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetById_ValidRequest_ShouldExist()
        {
            var game = new Game
            {
                Id = 1,
                Name = "Test Game"
            };
            _mockRepo.Setup(r => r.Get(1)).Returns(game);

            var result = _controller.GetById(1);
            result.Should().BeOfType<ObjectResult>();
        }
    }
}
