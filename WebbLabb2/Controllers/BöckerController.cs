using Microsoft.AspNetCore.Mvc;
using WebbLabb2.DAL;
using WebbLabb2.Models;

namespace WebbLabb2.Controllers
{
    [ApiController]
    [Route("/api")]
    public class BöckerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BöckerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("/Böcker")]
        public async Task<ActionResult<IEnumerable<Böcker>>> GetBöcker()
        {
            var böcker = _unitOfWork.Böcker.GetAll();
            return böcker.Any() ? Ok(böcker) : NotFound("Could not find any books.");
        }

    }
}
