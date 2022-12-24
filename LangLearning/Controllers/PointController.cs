using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LangLearning.Controllers
{
    [Route("api/[controller]/grade")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly DataContext _context;
        public PointController(DataContext context)
        {
            _context = context;
        }

        [Route("api/[controller]/grade/AddPoint")]
        [HttpPost]
        public async Task<ActionResult<List<Point>>> AddPoint(int examId, int userId, int grade)
        {
            Point point = new Point();
            point.examId = examId;
            point.grade = grade;
            point.userId = userId; 
            _context.Points.Add(point);
            await _context.SaveChangesAsync();
            return Ok( await _context.Points.ToListAsync());

        }


    }
}
