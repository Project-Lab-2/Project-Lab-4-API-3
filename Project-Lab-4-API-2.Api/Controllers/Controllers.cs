using Microsoft.AspNetCore.Mvc;
using Project.Lab4.API2.Domain.Catalog;

namespace Project.Lab4.API2.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = new List<Item>()
            {
                new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
            };

            return Ok(items);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m)
            {
                Id = id
            };

            return Ok(item);
        }
        [HttpPost]
        public IActionResult Post(Item item)
        {
            return Created("/catalog/42", item);
        }
        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m)
            {
                Id = id
            };

            item.AddRating(rating);

            return Ok(item);
        }
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            return NoContent();
        }
    }

    public class Rating
    {
    }

    public class Item
    {
        private string v1;
        private string v2;
        private string v3;
        private decimal v4;

        public Item(string v1, string v2, string v3, decimal v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public int Id { get; set; }

        internal void AddRating(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
