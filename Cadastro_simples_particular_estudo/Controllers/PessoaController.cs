using Cadastro_simples_particular_estudo.Domain;
using Cadastro_simples_particular_estudo.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cadastro_simples_particular_estudo.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private readonly PessoaServices _pessoaServices;
    //private readonly IValidator<Pessoa> _validator;

    public PessoaController()//(IValidator<Pessoa> validator)
    {
        _pessoaServices = new PessoaServices();
        //_validator = validator;
    }

    [HttpGet("GetAll")]
    public IEnumerable<Pessoa> GetAll()
    {
        //var pessoaServices = new PessoaServices();
        return _pessoaServices.GetAllPessoa();


    }


    [HttpGet("GetById/{id}")]
    public ActionResult GetById(Guid id)
    {
        //var pessoaServices = new PessoaServices();

        var pessoas = _pessoaServices.GetPessoaById(id);

        if (pessoas == null)
        {
            return NotFound($"Pessoa não encontrada com o Id ={id} informado");
        }

        return Ok(new
        {
            pessoas,
            msg = $"Pessoa com o ID = `{id}` encontrado",
            status = HttpStatusCode.OK
        });

    }


    [HttpPost]

    public ActionResult InsertPessoa(Pessoa pessoa)
    {
        //var validacao = _validator.Validate(pessoa);
        //if (!validacao.IsValid)
        //{

            //return BadRequest(validacao.ToDictionary());
        //}

        var pessoaServices = new PessoaServices();
        pessoaServices.InsertPessoa(pessoa);


        return Created("Pessoa adicionada com sucesso", pessoa);


    }


    [HttpPut("{id}")]
    public ActionResult UpdatePessoa(Pessoa pessoa, Guid id)
    {
        var pessoaServices = new PessoaServices();

        //var validacao = _validator.Validate(pessoa);

        //if (!validacao.IsValid)
        //{
        //    return BadRequest(validacao.ToDictionary());
        //}

        var pessoaDb = pessoaServices.UpdatePessoa(pessoa, id);

        if (pessoaDb is null)
        {
            return NotFound($"Pessoa não encontrada com o Id ={id} informado");
        }

        return Ok(new
        {
            pessoa,
            msg = $"Pessoa com o ID = `{id}` atualizado com sucesso",
            status = HttpStatusCode.OK
        });


    }


    [HttpDelete("{id}")]
    public ActionResult DeletePessoa(Guid id)
    {
        var pessoaServices = new PessoaServices();


        var pessoaDb = pessoaServices.DeletePessoa(id);

        if (pessoaDb is false)
        {
            return NotFound($"Pessoa não encontrada com o Id ={id} informado");
        }

        return Ok(new
        {
            msg = $"Pessoa com o ID = `{id}` removida com sucesso",
            status = HttpStatusCode.OK
        });

    }

}

