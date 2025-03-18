using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DepartmentWorkload.Domain.Model;

public class Workload
{
    [Key]
    public required int Id { get; set; } // Идентификатор нагрузки
    public required int TeacherId { get; set; } // Идентификатор преподавателя
    public required int CourseId { get; set; } // Идентификатор дисциплины
    public required int Semester { get; set; } // Номер семестра
    public required int GroupId { get; set; } // Идентификатор группы
    public required string ActivityType { get; set; } // Вид занятий (лекции, практические и т.д.)
    public required string StudyType { get; set; } // Вид обучения (дневное, вечернее)
    public required int Hours { get; set; } // Объем часов

    // Навигационные свойства
    public Teacher? Teacher { get; set; }
    public Course? Course { get; set; }
    public Group? Group { get; set; }
}