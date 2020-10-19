using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {

        [HttpGet("getAllStudent")]
        public IActionResult getAllStudent()
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
                return Ok(students);

            }
        }


        [HttpPost("InsertStudent")]
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
                return Ok();

            }

            return NotFound("Insertion abroated");
        }

        [HttpPut("Edit")]
        public IActionResult EditStudent(Student student)
        {

                string query = "Update Studentinfo set StudentName='" + student.StudentName + "',Address='" + student.Address + "',Phone='" + student.Phone + "',Email='" + student.Email + "' where StudentID='" + student.StudentID + "'";
                SqlConnection conn = new SqlConnection(@"data source=DESKTOP-40RFCPG\MAMUNSQL; initial catalog=DotNetCoreCrudDB; integrated security=true;");
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            return Ok("Succesfull");
            


           
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteRecord(int id)
        {

            string query = "Delete From Studentinfo  where StudentID='" +id+ "'";
            SqlConnection conn = new SqlConnection(@"data source=DESKTOP-40RFCPG\MAMUNSQL; initial catalog=DotNetCoreCrudDB; integrated security=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            return Ok("Succesfull");




        }




    }
}
