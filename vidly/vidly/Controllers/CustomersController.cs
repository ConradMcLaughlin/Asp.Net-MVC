using System.Linq;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;
using System.Data.Entity;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            //Need to dispose the context.
            _context.Dispose();
            base.Dispose(disposing);
        }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomersViewModel()
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            };
            return View(viewModel);
        }


        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.ID == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);
                
            if (customer == null)
                return HttpNotFound();
                
            return View(customer);
        }

        

        #region "Old Code"
        /*
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { ID = 1, Name = "John Smith", DOB =  new DateTime(1983, 4, 11)},
                new Customer { ID = 2, Name = "Mary Williams",  DOB =  new DateTime(1985, 2, 22)},
                new Customer { ID = 3, Name = "James Brown",  DOB =  new DateTime(1965, 7, 19)}
            };
        }
        */
        #endregion

    }

}