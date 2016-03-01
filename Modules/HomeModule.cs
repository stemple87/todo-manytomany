using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/tasks"] = _ => {
        List<Task> AllTasks = Task.GetAll();
        return View["tasks.cshtml", AllTasks];
      };
      Get["/categories"] = _ => {
        List<Category> AllCategories = Category.GetAll();
        return View["categories.cshtml", AllCategories];
      };

      //Create a new task
      Get["/tasks/new"] = _ => {
        return View["tasks_form.cshtml"];
      };
      Post["/tasks/new"] = _ => {
        DateTime newDateTime = Convert.ToDateTime((string)Request.Form["task-date"]);
        Task newTask = new Task(Request.Form["task-description"],newDateTime);
        newTask.Save();
        return View["success.cshtml"];
      };

      //Create a new category
      Get["/categories/new"] = _ => {
        return View["categories_form.cshtml"];
      };
      Post["/categories/new"] = _ => {
        Category newCategory = new Category(Request.Form["category-name"]);
        newCategory.Save();
        return View["success.cshtml"];
      };

      Get["/categories/delete/{id}"] = parameters => {
        Category newCategory = Category.Find(parameters.id);
        newCategory.Delete();
        List<Category> AllCategories = Category.GetAll();
        return View["categories.cshtml",AllCategories];
      };
      //Creates individual pages for category and task
      Get["tasks/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Task SelectedTask = Task.Find(parameters.id);
        List<Category> TaskCategories = SelectedTask.GetCategories();
        List<Category> AllCategories = Category.GetAll();
        model.Add("task", SelectedTask);
        model.Add("taskCategories", TaskCategories);
        model.Add("allCategories", AllCategories);
        return View["task.cshtml", model];
      };

      Post["tasks/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        DateTime newDateTime = Convert.ToDateTime((string)Request.Form["duedate"]);
        Task SelectedTask = Task.Find(parameters.id);
        SelectedTask.Update(Request.Form["description"],(bool)Request.Form["task-done"], newDateTime);
        List<Category> TaskCategories = SelectedTask.GetCategories();
        List<Category> AllCategories = Category.GetAll();
        model.Add("task", SelectedTask);
        model.Add("taskCategories", TaskCategories);
        model.Add("allCategories", AllCategories);
        return View["task.cshtml", model];
      };

      Get["/tasks/delete/{id}"] = parameters => {
        Task newTask = Task.Find(parameters.id);
        newTask.Delete();
        List<Task> AllTasks = Task.GetAll();
        return View["tasks.cshtml", AllTasks];
      };

      Get["categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category SelectedCategory = Category.Find(parameters.id);
        List<Task> CategoryTasks = SelectedCategory.GetTasks();
        List<Task> AllTasks = Task.GetAll();
        model.Add("category", SelectedCategory);
        model.Add("categoryTasks", CategoryTasks);
        model.Add("allTasks", AllTasks);
        return View["category.cshtml", model];
      };



      //Post routes for forms
      Post["task/add_category"] = _ => {
        Category category = Category.Find(Request.Form["category-id"]);
        Task task = Task.Find(Request.Form["task-id"]);
        task.AddCategory(category);
        bool retBool = (bool)Request.Form["task-done"];
        task.SetCompleted(retBool);
        return View["success.cshtml"];
      };
      Post["category/add_task"] = _ => {
        Category category = Category.Find(Request.Form["category-id"]);
        Task task = Task.Find(Request.Form["task-id"]);
        category.AddTask(task);
        return View["success.cshtml"];
      };


    }
  }
}
