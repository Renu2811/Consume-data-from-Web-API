using Employee.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{


    [ApiController]
    [Route("api/employees")]

    public class EmployeeController : Controller
    {
        private readonly EmployeeData _employeeData;
        public EmployeeController(EmployeeData employeeData) => _employeeData = employeeData;

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            return Ok(_employeeData.employeesList);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}



        [HttpPost]

        public async Task<ActionResult<EmployeeViewModel>> Create(EmployeeViewModel employeeViewModel)
        {
            if (employeeViewModel == null)
            {
                return BadRequest();
            }
            _employeeData.employeesList.Add(employeeViewModel);
            return Ok(_employeeData.employeesList);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeViewModel employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object can't be null");
            }
            if (_employeeData.employeesList == null)
            {
                return NotFound("Table doesn't exists");
            }
            var employeeToUpdate = _employeeData.employeesList.Where(e => e.Id == id).FirstOrDefault();
            if (employeeToUpdate == null)
            {
                return NotFound("Employee with this empId doesn't exists");
            }
            _employeeData.employeesList.Remove(employeeToUpdate);
            employeeToUpdate.Id = employee.Id;
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.MobileNumber = employee.MobileNumber;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.AddressLine1 = employee.AddressLine1;
            employeeToUpdate.AddressLine2 = employee.AddressLine2;
            employeeToUpdate.PostalCode = employee.PostalCode;
            employeeToUpdate.City = employee.City;
            employeeToUpdate.Country = employee.Country;

            _employeeData.employeesList.Add(employeeToUpdate);
            return Ok(_employeeData.employeesList);
        }











        [HttpGet("{searchString}")]

        public async Task<IActionResult> Show(string searchString)
        {
            if (searchString == null)
            {
                return BadRequest("input can't be null");
            }
            if (_employeeData.employeesList == null)
            {
                return NotFound("Table doesn't exists");
            }
            var employee =  _employeeData.employeesList.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString) || e.City.Contains(searchString) || e.Country.Contains(searchString)).ToList();
            if (employee == null)
            {
                return NotFound("Record doesn't exists");
            }
            return Ok(employee);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            var employeeInDb = _employeeData.employeesList.FirstOrDefault(x => x.Id == Id);

            if (employeeInDb == null)
            {
                return NotFound();
            }

            _employeeData.employeesList.Remove(employeeInDb);
            //await _employeeData.SaveChangesAsync();
            return Ok(_employeeData.employeesList);
        }

       
    }
}
