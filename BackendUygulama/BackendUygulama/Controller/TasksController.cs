using BackendUygulama.DataAccess;
using BackendUygulama.Models;
using Microsoft.AspNetCore.Mvc;
using Task = BackendUygulama.Models.Task;

namespace BackendUygulama.Controller;

[ApiController]
[Route("api/[controller]")]
public class TasksController:ControllerBase
{
    TaskDAO taskDAO;

    public TasksController(TaskDAO taskDAO)
    {
        this.taskDAO = taskDAO;
    }
    [HttpGet]
    public ActionResult<Response<List<Task>>> GetTasks()
    {
        try
        {
            List<Task> result = taskDAO.GetTasks();
            return Ok(Response<List<Task>>.Success(result));
        }
        catch (Exception e)
        {
            return BadRequest(Response<List<Task>>.Fail(e.Message));
        }
    }

    [HttpPost]
    
    public ActionResult<Response<Task>> CreateTask(Task task)
    {
        try
        {
            var result = taskDAO.Add(task);
            return Ok(Response<Task>.Success(result));
        }
        catch (Exception e)
        {
            return BadRequest(Response<Task>.Fail(e.Message));
        }
    }
    [HttpPut("{id}")]
    public ActionResult<Response<Task>> UpdateTask(int id,Task task)
    {
        try
        {
            var result = taskDAO.Update(id,task);
            if(result==null)
                return BadRequest(Response<Task>.Fail("Task not found"));
            return Ok(Response<Task>.Success(result));
        }
        catch (Exception e)
        {
            return BadRequest(Response<Task>.Fail(e.Message));
        }
    }
    [HttpDelete("{id}")]
    public ActionResult<Response<Task>> DeleteTask(int id)
    {
        try
        {
            var result = taskDAO.Remove(id);
            if(result==null)
                return BadRequest(Response<Task>.Fail("Task not found"));

            return Ok(Response<Task>.Success(result));
        }
        catch (Exception e)
        {
            return BadRequest(Response<Task>.Fail(e.Message));
        }
    }
}