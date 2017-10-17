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

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //Validation
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            
            if (customer.ID == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);
                customerInDb.Name = customer.Name;
                customerInDb.DOB = customer.DOB;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
                
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
        
    }

}