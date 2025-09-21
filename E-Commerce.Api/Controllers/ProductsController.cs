using System.Security.Claims;
using E_Commerce.Api.Contracts;
using E_Commerce.Api.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductsController(IProductService product)
        {
            _product = product;
        }

        // GET: api/Products
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<object>> GetProducts([FromQuery] int pageNo
            , [FromQuery] int pageSize)
        {
            return Ok(await _product.GetProductsAsync(pageNo, pageSize));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GetProductDto>> GetProduct(Guid id)
        {
            var product = await _product.GetProductbyIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTask(int id, TaskItemDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await _task.UpdateTaskItem(userId, taskDto, id);

            if (!success)
                return NotFound();

            return NoContent();
            //if (id != task.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(task).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TaskExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> PostProduct(ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _product.AddProduct(product);

            return StatusCode(
                StatusCodes.Status201Created,
                new
                {
                    message = "Product successfully created"
                }
            );

            //_context.Tasks.Add(task);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _task.GetTaskItem(userId, id, true);

            if (task == null)
            {
                return NotFound();
            }

            await _task.DeleteTaskItem(userId, task, id);

            return NoContent();
        }

    }
}
