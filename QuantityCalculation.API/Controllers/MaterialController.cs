using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantityCalculation.API.Context;
using QuantityCalculation.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuantityCalculation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaterialController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<ColorController>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Materials.ToListAsync());


        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await _context.Materials.FindAsync(id));

        // POST api/<ColorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Material value)
        {
            await _context.Materials.AddAsync(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم اضافة الخامة بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم اضافة الخامة" });
        }
        // PUT api/<ColorController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Material value)
        {
            _context.Materials.Update(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم تعديل الخامة بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم تعديل الخامة" });
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Material value)
        {
            _context.Materials.Remove(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم حذف الخامة بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم حذف الخامة" });
        }
    }
}
