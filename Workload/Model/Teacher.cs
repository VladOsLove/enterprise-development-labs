using System.ComponentModel.DataAnnotations;

namespace DepartmentWorkload.Domain.Model;

public class Teacher
{
    [Key]
    public required int Id { get; set; } // Идентификатор преподавателя
    public required string FullName { get; set; } // ФИО преподавателя
    public required string Position { get; set; } // Должность (ассистент, доцент, профессор)
}