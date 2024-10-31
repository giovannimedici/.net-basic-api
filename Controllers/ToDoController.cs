using Microsoft.AspNetCore.Mvc;
using ToDoApi.Repositories;
using ToDOApi.Models;

namespace ToDOApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoRepository _repository = new();

        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAll() => _repository.GetAll();

        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetById(int id)
        {
            var item = _repository.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public ActionResult Create(ToDoItem item)
        {
            _repository.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ToDoItem item)
        {
            var existingItem = _repository.GetById(id);
            if (existingItem == null) return NotFound();

            item.Id = id;
            _repository.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingItem = _repository.GetById(id);
            if (existingItem == null) return NotFound();

            _repository.Delete(id);
            return NoContent();
        }
    }
}