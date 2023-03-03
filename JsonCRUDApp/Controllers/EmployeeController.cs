using JsonCRUDApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using JsonCRUDApp.Model.ViewModels;
using JsonCRUDApp.Exctensions;

namespace JsonCRUDApp.Controllers
{
    public class EmployeeController : Controller
    {
        string path =  @"./wwwroot/employee.json";
        // GET: EmployeeController

        public ActionResult Index()
        {
                    
            var employee = Exctensions.JSONCRUDExtensions.Read(path);
            return View(employee);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                    employee.Id = Guid.NewGuid().ToString();  
                    JSONCRUDExtensions.Create(path, employee);
                    return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(string id)
        {
           Employee employee= JSONCRUDExtensions.Get(path, id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                JSONCRUDExtensions.Edit(path, employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(string id)
        {
            Employee employee = JSONCRUDExtensions.Get(path, id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [Route("Employee/DeleteEmp/{id?}")]
        public ActionResult DeleteEmp(string Id)
        {
            try
            {
                JSONCRUDExtensions.Delete(path, Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
