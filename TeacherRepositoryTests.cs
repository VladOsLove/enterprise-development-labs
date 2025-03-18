using System.Collections.Generic;
using System.Threading.Tasks;
using DepartmentWorkload.Domain.Model;
using DepartmentWorkload.Domain.Services.InMemory;
using Xunit;

namespace DepartmentWorkload.Domain.Tests;

public class TeacherRepositoryTests
{
    [Fact]
    public async Task GetTeachersByCourseAndActivityType_Success()
    {
        var repo = new TeacherInMemoryRepository();
        var teachers = await repo.GetTeachersByCourseAndActivityType(1, "Лекции");

        Assert.NotNull(teachers);
        Assert.True(teachers.Count > 0);
    }

    [Fact]
    public async Task GetTeachersWithCourseProject_Success()
    {
        var repo = new TeacherInMemoryRepository();
        var teachers = await repo.GetTeachersWithCourseProject();

        Assert.NotNull(teachers);
        Assert.True(teachers.Count > 0);
    }

    [Fact]
    public async Task GetTeachersWithMaxWorkload_Success()
    {
        var repo = new TeacherInMemoryRepository();
        var teachers = await repo.GetTeachersWithMaxWorkload();

        Assert.NotNull(teachers);
        Assert.True(teachers.Count > 0);
    }
}