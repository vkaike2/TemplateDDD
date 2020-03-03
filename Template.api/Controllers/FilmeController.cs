using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult BuscarFilmes(int id)
        {
            RequestRetorno<Filme> retorno = _filmeService.BuscarFilmePorId(id);
            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult InserirFilme(Filme model)
        {
            RequestRetorno<string> retorno = _filmeService.InserirFilme(model);
            return Ok(retorno);
        }

        [HttpPut]
        public IActionResult AlterarFilme(Filme model)
        {
            RequestRetorno<string> retonro = _filmeService.AlterarFilme(model);
            return Ok(retonro);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            RequestRetorno<string> retorno = _filmeService.RemoverFilme(id);
            return Ok(retorno);
        }
    }
}