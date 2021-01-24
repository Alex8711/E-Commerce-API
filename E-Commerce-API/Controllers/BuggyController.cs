using E_Commerce_API.Database;
using E_Commerce_API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly AppDbContext _context;
        public BuggyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            
            var thing = _context.Products.Find(42);

            if (thing == null) 
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }
        
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }
        
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}