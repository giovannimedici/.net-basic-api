using ToDOApi.Models;

namespace ToDoApi.Repositories
{
    public class ToDoRepository
    {
        private readonly List<ToDoItem> _toDoItems = new();

        public List<ToDoItem> GetAll() => _toDoItems;

        public ToDoItem GetById(int id) => _toDoItems.FirstOrDefault(x => x.Id == id);

        public void Add(ToDoItem item) => _toDoItems.Add(item);

        public void Update(ToDoItem item)
        {
            int index = _toDoItems.FindIndex(x => x.Id == item.Id);
            if (index != -1)
            {
                _toDoItems[index] = item;
            }
        }

        public void Delete(int id) => _toDoItems.RemoveAll(x => x.Id == id);
    }
}