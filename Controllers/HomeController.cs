using ApiTodoList.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiToDoList.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/ola")]
        public List<Todo> Get([FromServices] AppDbContext context)
        {
            return context.Todos.ToList();
        }

        [HttpGet("/{id:int}")]
        public Todo GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            return context.Todos.FirstOrDefault(x => x.Id == id);
        }


        [HttpPost("/")]
        public List<Todo> Post(
            [FromBody] Todo toDo,
            [FromServices] AppDbContext context)
        {
            context.Todos.Add(toDo);
            context.SaveChanges();
            return context.Todos.ToList();
        }

        [HttpPut("/{id:int}")]
        public Todo Put(
            [FromRoute] int id,
            [FromBody] Todo toDo,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return toDo;

            model.Title = toDo.Title;
            model.Done = toDo.Done;

            context.Todos.Update(model);
            context.SaveChanges();
            return model;
        }


        [HttpDelete("/{id:int}")]
        public Todo Delete(
            [FromRoute] int id,
            [FromBody] Todo toDo,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            model.Title = toDo.Title;
            model.Done = toDo.Done;

            context.Todos.Remove(model);
            context.SaveChanges();
            return model;
        }

    }



}