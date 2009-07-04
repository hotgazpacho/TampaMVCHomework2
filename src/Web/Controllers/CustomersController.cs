using System.Web.Mvc;
using Homework2.Models;
using MvcContrib.Pagination;
using System.Collections;

namespace Homework2.Controllers
{
    public class CustomersController : Controller
    {
        IRepository<Customer> _customerRepository;

        public CustomersController(IRepository<Customer> repository)
        {
            _customerRepository = repository;
        }

        // Need to inject this dependency rather than make it explicit...
        public CustomersController() : this(new CustomerActiveRecordRepository()) { }
        
        public ActionResult Index(int? page)
        {
            var customers = _customerRepository.FindAll();
            return View(customers.AsPagination(page ?? 1,2));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")]Customer customer)
        {
            if (!ModelState.IsValid)
                return View();

            _customerRepository.Insert(customer);

            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Details(long id)
        {
            var customer = _customerRepository.FindById(id);
            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            var customer = _customerRepository.FindById(id);
            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            _customerRepository.Update(customer);

            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Delete(long id)
        {
            var customer = _customerRepository.FindById(id);
            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(long id, FormCollection collection)
        {
            _customerRepository.DeleteById(id);         
            return RedirectToAction("Index");
        }
    }
}