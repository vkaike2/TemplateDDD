using Microsoft.AspNetCore.Mvc;
using System;
using Template.Domain.IServices;
using Template.Domain.Models;

namespace Template.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        //Exemplo Func
        //[HttpGet]
        //public IActionResult BuscarFilmes(string nome)
        //{
        //    bool retorno = TesteMetodod(e => e.Nome == nome);
        //    return Ok(retorno);
        //}

        //private bool TesteMetodod(Func<FilmeModel, bool> funcIntBool)
        //{
        //    FilmeModel model = new FilmeModel()
        //    {
        //        Id = Guid.NewGuid(),
        //        Nome = "Harry Potter"
        //    };

        //    bool retorno = funcIntBool(model);

        //    return retorno;
        //}

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarFilmes(Guid id)
        {
            RequestRetorno<FilmeModel> retorno = _filmeService.BuscarFilmePorId(id);
            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult InserirFilme(FilmeModel model)
        {

            RequestRetorno<string> retorno = _filmeService.InserirFilme(model);
            
            return Ok(retorno);
      
        }


        [HttpPut]
        public IActionResult AlterarFilme(FilmeModel model)
        {
            RequestRetorno<string> retonro = _filmeService.AlterarFilme(model);
            return Ok(retonro);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarFilme(Guid id)
        {
            RequestRetorno<string> retorno = _filmeService.RemoverFilme(id);
            return Ok(retorno);
        }
    }
}