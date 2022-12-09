using ApiTodoList.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiToDoList.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Get([FromServices] AppDbContext context)
        {
            return Ok(context.Todos.ToList());
        }

        [HttpGet("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                return NotFound();

            return Ok(todo);

        }


        [HttpPost("/")]
        public IActionResult Post(
            [FromBody] Todo toDo,
            [FromServices] AppDbContext context)
        {
            context.Todos.Add(toDo);
            context.SaveChanges();
            return Created($"/{toDo.Id}", toDo);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] Todo toDo,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            model.Title = toDo.Title;
            model.Done = toDo.Done;

            context.Todos.Update(model);
            context.SaveChanges();
            return Ok(model);
        }


        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromBody] Todo toDo,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            model.Title = toDo.Title;
            model.Done = toDo.Done;

            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }

    }



}