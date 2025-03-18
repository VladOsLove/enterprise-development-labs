using DepartmentWorkload.Domain.Model;
using DepartmentWorkload.Domain.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentWorkload.Domain.Services.InMemory;

public class WorkloadInMemoryRepository : IWorkloadRepository
{
    private readonly List<Workload> _workloads;

    public WorkloadInMemoryRepository()
    {
        _workloads = DataSeeder.Workloads;
    }

    public Task<IList<Workload>> GetAll()
    {
        return Task.FromResult<IList<Workload>>(_workloads);
    }

    public Task<IList<Workload>> GetWorkloadsByGroup(int groupId)
    {
        var workloads = _workloads
            .Where(w => w.GroupId == groupId)
            .ToList();
        return Task.FromResult<IList<Workload>>(workloads);
    }

    public Task<IList<(string ActivityType, int TotalHours)>> GetTotalHoursByActivityType()
    {
        var totalHours = _workloads
            .GroupBy(w => w.ActivityType)
            .Select(g => (ActivityType: g.Key, TotalHours: g.Sum(w => w.Hours)))
            .ToList();
        return Task.FromResult<IList<(string, int)>>(totalHours);
    }

    public Task<IList<(string Position, int Count)>> GetTeachersCountByPosition()
    {
        var counts = DataSeeder.Teachers
            .GroupBy(t => t.Position)
            .Select(g => (Position: g.Key, Count: g.Count()))
            .ToList();
        return Task.FromResult<IList<(string, int)>>(counts);
    }

    public Task<IList<(string CourseName, int TeacherCount)>> GetCoursesWithMultipleTeachers()
    {
        var courses = DataSeeder.Workloads
            .GroupBy(w => w.CourseId)
            .Where(g => g.Select(w => w.TeacherId).Distinct().Count() > 1)
            .Join(DataSeeder.Courses,
                g => g.Key,
                c => c.Id,
                (g, c) => (CourseName: c.Name, TeacherCount: g.Select(w => w.TeacherId).Distinct().Count()))
            .ToList();
        return Task.FromResult<IList<(string, int)>>(courses);
    }
}