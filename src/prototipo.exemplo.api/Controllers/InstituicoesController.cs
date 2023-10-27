using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prototipo.Exemplo.Application.UseCases.Instituicoes.AtualizacaoInstituicao;
using Prototipo.Exemplo.Application.UseCases.Instituicoes.CarregarInstituicao;
using Prototipo.Exemplo.Application.UseCases.Instituicoes.CriacaoInstituicao;
using Prototipo.Exemplo.Application.UseCases.Instituicoes.ExclusaoInstituicao;
using Prototipo.Exemplo.Application.UseCases.Instituicoes.PesquisarInstituicoes;

namespace prototipo.exemplo.api.Controllers;


[ApiController]
[Route("instituicoes")]
public class InstituicoesController : ControllerBase
{
    public IMediator _mediator;

    public InstituicoesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<ActionResult> GetInstituicoes([FromQuery] PesquisarInstituicaoQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost()]
    public async Task<ActionResult> PostInstituicao([FromBody] CriarInstituicaoCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("{instituicaoId}")]
    public async Task<ActionResult> GetInstituicao(Guid instituicaoId)
    {
        var query = new CarregarInstituicaoQuery()
        {
            InstituicaoId = instituicaoId
        };

        return Ok(await _mediator.Send(query));
    }

    [HttpPut("{instituicaoId}")]
    public async Task<ActionResult> PutInstituicao(Guid instituicaoId, [FromBody] AtualizarInstituicaoCommand command)
    {
        command.InstituicaoId = instituicaoId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{instituicaoId}")]
    public async Task<ActionResult> DeleteInstituicao(Guid instituicaoId, [FromBody] RemoverInstituicaoCommand command)
    {
        command.InstituicaoId = instituicaoId;
        await _mediator.Send(command);
        return Ok();
    }
}
