using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantityCalculation.API.Context;
using QuantityCalculation.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuantityCalculation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<ColorController>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Colors.ToListAsync());


        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await _context.Colors.FindAsync(id));

        // POST api/<ColorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Colors value)
        {
            await _context.Colors.AddAsync(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم اضافة اللون بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم اضافة اللون" });
        }
        // PUT api/<ColorController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Colors value)
        {
            _context.Colors.Update(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم تعديل اللون بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم تعديل اللون" });
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Colors value)
        {
            _context.Colors.Remove(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم حذف اللون بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم حذف تعديل اللون" });
        }
    }
}
