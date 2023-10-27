using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Instituicoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.CarregarInstituicao;


public class CarregarInstituicaoQuery : IQuery<InstituicaoDto>
{
    public Guid InstituicaoId { get; set; }
}
