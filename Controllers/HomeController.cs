using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid){
            DateTime now = DateTime.Now;
            string sqlnow = now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string query = $"INSERT INTO UserQuote (name, quote, created_at, updated_at) VALUES ('{user.Name}', '{user.Quote}', '{sqlnow}', '{sqlnow}')";
            DbConnector.Execute(query);
            return RedirectToAction("result");
            }else{
                return View("Index");
            }

        }


        [HttpGet]
        [Route("result")]
        public IActionResult Result()
        {
            string query = "SELECT * FROM UserQuote order by id desc";
            var AllQuote = DbConnector.Query(query);
            ViewBag.AllQuote = AllQuote;
            return View("result");
        }
    }
}
