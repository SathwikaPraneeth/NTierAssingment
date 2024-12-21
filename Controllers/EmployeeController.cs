using BussinessAccessLayer;
using DataAccessLayer;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace NTierAssingment.Controllers
{
    public class EmployeeController : Controller
    {
       EmployeeDbContext employeeDbContext;
        EmployeeBAL employeeBAL=new EmployeeBAL();

        public ActionResult Index()
        {
            return View(employeeBAL.GetEmployees().ToList());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(employeeBAL.GetEmployeeById(id));
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeBAL.AddEmployees(emp);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Employee emp = employeeBAL.GetEmployeeById(id);
                return View(emp);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                employeeBAL.EditEmployee(id, employee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = employeeBAL.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deleted(int id)
        {
            try
            {
                employeeBAL.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
