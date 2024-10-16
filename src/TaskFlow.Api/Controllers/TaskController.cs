﻿using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.UseCases.Tasks.CreateTask;
using TaskFlow.Application.UseCases.Tasks.DeleteTask;
using TaskFlow.Application.UseCases.Tasks.GetTask;
using TaskFlow.Application.UseCases.Tasks.ListMyTasks;
using TaskFlow.Application.UseCases.Tasks.UpdateTask;
using TaskFlow.Comunication.Requests;
using TaskFlow.Comunication.Responses;

namespace TaskFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseListMyTasksJson), StatusCodes.Status200OK)]
        public IActionResult ListTasks(
            [FromServices] IListMyTasksUseCase listMyTasksUseCase
        )
        {
            var tasks = listMyTasksUseCase.Execute();
            return Ok(tasks);
        }

        [HttpGet("by-task-id/{taskId}")]
        [ProducesResponseType(typeof(ResponseMyTaskJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult GetMyTaskById(
            [FromServices] IGetMyTaskByIdUseCase getMyTaskByIdUseCase,
            int taskId
        )
        {
            var myTask = getMyTaskByIdUseCase.Execute(new RequestMyTaskByIdJson { TaskId = taskId });
            return Ok(myTask);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateTaskJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult CreateTask(
            [FromServices] ICreateTaskUseCase createTaskUseCase,
            [FromBody] RequestCreateTaskJson requestCreateTaskJson

         )
        {
            var myTask = createTaskUseCase.Execute(requestCreateTaskJson);
            return Created(string.Empty, myTask);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateTask(
            [FromServices] IUpdateTaskUseCase updateTaskUseCase,
            [FromBody] RequestUpdateTaskJson requestUpdateTaskJson
        )
        {
            updateTaskUseCase.Execute(requestUpdateTaskJson);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteTask(
            [FromServices] IDeleteTaskUseCase deleteTaskUseCase,
            [FromBody] RequestDeleteTaskJson requestDeleteTaskJson
        )
        {
            deleteTaskUseCase.Execute(requestDeleteTaskJson);
            return NoContent();
        }
    }
}
