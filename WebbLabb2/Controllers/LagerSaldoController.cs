using Microsoft.AspNetCore.Mvc;
using WebbLabb2.DAL;
using WebbLabb2.Models;

namespace WebbLabb2.Controllers
{
    [ApiController]
    [Route("/api")]
    public class LagerSaldoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LagerSaldoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Saldo")]
        public async Task<ActionResult<IEnumerable<LagerSaldo>>> GetAllSaldos()
        {
            var lagerSaldo = await _unitOfWork.LagerSaldo.GetAll();
            return Ok(lagerSaldo);
        }

        [HttpGet("Saldo/Butik/{id}")]
        public async Task<ActionResult<IEnumerable<LagerSaldo>>> GetSaldoForStore(int id)
        {
            var lagerSaldo = await _unitOfWork.LagerSaldo.GetByStoreId(id);
            return Ok(lagerSaldo);
        }

        [HttpGet("Saldo/Bok/{isbn}")]
        public async Task<ActionResult<IEnumerable<LagerSaldo>>> GetSaldoForBook(string isbn)
        {
            var lagerSaldo = await _unitOfWork.LagerSaldo.GetByBookISBN(isbn);
            return Ok(lagerSaldo);
        }


    }
}
