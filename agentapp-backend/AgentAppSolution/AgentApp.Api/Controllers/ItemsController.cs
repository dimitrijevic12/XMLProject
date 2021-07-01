using AgentApp.Api.Factories;
using AgentApp.Core.Interface.Repository;
using AgentApp.Core.Model;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemFactory itemFactory;
        private readonly IItemRepository _itemRepository;

        public ItemsController(ItemFactory itemFactory, IItemRepository itemRepository)
        {
            this.itemFactory = itemFactory;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(itemFactory.CreateItems(_itemRepository.GetAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GeyById(Guid id)
        {
            Maybe<Item> item = _itemRepository.GetById(id);
            if (item.HasNoValue) return BadRequest();
            return Ok(itemFactory.Create(item.Value));
        }

        [HttpPost]
        public IActionResult Create(DTOs.Item item)
        {
            Guid id = Guid.NewGuid();
            Result<Name> name = Name.Create(item.Name);
            Result<ItemImagePath> itemImagePath = ItemImagePath.Create(item.ItemImagePath);
            Result<Price> price = Price.Create(item.Price);
            Result<AvailableCount> availableCount = AvailableCount.Create(item.AvailableCount);

            Result result = Result.Combine(name, itemImagePath, price, availableCount);
            if (result.IsFailure) return BadRequest();

            if (_itemRepository.Save(Item.Create(id, name.Value, itemImagePath.Value,
                price.Value, availableCount.Value).Value) == null)
                return BadRequest("Couldn't create item");

            return Created(this.Request.Path + id, "");
        }

        [HttpPut]
        public IActionResult Edit(DTOs.Item item)
        {
            Result<Name> name = Name.Create(item.Name);
            Result<ItemImagePath> itemImagePath = ItemImagePath.Create(item.ItemImagePath);
            Result<Price> price = Price.Create(item.Price);
            Result<AvailableCount> availableCount = AvailableCount.Create(item.AvailableCount);

            Result result = Result.Combine(name, itemImagePath, price, availableCount);
            if (result.IsFailure) return BadRequest();

            if (_itemRepository.Edit(Item.Create(item.Id, name.Value, itemImagePath.Value,
                price.Value, availableCount.Value).Value) == null)
                return BadRequest("Couldn't edit item");

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(DTOs.Item item)
        {
            _itemRepository.Delete(item.Id);

            return NoContent();
        }
    }
}