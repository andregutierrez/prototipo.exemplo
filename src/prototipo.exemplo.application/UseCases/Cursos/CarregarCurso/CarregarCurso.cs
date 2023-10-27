using Prototipo.Exemplo.Application._Shared.Queries;
using Prototipo.Exemplo.Application.DTOs.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Exemplo.Application.UseCases.Cursos.CarregarCurso;


public class CarregarCursoQuery : IQuery<CursoDto>
{
    public Guid CursoId { get; set; }
}
