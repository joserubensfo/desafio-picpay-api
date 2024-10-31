using desafio_picpay.Factories.Entities;
using desafio_picpay.Factories.Repositories;
using desafio_picpay.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace desafio_picpay.API
{
    [ApiController]
    [Route("api/shopkeeper")]
    public class ShopkeeperController
    {
        private readonly ILogger<ShopkeeperController> _logger;
        private readonly IEntityFactory _entityFactory;
        private readonly IRepositoryFactory _repositoryFactory;

        public ShopkeeperController(ILogger<ShopkeeperController> logger, IEntityFactory entityFactory, IRepositoryFactory repositoryFactory)
        {
            _logger = logger;
            _entityFactory = entityFactory;
            _repositoryFactory = repositoryFactory;
        }

        [HttpPost("create")]
        public IResult Create([FromBody] JsonElement json)
        {
            try
            {
                var shopkeeper = _entityFactory.Create(typeof(Shopkeeper), json) as Shopkeeper;
                var repo = _repositoryFactory.GetRepository<Shopkeeper>();

                if (shopkeeper is Shopkeeper objshopkeeper)
                {
                    var userErrors = shopkeeper.Validate();
                    repo.Add(objshopkeeper);
                }

                return Results.Ok("success!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return Results.Problem($"Error: {ex.Message}");
            }
        }
    }
}
