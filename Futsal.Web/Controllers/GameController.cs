using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Futsal.Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Futsal.Web.Controllers
{
    public class GameController: Controller
    {
        private IUnitOfWork _unitOfWork;
        public GameController(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentException(nameof(unitOfWork));
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetById(long id)
        {
            var gameRepo = _unitOfWork.GetDataRepository<IGameRepository>();
            var game = gameRepo.Get(id);
            if (game == null)
                return NotFound();
            return new ObjectResult(game);
        }
    }
}
