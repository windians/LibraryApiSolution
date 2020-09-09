using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class StatusController : ControllerBase
    {
        //Get employees/32
        [HttpGet("employees/{employeeId:int}")]
        public ActionResult GetAnEmployee(int employeeId)
        {
            // return Ok($"Employee {employeeId} is here!");
            var response = new EmployeeResponse
            {
                Id = 32,
                Name = "Akshay",
                Department = "IT",
                StartingSalary = 250000,
                HireDate = Convert.ToDateTime("10/15/2019")

            };
            return Ok(response);
        }

        public ActionResult Hire([FromBody] EmployeeCreateRequest employeeToHire)
        {
            var employeeRespnse = new EmployeeResponse

            {

                Id = new Random().Next(10, 10000),

                Name = employeeToHire.Name,

                Department = employeeToHire.Department,

                HireDate = DateTime.Now,

                StartingSalary = employeeToHire.StartingSalary

            };

        }
        //Get /status 
        //path param
        [HttpGet("/status")]
        public ActionResult GetStatus()
        {
            var status = new StatusResponse
            {
                Message = "Looks good",
                CheckedBy = "Akshay",
                WhenChecked = DateTime.Now
            };
            return Ok(status);
        }

        //Get /employees 
        //user query string
        [HttpGet("/employees")]
        public ActionResult GetAllEmployees([FromQuery] string department)
        {
            return Ok($"all the employees (filtered on {department})");
        }

        [HttpGet("whoami")]
        public ActionResult WhoAmi([FromHeader(Name = "User-Agent")] string userAge)
        {
            return Ok($"I see you are running {userAge}");
        }

       


    }

    public class StatusResponse
    {
        public string Message { get; set; }
        public string CheckedBy { get; set; }
        public DateTime WhenChecked { get; set; }
    }

    public class EmployeeCreateRequest
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal StartingSalary { get; set; }
    }
    public class EmployeeResponse {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal StartingSalary { get; set; }
        public DateTime HireDate { get; set; }
    }

}
