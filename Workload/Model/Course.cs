using System.ComponentModel.DataAnnotations;

namespace DepartmentWorkload.Domain.Model;

public class Course
{
    [Key]
    public required int Id { get; set; } // Идентификатор дисциплины
    public required string Name { get; set; } // Название дисциплины
}