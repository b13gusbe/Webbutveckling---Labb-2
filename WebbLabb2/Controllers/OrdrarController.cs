using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebbLabb2.DAL;
using WebbLabb2.Models;

namespace WebbLabb2.Controllers
{
    [ApiController]
    [Route("/api")]
    public class OrdrarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdrarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Ordrar")]
        public async Task<ActionResult<IEnumerable<Ordrar>>> GetAllOrdrar()
        {
            var ordrar = await _unitOfWork.Ordrar.GetAll(null);
            return ordrar.Any() ? Ok(ordrar) : NotFound("Could not find any orders.");
        }

        [HttpGet("Ordrar/{id}")]
        public async Task<ActionResult<Ordrar>> GetOrder(int id)
        {
            var order = await _unitOfWork.Ordrar.GetById(o => o.Id == id, null);
            return order is not null ? Ok(order) : NotFound($"Could not find any order with id: {id}");
        }

        [HttpPost("Ordrar")]
        public async Task<ActionResult> AddOrder(Ordrar order)
        {
            _unitOfWork.Ordrar.Add(order);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("Ordrar")]
        public async Task<ActionResult> UpdateOrder(Ordrar order)
        {
            var updated = await _unitOfWork.Ordrar.UpdateOrder(order);
            if (updated)
            {
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("Ordrar/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _unitOfWork.Ordrar.GetById(o => o.Id == id, null);
            if(order is not null)
            {
                _unitOfWork.Ordrar.Delete(order);
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }


    }
}
