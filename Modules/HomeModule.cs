using Nancy;
using System.Collections.Generic;
using ToDoList.Objects;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
          return View["index.cshtml"];
      };
      // Get["/categories"] = _ => {
      //   var allCategories = Category.GetAll();
      //   return View["categories.cshtml", allCategories];
      // };
      // Get["/categories/new"] = _ => {
      //   return View["category_form.cshtml"];
      // };
      // Post["/categories"] = _ => {
      //   var newCategory = new Category(Request.Form["category-name"]);
      //   var allCategories = Category.GetAll();
      //   return View["categories.cshtml", allCategories];
      // };
      // Get["/categories/{id}"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   var selectedCategory = Category.Find(parameters.id);
      //   var categoryTasks = selectedCategory.GetTasks();
      //   model.Add("category", selectedCategory);
      //   model.Add("tasks", categoryTasks);
      //   return View["category.cshtml", model];
      // };
      // Get["/clear_categories"] =_=> {
      //   Category.Clear();
      //   return View ["index.cshtml"];
      // };
      // //view a task
      // Get["/categories/{id}/task/{taskId}"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   Category selectedCategory = Category.Find(parameters.id);
      //   Task returnTask = Task.Find(parameters.taskId);
      //   model.Add("category", selectedCategory);
      //   model.Add("task", returnTask);
      //   return  View["task.cshtml",model];
      // };
      // //jill's delete task
      // Post["/deleteTask/{id}/task/{taskId}"]=parameters=>{
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   var selectedCategory = Category.Find(parameters.id);
      //   List<Task> allTasks = Task.GetAll();
      //   Task task = allTasks[parameters.taskId-1];
      //   task.ClearTask();
      //   // selectedCategory.RemoveTask(task);
      //   var categoryTasks = selectedCategory.GetTasks();
      //   model.Add("category", selectedCategory);
      //   model.Add("tasks", categoryTasks);
      //   return View["category.cshtml", model];
      // };
      // //deltet a task
      // Get["/delete/{id}/task/{taskId}"]=parameters=>{
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   Category selectedCategory = Category.Find(parameters.id);
      //   List<Task> allTasks = Task.GetAll();
      //   Task task = allTasks[parameters.taskId-1];
      //   selectedCategory.RemoveTask(task);
      //   model.Add("category", selectedCategory);
      //   model.Add("tasks", allTasks);
      //   return View["category.cshtml",model];
      // };
      // Get["/categories/{id}/tasks/new"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   Category selectedCategory = Category.Find(parameters.id);
      //   List<Task> allTasks = selectedCategory.GetTasks();
      //   model.Add("category", selectedCategory);
      //   model.Add("tasks", allTasks);
      //   return View["category_tasks_form.cshtml", model];
      // };
      // Post["/categories/{id}/task/{taskId}"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   var selectedCategory = Category.Find(parameters.id);
      //   var categoryTasks = selectedCategory.GetTasks();
      //   Task task = categoryTasks[parameters.taskId-1];
      //   task.SetDescription(Request.Form["edit"]);
      //   model.Add("category", selectedCategory);
      //   model.Add("tasks", categoryTasks);
      //   return View["category.cshtml", model];
      // };
      // Post["/tasks"] = _ => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   Category selectedCategory = Category.Find(Request.Form["category-id"]);
      //   List<Task> categoryTasks = selectedCategory.GetTasks();
      //   string taskDescription = Request.Form["task-description"];
      //   Task newTask = new Task(taskDescription);
      //   categoryTasks.Add(newTask);
      //   model.Add("tasks", categoryTasks);
      //   model.Add("category", selectedCategory);
      //   return View["category.cshtml", model];
      // };
    }
  }
}
