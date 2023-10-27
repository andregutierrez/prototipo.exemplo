using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prototipo.Exemplo.Application.UseCases.Cursos.AtualizacaoCurso;
using Prototipo.Exemplo.Application.UseCases.Cursos.CarregarCurso;
using Prototipo.Exemplo.Application.UseCases.Cursos.CriacaoCurso;
using Prototipo.Exemplo.Application.UseCases.Cursos.ExclusaoCurso;
using Prototipo.Exemplo.Application.UseCases.Cursos.PesquisarCurso;

namespace prototipo.exemplo.api.Controllers;


[ApiController]
[Route("cursos")]
public class CursosController : ControllerBase
{
    public IMediator _mediator;

    public CursosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<ActionResult> GetCursos([FromQuery] PesquisarCursoQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost()]
    public async Task<ActionResult> PostCurso([FromBody] CriarCursoCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("{cursoId}")]
    public async Task<ActionResult> GetCurso(Guid cursoId)
    {
        var query = new CarregarCursoQuery()
        {
            CursoId = cursoId
        };

        return Ok(await _mediator.Send(query));
    }

    [HttpPut("{cursoId}")]
    public async Task<ActionResult> PutCurso(Guid cursoId, [FromBody] AtualizarCursoCommand command)
    {
        command.CursoId = cursoId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{cursoId}")]
    public async Task<ActionResult> DeleteCurso(Guid cursoId, [FromBody] RemoverCursoCommand command)
    {
        command.CursoId = cursoId;
        await _mediator.Send(command);
        return Ok();
    }
}
