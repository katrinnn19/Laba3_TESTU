using System.Collections.Generic;

namespace Fotius.Example.Todo
{
    /**
     * Represents a list of items.
     */
    public class TodoList
    {
        private readonly List<string> items;

        public TodoList()
        {
            this.items = new List<string>();
        }

        public TodoList(List<string> items)
        {
            this.items = new List<string>(items);
        }

        /**
         * Adds the given item to the list.
         */
        public void Add(string item)
        {
            items.Add(item);
        }

        /**
         * Returns items list. Note that returned list is an immutable copy of items.
         */
        public List<string> Items()
        {
            return new List<string>(items);
        }

        /**
         * Deletes all the items equal to the given one.
         * Returns true only if at least one item has been deleted.
         */
        public bool Delete(string item)
        {
            return items.RemoveAll(x => x.Equals(item)) > 0;
        }

        /**
         * Deletes the item at the specified index.
         * Returns the deleted item.
         */
        public string DeleteAt(int index)
        {
            string deletedItem = items[index];
            items.RemoveAt(index);
            return deletedItem;
        }
    }
}
