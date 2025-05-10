    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TaskManagement.Application.Commands.CreateTask;
    using TaskManagement.Application.Commands.DeleteTask;
    using TaskManagement.Application.Commands.UpdateTask;
    using TaskManagement.Application.Queries.GetAllTasks;
    using TaskManagement.Application.Queries.GetTaskById;
    using TaskManagement.Domain;
    using TaskManagement.Domain;

namespace TaskManagement.Host.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class TaskController : ControllerBase
        {
            private readonly IMediator _mediator;

            public TaskController(IMediator mediator)
            {
                _mediator = mediator;
            }

            // ایجاد تسک جدید
            [HttpPost]
            public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
            {
                var taskId = await _mediator.Send(command);
                return Ok(taskId);

            }

            // دریافت تمام تسک‌ها
            [HttpGet]
            public async Task<IActionResult> GetTasks([FromQuery] TaskManagement.Domain.TaskStatus? status)
            {
                var query = new GetAllTasksQuery(status);
                var tasks = await _mediator.Send(query);
                return Ok(tasks);
            }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            // ارسال درخواست به MediatR
            var task = await _mediator.Send(new GetTaskByIdQuery(id));
            if (task == null)
            {
                return NotFound(); // در صورت عدم یافتن تسک، 404 باز می‌گردانیم
            }
            return Ok(task); // تسک پیدا شده را باز می‌گردانیم
        }
        // بروزرسانی تسک
        [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskCommand command)
            {
                if (id != command.Id)
                {
                    return BadRequest("ID mismatch");
                }

                await _mediator.Send(command);
                return NoContent();
            }

            // حذف تسک
            // حذف تسک
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTask(Guid id)
            {
                await _mediator.Send(new DeleteTaskCommand(id));
                return NoContent();
            }
        }
    }