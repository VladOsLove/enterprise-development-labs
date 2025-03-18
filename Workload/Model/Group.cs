using System.ComponentModel.DataAnnotations;

namespace DepartmentWorkload.Domain.Model;

public class Group
{
    [Key]
    public required int Id { get; set; } // Идентификатор группы
    public required string GroupNumber { get; set; } // Номер группы
    public required int StudentCount { get; set; } // Количество студентов
}