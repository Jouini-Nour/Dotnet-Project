using Dotnet_Project.Models;
using Dotnet_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskRepository _projectTaskRepository;

        public ProjectTaskController(IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectTasks()
        {
            var projectTasks = await _projectTaskRepository.GetAllProjectTasksAsync();
            return Ok(projectTasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectTaskById(int id)
        {
            var projectTask = await _projectTaskRepository.GetProjectTaskByIdAsync(id);
            if (projectTask == null)
                return NotFound();

            return Ok(projectTask);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectTask([FromBody] ProjectTask projectTask)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProjectTask = await _projectTaskRepository.AddProjectTaskAsync(projectTask);
            return CreatedAtAction(nameof(GetProjectTaskById), new { id = createdProjectTask.TaskId }, createdProjectTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectTask(int id, [FromBody] ProjectTask projectTask)
        {
            if (id != projectTask.TaskId)
                return BadRequest("Task ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedProjectTask = await _projectTaskRepository.UpdateProjectTaskAsync(projectTask);
            return Ok(updatedProjectTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectTask(int id)
        {
            var result = await _projectTaskRepository.DeleteProjectTaskAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }

}
