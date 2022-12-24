using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LangLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly DataContext _context;
        public ExamController(DataContext context)
        {
            _context = context;
        }

        [Route("api/[controller]/GetList")]
        [HttpGet]
        public async Task<ActionResult<List<Questions>>> Get(int userIdParam, int examIdParam)
        {
            var queryDate = _context.Points.AsQueryable();
            var shortDateValue = DateTime.Now.ToShortDateString() +1;
            //var tomorrowShortDateValue = shortDateValue + 24.Hours();
            queryDate = queryDate.Where(entry => entry.userId == userIdParam && entry.examId == examIdParam).Select(t => new Point
            {
                currDate = t.currDate,
            }).OrderByDescending(entry => entry.currDate);
            var allDates = queryDate.ToList();
            if(allDates.Count!=0)
            {
                DateTime dtNow = DateTime.Now;
                if (dtNow <= allDates[0].currDate.AddDays(1))
                {
                    return null;
                }
            }

            var query = _context.Questions.AsQueryable();

            
            query = query.Where(entry => entry.examId ==examIdParam );//examId 1 yapınca çalışıyodu.
            
            return Ok( await query.ToListAsync());
        }
        [Route("api/[controller]/DoneExam")]
        [HttpPost]

        public async Task<ActionResult<List<Point>>> AddGrade(int userIdParam, int examIdParam,int gradeParam)
        {
            Point point = new Point();
            point.examId = examIdParam;
            point.grade = gradeParam;
            point.userId = userIdParam;
            _context.Points.Add(point);
            await _context.SaveChangesAsync();
            return Ok(await _context.Points.ToListAsync());
        }

    }    
}