using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Futsal.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Moq;

namespace Futsal.Web.Tests.Extensions
{
    public static class ControllerExtension
    {
        public static void MockUser(this GameController controller, string userId, string userName)
        {
            var cp = new Mock<ClaimsPrincipal>();
            cp.Setup(m => m.HasClaim(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(ctx => ctx.User).Returns(cp.Object);
            
            var controllerContextMock = new Mock<ControllerContext>();
            controller.ControllerContext.HttpContext = contextMock.Object;
            controller.ControllerContext = controllerContextMock.Object;
        }
        
    }
}
