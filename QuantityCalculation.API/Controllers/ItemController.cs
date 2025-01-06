using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantityCalculation.API.Context;
using QuantityCalculation.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuantityCalculation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<ColorController>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Items.Include(i => i.Components).ToListAsync());


        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) => Ok(_context.Items.Where(i => i.Id == id).Include(i => i.Components));

        // POST api/<ColorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item value)
        {
            await _context.Items.AddAsync(value);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return Ok(new ApiResponse { Success = true, Message = "تم اضافة المنتج بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم اضافة المنتج" });
        }
        // PUT api/<ColorController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Item value)
        {
            _context.Items.Update(value);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم تعديل المنتج بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم تعديل المنتج" });
        }

        // DELETE api/<ColorController>/5
        [HttpDelete()]
        public async Task<IActionResult> Delete([FromBody] Guid value)
        {
            var item = _context.Items.Find(value);
            _context.Items.Remove(item);
            var result = await _context.SaveChangesAsync();
            if (result == 1)
                return Ok(new ApiResponse { Success = true, Message = "تم حدف المنتج بنجاح" });
            else
                return Ok(new ApiResponse { Success = false, Message = "لم يتم حذف المنتج" });
        }
    }
}
