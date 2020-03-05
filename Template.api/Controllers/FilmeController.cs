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
            RequestRetorno<FilmeModel> retorno = _filmeService.InserirFilme(model);   
            return Ok(retorno);
        }

        [HttpPut]
        public IActionResult AlterarFilme(FilmeModel model)
        {
            RequestRetorno<FilmeModel> retonro = _filmeService.AlterarFilme(model);
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