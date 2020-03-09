using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipHub.Repository
{
    public class StudentRepository: Repository<Student>,IStudentRepository
    {
        public Student GetStudent(string username)
        {
            return context.Set<Student>().SingleOrDefault(s => s.Username == username);
        }
        
 
    }
}