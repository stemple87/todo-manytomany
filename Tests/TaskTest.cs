using Xunit;
// using ToDoList.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ToDoList
{
  public class ToDoTest : IDisposable
  {
    public ToDoTest()
    {
      // DBConfiguration.ConnectionString = "Data Source=CHIYOKAWA\\SQLEXPRESS;Initial Catalog=todo_test;Integrated Security=SSPI;";
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=todo_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Task.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    {
      //Arrange, Act
      Task firstTask = new Task("Mow the lawn", 1);
      Task secondTask = new Task("Mow the lawn", 1);

      //Assert
      Assert.Equal(firstTask, secondTask);
    }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Task testTask = new Task("Mow the lawn", 1);

      //Act
      testTask.Save();
      Task savedTask = Task.GetAll()[0];

      int result = savedTask.GetId();
      int testId = testTask.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsTaskInDatabase()
    {
      //Arrange
      Task testTask = new Task("Mow the lawn", 1);
      testTask.Save();

      //Act
      Task foundTask = Task.Find(testTask.GetId());

      //Assert
      Assert.Equal(testTask, foundTask);
    }
    public void Dispose()
    {
      Task.DeleteAll();
    }
  }
}
