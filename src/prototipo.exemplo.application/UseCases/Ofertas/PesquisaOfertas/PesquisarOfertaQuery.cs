using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Exemplo.Application.UseCases.Ofertas.PesquisaOfertas;


public class PesquisarOfertaQuery : IQuery<IEnumerable<OfertaDto>>
{
    public Guid? CursoId { get; set; }
    public Guid? InstituicaoId { get; set; }
}

