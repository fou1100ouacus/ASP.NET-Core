using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AddSecurityJWT.Controllers
{

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
 [HttpGet]
    //[Authorize(Policy = Permission.Project.Read)] // Requires 'project:read' permission

       public IActionResult GetProjects()
        {
          return Ok(new
        {
            Message = "Read List of project",
            UserInfo = GetUserInfo(),
         //   Permission = Permission.Project.Read // Using constant for consistency
        });
        }

           [HttpGet("{id}")]
    //[Authorize(Policy = Permission.Project.Read)] // Requires 'project:read' permission
    public IActionResult GetProjectById(string id)
    {
        return Ok(new
        {
            Message = $"Read a single project with id = `{id}`",
            UserInfo = GetUserInfo(),
        //    Permission = Permission.Project.Read // Using constant for consistency
        });
    }


    [HttpPost]
  //  [Authorize(Policy = Permission.Project.Create)] // Requires 'project:create' permission
    public IActionResult CreateProject()
    {
        return CreatedAtAction(
            nameof(GetProjectById),
            new { id = Guid.NewGuid() },
            new
            {
                Message = "Project created successfully",
                UserInfo = GetUserInfo(),
//                Permission = Permission.Project.Create // Using constant for consistency
            });
    }

    [HttpPut("{id}")]
//    [Authorize(Policy = Permission.Project.Update)] // Requires 'project:update' permission
    public IActionResult UpdateProject(string id)
    {
        return Ok(new
        {
            Message = $"Project with Id = '{id}' was updated successfully",
            UserInfo = GetUserInfo(),
//            Permission = Permission.Project.Update // Using constant for consistency
        });
    }


    [HttpDelete("{id}")]
//    [Authorize(Policy = Permission.Project.Delete)] // Requires 'project:delete' permission
    public IActionResult DeleteProject(string id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok(new
        {
            Message = $"Project with Id = '{id}' was Deleted successfully",
            UserInfo = GetUserInfo(),
  //          Permission = Permission.Project.Delete // Using constant for consistency
        });
    }

















        private string GetUserInfo()
        {
            if (User.Identity is { IsAuthenticated: false })
                return "Anonymous"; // Corrected typo: Annonymous -> Anonymous

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var firstName = User.FindFirstValue(ClaimTypes.GivenName);
            var lastName = User.FindFirstValue(ClaimTypes.Surname);

            return $"[{userId}] {firstName} {lastName}";
        }

















    }
}