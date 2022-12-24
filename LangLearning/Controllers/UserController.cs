using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LangLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [Route("api/[controller]/GetList")]
        [HttpGet]
        public async Task<ActionResult<List<Users>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }


        [Route("api/[controller]/AddUser")]
        [HttpPost]
        public async Task<ActionResult<List<Users>>> AddUsers(Users emp)
        {
            _context.Users.Add(emp);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }

        [Route("api/[controller]/UpdateEmployee")]
        [HttpPut]
        public async Task<ActionResult<List<Users>>> UpdateEmployee(Users reqEmp)
        {
            var dbEmp = await _context.Users.FindAsync(reqEmp.id);
            if (dbEmp == null)
                return BadRequest("Employee not found");

            dbEmp.username = reqEmp.username;
            dbEmp.email = reqEmp.email;
            dbEmp.phone = reqEmp.phone;
            dbEmp.password = reqEmp.password;
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }

        //[Route("api/[controller]/DeleteEmployee")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Users>>> Delete(int id)
        {
            var dbEmp = await _context.Users.FindAsync(id);
            if (dbEmp == null)
                return BadRequest("Employee not found");

            _context.Users.Remove(dbEmp);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
    }
}