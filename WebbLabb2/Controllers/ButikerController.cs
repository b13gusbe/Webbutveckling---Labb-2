using Microsoft.AspNetCore.Mvc;
using WebbLabb2.DAL;
using WebbLabb2.Models;

namespace WebbLabb2.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ButikerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ButikerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet("Butiker")]
        public async Task<ActionResult<IEnumerable<Butiker>>> GetAllButiker()
        {
            var butiker = await _unitOfWork.Butiker.GetAll();
            return butiker.Any() ? Ok(butiker) : NotFound("Could not find any stores.");
        }

        [HttpGet("Butiker/{id}")]
        public async Task<ActionResult<Butiker>> GetButiker(int id)
        {
            var butik = await _unitOfWork.Butiker.GetById(id);
            return butik is not null ? Ok(butik) : NotFound("Could not find that store.");
        }

        [HttpPost("Butiker")]
        public async Task<ActionResult> AddButik(Butiker butik)
        {
            _unitOfWork.Butiker.Add(butik);
            _unitOfWork.Save();
            return Ok(butik);
        }

        [HttpPut("Butiker")]
        public async Task<ActionResult> UpdateButik(Butiker butiker)
        {
            bool updated = await _unitOfWork.Butiker.UpdateStore(butiker);
            if (updated)
            {
                _unitOfWork.Save();
                return Ok(butiker);
            }
            return BadRequest();
        }

        [HttpDelete("Butiker/{id}")]
        public async Task<ActionResult> DeleteButik(int id)
        {
            var butik = await _unitOfWork.Butiker.GetById(id);
            if (butik is null)
            {
                return BadRequest("Store not found.");
            }
            _unitOfWork.Butiker.Delete(butik);
            _unitOfWork.Save();
            return Ok($"Store with id {id} deleted.");
        }



    }
}
