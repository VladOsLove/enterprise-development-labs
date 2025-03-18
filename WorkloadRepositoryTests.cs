using System.Collections.Generic;
using System.Threading.Tasks;
using DepartmentWorkload.Domain.Model;
using DepartmentWorkload.Domain.Services.InMemory;
using Xunit;

namespace DepartmentWorkload.Domain.Tests;

public class WorkloadRepositoryTests
{
    [Fact]
    public async Task GetWorkloadsByGroup_Success()
    {
        var repo = new WorkloadInMemoryRepository();
        var workloads = await repo.GetWorkloadsByGroup(1);

        Assert.NotNull(workloads);
        Assert.True(workloads.Count > 0);
    }

    [Fact]
    public async Task GetTotalHoursByActivityType_Success()
    {
        var repo = new WorkloadInMemoryRepository();
        var totalHours = await repo.GetTotalHoursByActivityType();

        Assert.NotNull(totalHours);
        Assert.True(totalHours.Count > 0);
    }

    [Fact]
    public async Task GetTeachersCountByPosition_Success()
    {
        var repo = new WorkloadInMemoryRepository();
        var counts = await repo.GetTeachersCountByPosition();

        Assert.NotNull(counts);
        Assert.True(counts.Count > 0);
    }

    [Fact]
    public async Task GetCoursesWithMultipleTeachers_Success()
    {
        var repo = new WorkloadInMemoryRepository();
        var courses = await repo.GetCoursesWithMultipleTeachers();

        Assert.NotNull(courses);
        Assert.True(courses.Count > 0);
    }
}