using System.ComponentModel.DataAnnotations;

namespace Prototipo.Exemplo.Domain._Shared.Entities;


/// <summary>
/// Classe base para entidades genéricas.
/// </summary>
/// <typeparam name="TKey">O tipo do identificador da entidade.</typeparam>
public abstract class Entity<TKey> where TKey : EntityId
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Entity{TKey}"/>.
    /// </summary>
    protected Entity()
    {
        Id = null!;
    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Entity{TKey}"/> com um identificador.
    /// </summary>
    /// <param name="id">O identificador da entidade.</param>
    protected Entity(TKey id)
    {
        Id = id;
    }

    /// <summary>
    /// Obtém o identificador da entidade.
    /// </summary>
    public TKey Id { get; protected set; }
}
