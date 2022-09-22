using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Tests;

public class StudentTests
{
    [Fact]
    public void Student_creation_test()
    {
        //Arrange
        Student newStudent = new Student();
        newStudent.StartDate = DateTime.Now;
        newStudent.GraduationDate = DateTime.Now + TimeSpan.FromDays(365 * 2);

        Student activeStudent = new Student();
        activeStudent.StartDate = DateTime.Now - TimeSpan.FromDays(1);
        activeStudent.GraduationDate = DateTime.Now + TimeSpan.FromDays(365 * 2);

        Student dropout = new Student();
        dropout.StartDate = DateTime.Now - TimeSpan.FromDays(1);
        dropout.EndDate = DateTime.Now;
        dropout.GraduationDate = DateTime.Now + TimeSpan.FromDays(365 * 2);


        Student graduated = new Student();
        graduated.StartDate = DateTime.Now - TimeSpan.FromDays(1);
        graduated.EndDate = DateTime.Now;
        graduated.GraduationDate = DateTime.Now;


        //Act
        var newStudentStatus = newStudent.Status;
        var activeStudentStatus = activeStudent.Status;
        var dropoutStatus = dropout.Status;
        var graduatedStadus = graduated.Status;

        //Assert
        Assert.Equal(Status.New, newStudentStatus);
        Assert.Equal(Status.Active, activeStudentStatus);
        Assert.Equal(Status.Dropout, dropoutStatus);
        Assert.Equal(Status.Graduated, graduatedStadus);
    }

    [Fact]
    public void ImmutableTest_status()
    {
        Assert.Equal(Status.New, new ImmutableStudent(1, "Bob", "The Builder", DateTime.Now, new DateTime(), DateTime.Now + TimeSpan.FromDays(365)).Status);
        Assert.Equal(Status.Active, new ImmutableStudent(2, "Bob", "The Learner", DateTime.Now - TimeSpan.FromDays(1), new DateTime(), DateTime.Now + TimeSpan.FromDays(365)).Status);
        Assert.Equal(Status.Dropout, new ImmutableStudent(3, "Bob", "The Dropout", DateTime.Now - TimeSpan.FromDays(1), DateTime.Now, DateTime.Now + TimeSpan.FromDays(365)).Status);
        Assert.Equal(Status.Graduated, new ImmutableStudent(4, "Bob", "The Graduator", DateTime.Now - TimeSpan.FromDays(1), DateTime.Now, DateTime.Now).Status);
    }

    [Fact]
    public void Immutable_equality_test_equal()
    {
        var student1 = new ImmutableStudent(1, "Bob", "The Builder", DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
        var student2 = new ImmutableStudent(1, "Bob", "The Builder", DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);

        Assert.Equal(student1, student2);
    }

    [Fact]
    public void Immutable_equality_test_not_equal()
    {
        var student1 = new ImmutableStudent(1, "Bob", "The Builder", DateTime.Now, new DateTime(), DateTime.Now + TimeSpan.FromDays(365));
        var student2 = new ImmutableStudent(2, "Frederick", "The Impostor", DateTime.Now, new DateTime(), DateTime.Now + TimeSpan.FromDays(365));

        Assert.NotEqual(student1, student2);
    }
}

