using DepartmentWorkload.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepartmentWorkload.Domain.Services;

public interface IWorkloadRepository
{
    Task<IList<Workload>> GetAll();
    Task<IList<Workload>> GetWorkloadsByGroup(int groupId);
    Task<IList<(string ActivityType, int TotalHours)>> GetTotalHoursByActivityType();
    Task<IList<(string Position, int Count)>> GetTeachersCountByPosition();
    Task<IList<(string CourseName, int TeacherCount)>> GetCoursesWithMultipleTeachers();
}