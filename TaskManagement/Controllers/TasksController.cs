using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Command;
using TaskManagement.Application.Commands.CreateTask;
using TaskManagement.Application.Commands.DeleteTask;
using TaskManagement.Application.Commands.UpdateTask;
using TaskManagement.Application.Queries.GetAllTasks;
using TaskManagement.Application.Queries.GetTasksByUserId;
using TaskManagement.Application.Queries.GetTasksByUserId;
using TaskManagement.Domain;
using TaskManagement.Domain;

namespace TaskManagement.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ایجاد تسک جدید
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            var taskId = await _mediator.Send(command);
            return Ok(taskId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery] TaskManagement.Domain.TaskStatus? status)
        {

            var query = new GetAllTasksCommand();
            query.Status = status;
            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }


        [Authorize(Roles = "User")]
        [HttpGet("user")]
        public async Task<IActionResult> GetTasksByUserId()
        {
            var userId = Guid.Parse(User.FindFirst("UserId")?.Value);

            var tasks = await _mediator.Send(new GetTasksByUserIdCommand(userId));
            if (tasks == null || !tasks.Any())
            {
                return NotFound("No tasks found for this user.");
            }
            return Ok(tasks);
        }

        [HttpGet("status")]
        [Authorize]
        public async Task<IActionResult> GetTasksByStatus([FromQuery] TaskManagement.Domain.TaskStatus status)
        {
            var result = await _mediator.Send(new GetTasksByStatusCommand { Status = status });
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _mediator.Send(command);
            return Ok(command);
        }



        [HttpPut()]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUserTask([FromBody] UpdateUserTaskCommand command)
        {
            var userId = Guid.Parse(User.FindFirst("UserId")?.Value);

            var success = await _mediator.Send(new UpdateTaskCommand
            {
                Id = command.Id,
                Title = command.Title,
                Description = command.Description,
                Status = command.Status,
                AssignedUserId = userId
            });

            if (!success)
                return Forbid("You are not allowed to update this task.");

            return Ok("Task updated successfully.");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _mediator.Send(new DeleteTaskCommand(id));
            return Ok();
        }



    }
}