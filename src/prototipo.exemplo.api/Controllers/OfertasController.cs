using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prototipo.Exemplo.Application.UseCases.Ofertas.CarregarOferta;
using Prototipo.Exemplo.Application.UseCases.Ofertas.CriarOferta;
using Prototipo.Exemplo.Application.UseCases.Ofertas.PesquisaOfertas;

namespace prototipo.exemplo.api.Controllers;


[ApiController]
[Route("ofertas")]
public class OfertasController : ControllerBase
{
    public IMediator _mediator;

    public OfertasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<ActionResult> GetOfertas([FromQuery] PesquisarOfertaQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost()]
    public async Task<ActionResult> PostOferta([FromBody] CriarOfertaCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("{ofertaId}")]
    public async Task<ActionResult> GetOferta(Guid ofertaId)
    {
        var query = new CarregarOfertaQuery()
        {
            OfertaId = ofertaId
        };

        return Ok(await _mediator.Send(query));
    }
}
