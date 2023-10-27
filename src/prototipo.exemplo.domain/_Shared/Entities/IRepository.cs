using System.Linq.Expressions;

namespace Prototipo.Exemplo.Domain._Shared.Entities;

/// <summary>
/// Interface para o repositório que lida com operações em entidades.
/// </summary>
/// <typeparam name="TEntity">O tipo de entidade.</typeparam>
/// <typeparam name="TKey">O tipo da chave da entidade.</typeparam>
public interface IRepository<TEntity, TKey>
    where TKey : EntityId
    where TEntity : Entity<TKey>
{
    /// <summary>
    /// Exclui uma entidade.
    /// </summary>
    /// <param name="entity">A entidade a ser excluída.</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Exclui várias entidades.
    /// </summary>
    /// <param name="entities">A coleção de entidades a serem excluídas.</param>
    void Delete(IEnumerable<TEntity> entities);

    /// <summary>
    /// Verifica se uma entidade com a chave especificada existe assincronamente.
    /// </summary>
    /// <param name="id">A chave da entidade.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém um valor booleano indicando se a entidade existe ou não.</returns>
    Task<bool> ExistsAsync(TKey id);

    /// <summary>
    /// Procura uma entidade com a chave especificada assincronamente.
    /// </summary>
    /// <param name="id">A chave da entidade.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém a entidade encontrada ou null se não encontrada.</returns>
    Task<TEntity?> FindAsync(TKey id);

    /// <summary>
    /// Procura uma entidade que corresponda ao predicado especificado assincronamente.
    /// </summary>
    /// <param name="predicate">O predicado usado para corresponder à entidade.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém a entidade encontrada ou null se não encontrada.</returns>
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Obtém uma entidade com a chave especificada assincronamente.
    /// </summary>
    /// <param name="id">A chave da entidade.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém a entidade encontrada.</returns>
    Task<TEntity> GetAsync(TKey id);

    /// <summary>
    /// Obtém uma entidade com a chave especificada e inclui detalhes relacionados assincronamente.
    /// </summary>
    /// <param name="id">A chave da entidade.</param>
    /// <param name="propertySelectors">Os seletores de propriedade usados para incluir detalhes relacionados.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém a entidade encontrada.</returns>
    Task<TEntity> GetAsyncWithDetails(TKey id, params Expression<Func<TEntity, object?>>[] propertySelectors);

    /// <summary>
    /// Obtém uma entidade que corresponda ao predicado especificado assincronamente.
    /// </summary>
    /// <param name="predicate">O predicado usado para corresponder à entidade.</param>
    /// <param name="includeDetails">Flag indicando se deve incluir detalhes relacionados ou não.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém a entidade encontrada.</returns>
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true);

    /// <summary>
    /// Obtém uma lista de entidades assincronamente.
    /// </summary>
    /// <returns>Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém a lista de entidades.</returns>
    Task<IEnumerable<TEntity>> GetListAsync();

    /// <summary>
    /// Obtém uma lista de entidades que correspondem ao predicado especificado assincronamente.
    /// </summary>
    /// <param name="predicate">O predicado usado para corresponder às entidades.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém a lista de entidades.</returns>
    Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Obtém uma lista paginada de entidades assincronamente.
    /// </summary>
    /// <param name="skipCount">O número de entidades a serem ignoradas.</param>
    /// <param name="maxResultCount">O número máximo de entidades a serem retornadas.</param>
    /// <param name="sorting">Os critérios de ordenação.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém a lista paginada de entidades.</returns>
    Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting);

    /// <summary>
    /// Obtém um objeto consultável para entidades.
    /// </summary>
    /// <returns>O objeto consultável para entidades.</returns>
    IQueryable<TEntity> GetQueryable();

    /// <summary>
    /// Insere uma entidade assincronamente.
    /// </summary>
    /// <param name="entity">A entidade a ser inserida.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task InsertAsync(TEntity entity);

    /// <summary>
    /// Insere várias entidades assincronamente.
    /// </summary>
    /// <param name="entities">A coleção de entidades a serem inseridas.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task InsertAsync(IEnumerable<TEntity> entities);

    /// <summary>
    /// Atualiza uma entidade.
    /// </summary>
    /// <param name="entity">A entidade a ser atualizada.</param>
    void Update(TEntity entity);

    /// <summary>
    /// Atualiza várias entidades.
    /// </summary>
    /// <param name="entities">A coleção de entidades a serem atualizadas.</param>
    void Update(IEnumerable<TEntity> entities);

    /// <summary>
    /// Obtém um objeto consultável para entidades com detalhes relacionados.
    /// </summary>
    /// <param name="propertySelectors">Os seletores de propriedade usados para incluir detalhes relacionados.</param>
    /// <returns>O objeto consultável para entidades com detalhes relacionados.</returns>
    IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] propertySelectors);
}
