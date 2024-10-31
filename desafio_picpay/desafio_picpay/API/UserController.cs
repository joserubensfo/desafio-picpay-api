using desafio_picpay.Factories.Entities;
using desafio_picpay.Factories.Repositories;
using desafio_picpay.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace desafio_picpay.API
{
    [ApiController]
    [Route("api/user")]
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IEntityFactory _entityFactory;
        private readonly IRepositoryFactory _repositoryFactory;

        public UserController(ILogger<UserController> logger, IEntityFactory entityFactory, IRepositoryFactory repositoryFactory)
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
                var user = _entityFactory.Create(typeof(User), json) as User;
                var repo = _repositoryFactory.GetRepository<User>();

                if (user is User objuser)
                {
                    var userErrors = user.Validate();
                    repo.Add(objuser);
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
