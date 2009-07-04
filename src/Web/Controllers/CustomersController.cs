using System.Web.Mvc;
using Homework2.Models;
using MvcContrib.Pagination;

namespace Homework2.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index(int? page)
        {
            return View(Customer.FetchAll().AsPagination(page ?? 1,2 ));
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

            customer.Save();

            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Details(long id)
        {
            var customer = Customer.FetchById(id);
            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            var customer = Customer.FetchById(id);
            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            customer.Save();

            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Delete(long id)
        {
            var customer = Customer.FetchById(id);
            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(long id, FormCollection collection)
        {
            Customer.DeleteById(id);            
            return RedirectToAction("Index");
        }
    }
}