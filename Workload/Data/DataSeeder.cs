using DepartmentWorkload.Domain.Model;
using System.Text.RegularExpressions;

namespace DepartmentWorkload.Domain.Data;

public static class DataSeeder
{
    public static readonly List<Teacher> Teachers =
    [
        new() { Id = 1, FullName = "Иванов И.И.", Position = "Доцент" },
        new() { Id = 2, FullName = "Петров П.П.", Position = "Профессор" },
        new() { Id = 3, FullName = "Сидоров С.С.", Position = "Ассистент" },
        new() { Id = 4, FullName = "Андреев А.А.", Position = "Доцент" },
        new() { Id = 5, FullName = "Васильев В.В.", Position = "Профессор" },
        new() { Id = 6, FullName = "Дмитриев Д.Д.", Position = "Ассистент" },
        new() { Id = 7, FullName = "Егоров Е.Е.", Position = "Доцент" }
    ];

    public static readonly List<Course> Courses =
    [
        new() { Id = 1, Name = "Математика" },
        new() { Id = 2, Name = "Физика" },
        new() { Id = 3, Name = "Программирование" },
        new() { Id = 4, Name = "Химия" },
        new() { Id = 5, Name = "Биология" },
        new() { Id = 6, Name = "История" },
        new() { Id = 7, Name = "Литература" }
    ];

    public static readonly List<Group> Groups =
    [
        new() { Id = 1, GroupNumber = "101", StudentCount = 25 },
        new() { Id = 2, GroupNumber = "102", StudentCount = 30 },
        new() { Id = 3, GroupNumber = "103", StudentCount = 20 },
        new() { Id = 4, GroupNumber = "104", StudentCount = 35 },
        new() { Id = 5, GroupNumber = "105", StudentCount = 28 },
        new() { Id = 6, GroupNumber = "106", StudentCount = 22 },
        new() { Id = 7, GroupNumber = "107", StudentCount = 40 }
    ];

    public static readonly List<Workload> Workloads =
    [
        new() { Id = 1, TeacherId = 1, CourseId = 1, Semester = 1, GroupId = 1, ActivityType = "Лекции", StudyType = "Дневное", Hours = 30, Teacher = Teachers[0], Course = Courses[0], Group = Groups[0] },
        new() { Id = 2, TeacherId = 1, CourseId = 1, Semester = 1, GroupId = 1, ActivityType = "Практические", StudyType = "Дневное", Hours = 20, Teacher = Teachers[0], Course = Courses[0], Group = Groups[0] },
        new() { Id = 3, TeacherId = 2, CourseId = 2, Semester = 2, GroupId = 2, ActivityType = "Лекции", StudyType = "Вечернее", Hours = 40, Teacher = Teachers[1], Course = Courses[1], Group = Groups[1] },
        new() { Id = 4, TeacherId = 3, CourseId = 3, Semester = 1, GroupId = 1, ActivityType = "Курсовой проект", StudyType = "Дневное", Hours = 10, Teacher = Teachers[2], Course = Courses[2], Group = Groups[0] },
        new() { Id = 5, TeacherId = 4, CourseId = 4, Semester = 2, GroupId = 3, ActivityType = "Лекции", StudyType = "Дневное", Hours = 35, Teacher = Teachers[3], Course = Courses[3], Group = Groups[2] },
        new() { Id = 6, TeacherId = 5, CourseId = 5, Semester = 1, GroupId = 4, ActivityType = "Практические", StudyType = "Вечернее", Hours = 25, Teacher = Teachers[4], Course = Courses[4], Group = Groups[3] },
        new() { Id = 7, TeacherId = 6, CourseId = 6, Semester = 2, GroupId = 5, ActivityType = "Лекции", StudyType = "Дневное", Hours = 50, Teacher = Teachers[5], Course = Courses[5], Group = Groups[4] }
    ];
}