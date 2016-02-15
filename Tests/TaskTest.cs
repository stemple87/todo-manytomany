using Xunit;
using ToDoList.Objects;
using System;
using System.Collections.Generic;

namespace ToDoList
{
  public class TaskTest : IDisposable
  {

    [Fact]
    public void Test1_GetDescription_ReturnsDescription()
    {
      //Arrange
      string description01 = "Walk the dog.";
      Task newTask = new Task(description01);

      //Act
      string result = newTask.GetDescription();
      //Assert
      Assert.Equal(description01, result);
    }
    [Fact]
    public void Test2_GetAll_ReturnsTasks()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Task newTask1 = new Task(description01);
      Task newTask2 = new Task(description02);
      List<Task> newList = new List<Task> { newTask1, newTask2 };

      //Act
      List<Task> result = Task.GetAll();
      foreach (Task thisTask in result)
      {
        System.Console.WriteLine("Output: " + thisTask.GetDescription());
      }

      //Assert
      Assert.Equal(newList, result);
    }
    public void Dispose()
    {
      Task.ClearAll();
    }
  }
}