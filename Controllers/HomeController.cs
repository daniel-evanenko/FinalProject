using AngularRegistarion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace AngularRegistarion.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        // gets the user input from scope and srotes the data into Dictionary and uses a function to insert the user data to the db.
        public IActionResult RegisterUser(account acc)
        {
            using (DbConnection conn1 = new DbConnection())
            {
                conn1.open_connection();
                conn1.begin_transaction();
                Dictionary<string, object> prms = new Dictionary<string, object>();
                prms["@username"] = acc.Name;// username;
                prms["@password"] = acc.Password;//user_pass;
                conn1.execute_query("insert into users(username,password) values(@username, @password)", prms, conn1.transaction_conn);
                conn1.commit_transaction();
                //return View("Privacy");
                return Content("2342342");
            }
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult time_span1()
        {
            long ticks1 = DateTime.Now.Ticks;

            while (ticks1< (DateTime.Now.Ticks-10*1000000))
            {
                int d1 = 1;
            }

            return Content("");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Signin()
        {
            return View();
        }
        public IActionResult nextSignUp()
        {
            return View();
        }
        public IActionResult PetDetails()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}