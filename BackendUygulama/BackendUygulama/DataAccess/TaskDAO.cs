using BackendUygulama.Models;
using Task = BackendUygulama.Models.Task;

namespace BackendUygulama.DataAccess;

public class TaskDAO
{
    private ScrumboarddbContext context;

    public TaskDAO(ScrumboarddbContext context)
    {
        this.context = context;
    }

    public List<Task> GetTasks()
    {
        return context.Tasks.ToList();
    }

    public Task Add(Task task)
    {
        var result = context.Tasks.Add(task).Entity;
        context.SaveChanges();
        return result;
    }

    public Task? Update(int id, Task task)
    {
        var result = context.Tasks.FirstOrDefault();
        if (result != null)
        {
            result.Id = task.Id;
            result.Title = task.Title;
            result.Content = task.Content;
            result.Deadline = task.Deadline;
            result.Owner = task.Owner;
            //SMTH
            context.Tasks.Update(result);
            context.SaveChanges();
        }
        return result;
    }

    public Task? Remove(int id)
    {
        var result = context.Tasks.FirstOrDefault(x => x.Id == id);
        if (result != null)
        {
            context.Tasks.Remove(result);
            context.SaveChanges();
        }

        return result;
    }
}