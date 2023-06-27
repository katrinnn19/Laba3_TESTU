using System;
using System.Collections.Generic;
using System.IO;

namespace Fotius.Example.Todo
{
    public class FileTodoListStorage : ITodoListStorage
    {
        private readonly string path;

        public FileTodoListStorage(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public void Save(TodoList content)
        {
            try
            {
                File.WriteAllText(path, string.Join("\n", content.Items));
            }
            catch (IOException ioEx)
            {
                throw new StorageException(ioEx.Message, ioEx);
            }
        }

        public TodoList Load()
        {
            if (!File.Exists(path))
            {
                return new TodoList();
            }

            try
            {
                string[] lines = File.ReadAllLines(path);
                return new TodoList(new List<string>(lines));
            }
            catch (IOException ioEx)
            {
                throw new StorageException(ioEx.Message, ioEx);
            }
        }
    }
}
