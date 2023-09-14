using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using UnknownApp.Models;

namespace UnknownApp.Controllers
{
    public class AppController : Controller
    {
        private IConfiguration _configuration;

        public AppController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public async Task<ActionResult<IEnumerable<App>>> Index()
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            {
                
                var result = await con.QueryAsync<App>("SELECT * FROM APPS");
                return View(result);
            }
        }
       
       
    }
}
