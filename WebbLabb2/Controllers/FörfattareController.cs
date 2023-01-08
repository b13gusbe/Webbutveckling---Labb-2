using Microsoft.AspNetCore.Mvc;
using WebbLabb2.DAL;
using WebbLabb2.Models;

namespace WebbLabb2.Controllers
{
    [ApiController]
    [Route("/api")]
    public class FörfattareController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FörfattareController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("Författare")]
        public async Task<ActionResult<IEnumerable<Böcker>>> GetAllFörfattare()
        {
            var författare = await _unitOfWork.Författare.GetAll(new string[] { "Böckers" });
            return författare.Any() ? Ok(författare) : NotFound("Could not find any authors.");
        }

        [HttpGet("Författare/{id}")]
        public async Task<ActionResult<Böcker>> GetFörfattare(int id)
        {
            var författare = await _unitOfWork.Författare.GetById(f => f.Id == id, new string[] { "Böckers" });
            return författare is not null ? Ok(författare) : NotFound("Could not find that author.");
        }

        [HttpPost("Författare")]
        public async Task<ActionResult> AddFörfattare(Författare författare)
        {
            _unitOfWork.Författare.Add(författare);
            _unitOfWork.Save();
            return Ok(författare);
        }

        [HttpPut("Författare")]
        public async Task<ActionResult> UpdateFörfattare(Författare författare)
        {
            bool updated = await _unitOfWork.Författare.UpdateFörfattare(författare);
            if (updated)
            {
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("Författare/{id}")]
        public async Task<ActionResult> DeleteFörfattare(int id)
        {
            var författare = await _unitOfWork.Författare.GetById(b => b.Id == id, null);
            if (författare is null)
            {
                return BadRequest("Author not found.");
            }
            _unitOfWork.Författare.Delete(författare);
            _unitOfWork.Save();
            return Ok($"Author with id {id} deleted.");
        }



    }
}
