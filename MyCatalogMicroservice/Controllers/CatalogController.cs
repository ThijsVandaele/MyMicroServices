using Microsoft.AspNetCore.Mvc;
using MyCatalogMicroservice.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyCatalogMicroservice.Model;

namespace MyCatalogMicroservice.Controllers
{
    
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _catalogContext;

        public CatalogController(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? 
                throw new ArgumentNullException(nameof(catalogContext));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items()
        {
            var model = await _catalogContext.catalogItems.ToListAsync();

            return Ok(model);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Item(int id)
        {
            var model = await _catalogContext.catalogItems.FirstOrDefaultAsync(x => x.Id == id);

            if(model == null)
            {
                return NotFound(id);
            }

            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateItem(CatalogItem item)
        {
            if(item == null)
            {
                return BadRequest(item);
            }

            _catalogContext.catalogItems.Add(item);
            await _catalogContext.SaveChangesAsync();

            return Created($"api/v1/[controller]/Item/{item.Id}", item);
        }
    }
}