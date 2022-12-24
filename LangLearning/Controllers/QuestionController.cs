using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LangLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly DataContext _context;
        public QuestionController(DataContext context)
        {
            _context = context;
        }

        [Route("api/[controller]/GetList")]
        [HttpGet]
        public async Task<ActionResult<List<Questions>>> Get()
        {
            return Ok(await _context.Questions.ToListAsync());
        }


        [Route("api/[controller]/AddQuestions")]
        [HttpPost]
        public async Task<ActionResult<List<Questions>>> AddQuestions(Questions emp)
        {
            _context.Questions.Add(emp);
            await _context.SaveChangesAsync();
            return Ok(await _context.Questions.ToListAsync());
        }

        //[Route("api/[controller]/DeleteEmployee")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Questions>>> Delete(int id)
        {
            var dbEmp = await _context.Questions.FindAsync(id);
            if (dbEmp == null)
                return BadRequest("Questions not found");

            _context.Questions.Remove(dbEmp);
            await _context.SaveChangesAsync();

            return Ok(await _context.Questions.ToListAsync());
        }
    }
}