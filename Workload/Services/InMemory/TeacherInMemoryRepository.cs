using DepartmentWorkload.Domain.Model;
using DepartmentWorkload.Domain.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentWorkload.Domain.Services.InMemory;

public class TeacherInMemoryRepository : ITeacherRepository
{
    private readonly List<Teacher> _teachers;

    public TeacherInMemoryRepository()
    {
        _teachers = DataSeeder.Teachers;
    }

    public Task<IList<Teacher>> GetAll()
    {
        return Task.FromResult<IList<Teacher>>(_teachers);
    }

    public Task<Teacher?> GetById(int id)
    {
        var teacher = _teachers.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(teacher);
    }

    public Task<Teacher> Add(Teacher teacher)
    {
        _teachers.Add(teacher);
        return Task.FromResult(teacher);
    }

    public Task<Teacher> Update(Teacher teacher)
    {
        var existingTeacher = _teachers.FirstOrDefault(t => t.Id == teacher.Id);
        if (existingTeacher != null)
        {
            existingTeacher.FullName = teacher.FullName;
            existingTeacher.Position = teacher.Position;
        }
        return Task.FromResult(teacher);
    }

    public Task<bool> Delete(int id)
    {
        var teacher = _teachers.FirstOrDefault(t => t.Id == id);
        if (teacher != null)
        {
            _teachers.Remove(teacher);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<IList<Teacher>> GetTeachersByCourseAndActivityType(int courseId, string activityType)
    {
        var teachers = DataSeeder.Workloads
            .Where(w => w.CourseId == courseId && w.ActivityType == activityType)
            .Join(DataSeeder.Teachers,
                w => w.TeacherId,
                t => t.Id,
                (w, t) => t)
            .OrderBy(t => t.FullName)
            .ToList();
        return Task.FromResult<IList<Teacher>>(teachers);
    }

    public Task<IList<Teacher>> GetTeachersWithCourseProject()
    {
        var teachers = DataSeeder.Workloads
            .Where(w => w.ActivityType == "Курсовой проект")
            .Join(DataSeeder.Teachers,
                w => w.TeacherId,
                t => t.Id,
                (w, t) => t)
            .Distinct()
            .ToList();
        return Task.FromResult<IList<Teacher>>(teachers);
    }

    public Task<IList<Teacher>> GetTeachersWithMaxWorkload()
    {
        var maxHours = DataSeeder.Workloads
            .GroupBy(w => w.TeacherId)
            .Max(g => g.Sum(w => w.Hours));

        var teachers = DataSeeder.Workloads
            .GroupBy(w => w.TeacherId)
            .Where(g => g.Sum(w => w.Hours) == maxHours)
            .Join(DataSeeder.Teachers,
                g => g.Key,
                t => t.Id,
                (g, t) => t)
            .ToList();
        return Task.FromResult<IList<Teacher>>(teachers);
    }
}