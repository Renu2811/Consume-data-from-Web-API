using ConsumeEmployeeWebAPI.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeEmployeeWebAPI.WebAPI.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseuri = new Uri("https://localhost:7213/api");
        HttpClient client = new HttpClient();


        List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();


        public IActionResult Index()
        {
            client.BaseAddress = baseuri;
            HttpResponseMessage response = client.GetAsync(baseuri + "/employees").Result;
            if (response.IsSuccessStatusCode)
            {
                string EmployeeData = response.Content.ReadAsStringAsync().Result;
                employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(EmployeeData);
            }
            return View(employeeList);
        }

        public IActionResult CreateNewEmp()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult CreateNewEmp(EmployeeViewModel employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7213/api/employees");
                //HTTP POST

                var postTask = client.PostAsJsonAsync<EmployeeViewModel>("employees", employee);

                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)

                {

                    return RedirectToAction("Index");

                }

            }

                ModelState.AddModelError(string.Empty, "Server Error.");

                return View(employee);

            

        }

       
        

        public IActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7213/api");

                var delete = client.DeleteAsync(baseuri + $"/employees?Id={id}");


                //  var delete = client.DeleteAsync($"{id}");

                delete.Wait();

                var result = delete.Result;



                if (result.IsSuccessStatusCode)

                {

                    return RedirectToAction("Index");

                }

            }

            ModelState.AddModelError(string.Empty, "Server Error.");

            return View();



        }

        public IActionResult Edit(int id)
        {
            client.BaseAddress = baseuri;
            HttpResponseMessage response = client.GetAsync(baseuri + "/employees").Result;
            string orginalData = response.Content.ReadAsStringAsync().Result;
            employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(orginalData);
            var emp = employeeList.Where(e => e.id == id).FirstOrDefault();
            return View(emp);

        }

        [HttpPost]
        public IActionResult Save(EmployeeViewModel employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7213/api");
                var put = client.PutAsJsonAsync<EmployeeViewModel>(baseuri + $"/employees/{employee.id}", employee);
                put.Wait();
                var result = put.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "server error");
            }
            return View(employee);
        }


        public ActionResult Search(string searchString)
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            HttpResponseMessage response = client.GetAsync( baseuri + "/employees/" + searchString).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }
            return View("Index", employeeList);
        }
    }
}




