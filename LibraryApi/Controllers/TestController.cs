using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    public class TestController : ControllerBase
    {
        //Get /status 
        [HttpGet("/teststatus")]
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

    }
}

