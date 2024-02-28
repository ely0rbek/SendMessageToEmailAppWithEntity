using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Domain.Entites.AuthModels
{
    public enum Permission
    {
        CreateStudent = 1,
        DeleteStudent = 2,
        UpdateStudent = 3,
        GetStudentById = 4,
        GetAllStudents = 5,
        GetAllTeachers = 6,
        GetTeacherById = 7,
        CreateTeacher = 8,
        DeleteTeacher = 9,
        UpdateTeacher = 10
    }
}