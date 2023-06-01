using Microsoft.AspNetCore.Mvc;
using Newman.EntityModels.Models;
using Newman.Helpers;
using Newman.Models;
using Newman.Services;

namespace Newman.Controllers
{
    [ApiController]
    [Route("api/stub")]
    public class StubController
    {
        private readonly IAppService _appService;
        public StubController(IAppService appService)
        {
           _appService = appService;
        }
        /// <summary>
        /// List people (id is nullable)
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IList<People>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 500)]
        public async Task<IList<People>> Get(int? id)
        {
            return await _appService.Get(id);
        }
        /// <summary>
        /// Create person
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(StatusCodes), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 500)]
        [ModelStateValidation]
        public async Task<ActionResult> Post(PeopleCreateModel model)
        {
            await _appService.Post(model);
            return new StatusCodeResult(statusCode: 200);
        }
        /// <summary>
        /// Update person
        /// </summary>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(typeof(StatusCodes), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 500)]
        [ModelStateValidation]
        public async Task<ActionResult> Put(PeopleUpdateModel model)
        {
            await _appService.Update(model);
            return new StatusCodeResult(statusCode: 200);
        }
        /// <summary>
        /// Delete person
        /// </summary>
        /// <returns></returns>
        [HttpDelete(template:"{id}")]
        [ProducesResponseType(typeof(StatusCodes), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 500)]
        [ModelStateValidation]
        public async Task<ActionResult> Delete(int id)
        {
            await _appService.Delete(id);
            return new StatusCodeResult(statusCode: 200);
        }
    }
}
