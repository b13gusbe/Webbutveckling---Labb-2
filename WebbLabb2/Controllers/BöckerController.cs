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

        [HttpGet("Böcker")]
        public async Task<ActionResult<IEnumerable<Böcker>>> GetAllBöcker()
        {
            var böcker = await _unitOfWork.Böcker.GetAll();
            return böcker.Any() ? Ok(böcker) : NotFound("Could not find any books.");
        }

        [HttpGet("Böcker/{isbn}")]
        public async Task<ActionResult<Böcker>> GetBöcker(string ISBN)
        {
            var bok = await _unitOfWork.Böcker.GetBook(ISBN);
            return bok is not null ? Ok(bok) : NotFound("Could not find that book.");
        }

        [HttpPost("Böcker")]
        public async Task<ActionResult> AddBok(Böcker bok)
        {
            _unitOfWork.Böcker.Add(bok);
            _unitOfWork.Save();
            return Ok(bok);
        }

        [HttpPut("Böcker")]
        public async Task<ActionResult> UpdateBok(Böcker bok)
        {
            bool updated = await _unitOfWork.Böcker.UpdateBook(bok);
            if (updated)
            {
                _unitOfWork.Save();
                return Ok(bok);
            }
            return BadRequest();
        }

        [HttpDelete("Böcker/{isbn}")]
        public async Task<ActionResult> DeleteBok(string isbn)
        {
            var bok = await _unitOfWork.Böcker.GetBook(isbn);
            if(bok is null)
            {
                return BadRequest("Book not found.");
            }
            _unitOfWork.Böcker.Delete(bok);
            _unitOfWork.Save();
            return Ok($"Book with isbn {isbn} deleted.");
        }
    }
}
