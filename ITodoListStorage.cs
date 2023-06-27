namespace Fotius.Example.Todo
{
    /// <summary>
    /// Storage layer for <see cref="TodoList"/>.
    /// </summary>
    public interface ITodoListStorage
    {
        /// <summary>
        /// Persists items to the storage associated with this todolist.
        /// </summary>
        /// <param name="list">The todolist to save.</param>
        /// <exception cref="StorageException">Thrown if the persistence operation fails.</exception>
        void Save(TodoList list);

        /// <summary>
        /// Loads list of items from this storage.
        /// </summary>
        /// <returns>The loaded todolist.</returns>
        /// <exception cref="StorageException">Thrown if the load operation fails.</exception>
        TodoList Load();
    }
}
