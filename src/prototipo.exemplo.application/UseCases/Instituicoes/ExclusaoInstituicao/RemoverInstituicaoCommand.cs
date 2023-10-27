using Prototipo.Exemplo.Application._Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Exemplo.Application.UseCases.Instituicoes.ExclusaoInstituicao;


public class RemoverInstituicaoCommand : ICommand
{
    public Guid InstituicaoId { get; set; }
}
