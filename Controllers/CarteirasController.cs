using Microsoft.AspNetCore.Mvc;
using ProjetoPainel.Models;
using ProjetoPainel.Repository.Interface;
using RPA._000.RetornaCarteirasAPI.Models;

namespace RPA._000.RetornaCarteirasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteirasController : ControllerBase
    {
        private readonly IRepository _Repository;
        public CarteirasController(IRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpPost("GetCarteiraPorID")]
        public ActionResult GetCarteiraPorID(CarteiraInputModel carteira)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var response = _Repository.GetCarteiraPorID(carteira.codigoCarteira);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpGet("GetPessoa")]
        public ActionResult GetNomesPessoas()
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var response = _Repository.GetPessoas();
            if (response == null)
                return NotFound();
           
            return Ok(response);
        }

        [HttpPost("PostPessoaCarteira")]
        public void PostPessoaCarteira(InCarteiraPessoa inCarteiraPessoa)
        {
            _Repository.AssociarPessoaCarteira(inCarteiraPessoa);
        }

        [HttpPost("PostPessoa")]
        public void PostPessoa(InPessoa inPessoa)
        {
            _Repository.InserePessoa(inPessoa.nomePessoa, inPessoa.cargo);
        }
    }
}