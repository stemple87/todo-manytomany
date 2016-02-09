using Nancy;
using Todo.Objects;
using System.Collections.Generic;
using Todo.Objects;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["add_new_task.cshtml"];
      Get["/view_all_tasks"] = _ => {
        List<string> allTasks = Task.GetAll();
        return View["view_all_tasks.cshtml", allTasks];
      };
      Post["/tasks_cleared"] = _ => {
        Task.ClearAll();
        return View["tasks_cleared.cshtml"];
      };
      Post["/task_added"] = _ => {
        Task newTask = new Task (Request.Form["new-task"]);
        newTask.Save();
        return View["task_added.cshtml", newTask];
      };

    }
  }
}
