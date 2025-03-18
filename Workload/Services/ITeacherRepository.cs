using DepartmentWorkload.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepartmentWorkload.Domain.Services;

public interface ITeacherRepository
{
    Task<IList<Teacher>> GetAll();
    Task<Teacher?> GetById(int id);
    Task<Teacher> Add(Teacher teacher);
    Task<Teacher> Update(Teacher teacher);
    Task<bool> Delete(int id);
    Task<IList<Teacher>> GetTeachersByCourseAndActivityType(int courseId, string activityType);
    Task<IList<Teacher>> GetTeachersWithCourseProject();
    Task<IList<Teacher>> GetTeachersWithMaxWorkload();
}