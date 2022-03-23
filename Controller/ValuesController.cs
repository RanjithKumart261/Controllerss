using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Models;
using System;
using Solution.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;


namespace Solution.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly ILogger<ValuesController> _logger;
        private readonly UserRepository repository;
        //private readonly EmployeeRepository employeeRepository;

        public ValuesController()
        {
            repository = new UserRepository("User Id=postgres;Password=TRIVENI@1;Host=localhost;Database=Solution1");
            //employeeRepository = new EmployeeRepository("User Id=postgres;Password=TRIVENI@1;Host=localhost;Database=Solution");
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var result = repository.GetAll();
            return Ok(result.Select(x => new User
            {
                Email = x.Email,
                Id = x.Id,
                IsUpdated   = x.IsUpdated,
                Password = x.Password
            }));
        }

   
        [HttpPut]
      
        public ActionResult<User> Put(User user)
        {
            repository.Update(user);
            return user;
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            repository.Create(user);
            return user;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok();
        }


    }
}
