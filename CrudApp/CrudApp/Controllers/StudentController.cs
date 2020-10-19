using CrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CrudApp.Controllers
{
    public class StudentController : Controller
    {
        
        public IActionResult Index()
        {

            List<Student> students = new List<Student>();
            students = (List<Student>)getAllStudent();
            return View("ViewStudent", students);
        }

        public IActionResult CreateStudent()
        {

            return View();

        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student.StudentID == 0)
            {
                string query = "Insert Into Studentinfo values('" + student.StudentName + "','" + student.Address + "','" + student.Phone + "','" + student.Email + "' )";
                SqlConnection conn = new SqlConnection(@"data source=DESKTOP-40RFCPG\MAMUNSQL; initial catalog=DotNetCoreCrudDB; integrated security=true;");
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    return RedirectToAction("Index");

                }

                return NotFound("Failed to save");

            }
            else
            {
                string query = "Update Studentinfo set StudentName='" + student.StudentName + "',Address='" + student.Address + "',Phone='" + student.Phone + "',Email='" + student.Email + "' where StudentID='" + student.StudentID + "'";
                SqlConnection conn = new SqlConnection(@"data source=DESKTOP-40RFCPG\MAMUNSQL; initial catalog=DotNetCoreCrudDB; integrated security=true;");
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                   
                    return RedirectToAction("Index");

                }

            }
            return NotFound();
        }

        public IEnumerable<Student> getAllStudent()
        {
            {
                List<Student> students = new List<Student>();
                string query = "select * from StudentInfo";
                SqlConnection conn = new SqlConnection(@"data source=DESKTOP-40RFCPG\MAMUNSQL; initial catalog=DotNetCoreCrudDB; integrated security=true;");
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Student student = new Student();
                    student.StudentID = (int)reader["StudentID"];
                    student.StudentName = reader["StudentName"].ToString();
                    student.Address = reader["Address"].ToString();
                    student.Phone = reader["Phone"].ToString();
                    student.Email = reader["Email"].ToString();

                    students.Add(student);



                }
                conn.Close();
                return students;

            }
        }

        public IActionResult Edit(int id)
        {
            string query = "select * from StudentInfo where StudentId='"+id+"'";
            SqlConnection conn = new SqlConnection(@"data source=DESKTOP-40RFCPG\MAMUNSQL; initial catalog=DotNetCoreCrudDB; integrated security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Student student = new Student();
                student.StudentID = (int)reader["StudentID"];
                student.StudentName = reader["StudentName"].ToString();
                student.Address = reader["Address"].ToString();
                student.Phone = reader["Phone"].ToString();
                student.Email = reader["Email"].ToString();

                return View("CreateStudent",student);



            }
            return NotFound();


        }

      

      


        

    }
    }

