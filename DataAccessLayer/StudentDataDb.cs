using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using CommanLayer.Model;
using DataAccessLayer;


namespace DataAccessLayer
{
    public class StudentDataDb
    {
        private DbConnection db = new DbConnection();
        public List<Students> GetStudents()
        {
            string query = "select *from students";
            SqlCommand commnad = new SqlCommand();
            commnad.CommandText = query;
            commnad.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = commnad.ExecuteReader();
            List<Students> student = new List<Students>();
            while (reader.Read())
            {
                Students std = new Students();
                std.ID = (int)reader["ID"];
                std.name = reader["Name"].ToString();
                std.email = reader["email"].ToString();
                std.mobile = reader["mobile"].ToString();
                std.Gender = reader["gender"].ToString();
                std.Address = reader["Address"].ToString();
                student.Add(std);
            }
            db.Cnn.Close();
            return student;
        }

        public Students GetStudentById(int id)
        {
            string query = "Select * from students where ID= "+ id;
            SqlCommand commnad = new SqlCommand();
            commnad.CommandText = query;
            commnad.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = commnad.ExecuteReader();
           
            reader.Read();
            Students std = new Students();
            std.ID = (int)reader["ID"];
            std.name = reader["Name"].ToString();
            std.email = reader["email"].ToString();
            std.mobile = reader["mobile"].ToString();
            std.Gender = reader["gender"].ToString();
            std.Address = reader["Address"].ToString();
            
            db.Cnn.Close();
            return std;
        }
        public bool CreateStudents(Students students)
        {
            String query = "insert into Students values('"+students.name + "','" + students.email + "','"  +students.mobile+"','"

              + students.Gender + "','" + students.Address + "')";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);

        }
        public bool DeleteStudents(int id)
        {
            String query = "delete from Students where id=" + id + " ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = db.Cnn;
            
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);

        }
        public bool UpdateStudents(Students students)
        {
            string query = $"Update Students Set  name='{students.name}' ,Email='{students.email}', Gender= '{students.Gender}' Where ID='{students.ID}'";
            // String query = "update Students set  ID =" +students.ID + "," +"name="
            //+students.name + "," +"email="+students.email + "," +"mobile="+students.mobile+
            //          ","+"Gender=" + students.Gender+ ","+"Address=" + students.Address
            //        + "where ID=" +students.ID;
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }

    }
}
