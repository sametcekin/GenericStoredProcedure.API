using GenericStoredProcedure.API.Library.Data.Interfaces;
using GenericStoredProcedure.API.Library.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GenericStoredProcedure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericStoredProcedureController : ControllerBase
    {
        private readonly IBaseStoredProcedure<dynamic> _genericStoredProcedure;

        public GenericStoredProcedureController(IBaseStoredProcedure<dynamic> genericStoredProcedure)
        {
            _genericStoredProcedure = genericStoredProcedure;
        }

        // POST api/<GenericStoredProcedure>
        [HttpPost]
        public async Task<object> GetStoredProcedureResult([FromBody] StoredProcedureModel storredProcedureModel)
        {
            var result = await _genericStoredProcedure.GetStoredProcedureResult(storredProcedureModel);
            return result;
        }

    }
}
