using System;
using Microsoft.Data.SqlClient;
using CommanLayer.Model;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessAccessLayer
{
    public class StudentBusiness
    {
        private StudentDataDb StudentsData;
        public StudentBusiness()
        {
            StudentsData = new StudentDataDb();

        }
        public List<Students> GetSutdents()
        {
            return StudentsData.GetStudents();
        }
        public Students GetStudentsById(int ID)
        {
            return StudentsData.GetStudentById(ID);
        }
        public bool DeleteStudents(int ID)
        {
            return StudentsData.DeleteStudents(ID);

        }
        public bool  CreateStudents(Students std)
        {
            return StudentsData.CreateStudents(std);
        }
        public bool UpdateStudents(Students std)
        {
            return StudentsData.UpdateStudents(std);
        }

        //public object UpdateEmployee(Students students)
        //{
        //    throw new NotImplementedException();
        //}
    } 
}
