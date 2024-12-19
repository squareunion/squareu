using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TaskFlowManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        // Static list to store projects temporarily
        private static List<Project> Projects = new List<Project>
        {
            new Project { Id = 1, Name = "Website Redesign", Status = "In Progress" },
            new Project { Id = 2, Name = "Mobile App Development", Status = "Not Started" }
        };

        // GET: api/project
        [HttpGet]
        public IActionResult GetProjects()
        {
            return Ok(Projects); // Return all projects as JSON
        }

        // POST: api/project
        [HttpPost]
        public IActionResult AddProject([FromBody] Project newProject)
        {
            newProject.Id = Projects.Count + 1; // Generate a new ID
            Projects.Add(newProject); // Add to the list
            return CreatedAtAction(nameof(GetProjects), new { id = newProject.Id }, newProject);
        }

        // PUT: api/project/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, [FromBody] Project updatedProject)
        {
            var project = Projects.FirstOrDefault(p => p.Id == id); // Find the project by ID
            if (project == null)
            {
                return NotFound(); // Return 404 if not found
            }

            project.Name = updatedProject.Name; // Update the name
            project.Status = updatedProject.Status; // Update the status
            return NoContent(); // Return 204 No Content
        }

        // DELETE: api/project/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = Projects.FirstOrDefault(p => p.Id == id); // Find the project by ID
            if (project == null)
            {
                return NotFound(); // Return 404 if not found
            }

            Projects.Remove(project); // Remove the project
            return NoContent(); // Return 204 No Content
        }
    }
}
