using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Exemplo.Application.UseCases.Ofertas.CarregarOferta;


public class CarregarOfertaQuery : IQuery<OfertaDto>
{
    public Guid OfertaId { get; set; }
}
