using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantityCalculation.API.Context;
using QuantityCalculation.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuantityCalculation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MBController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MBController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<ColorController>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.MBs.ToListAsync());


        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await _context.MBs.FindAsync(id));

        // POST api/<ColorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MB value)
        {
            await _context.MBs.AddAsync(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم اضافة الMB بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم اضافه الMB" });
        }
        // PUT api/<ColorController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MB value)
        {
            _context.MBs.Update(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم تعديل الMB بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم تعديل الMB" });
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(MB value)
        {
            _context.MBs.Remove(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم حذف الMB بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم حذف الMB" });
        }
    }
}
