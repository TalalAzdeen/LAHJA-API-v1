using Api.Repositories;
using ASG.Api2.Results;
using AutoMapper;
using Dto;
using Dto.ModelAi;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace ASG.Api2.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //[OutputCache(PolicyName = "CustomPolicy", Tags = new[] { "Model Ai" })]
    public class ModelAiController(IModelAiRepository repository, IMapper mapper) : ControllerBase
    {
        [EndpointSummary("Get all Model Ai")]
        [HttpGet(Name = "GetModelsAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ModelAiResponse>>> GetAll()
        {
            var items = await repository.GetAllAsync();
            var result = mapper.Map<List<ModelAiResponse>>(items);
            //return Ok(new BaseResponseModel { Success = true, Data = data });
            return Ok(result);
        }

        [EndpointSummary("Get one")]
        [HttpGet("{id}", Name = "GetModelAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ModelAiResponse>> GetOne(string id)
        {
            var item = await repository.GetByAsync(m => m.Id == id);
            var result = mapper.Map<ModelAiResponse>(item);
            return Ok(result);
        }

        [EndpointSummary("Create a Model Ai")]
        [HttpPost("CreateModelAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModelAiResponse>> Create(ModelAiCreate model)
        {
            try
            {
                var item = mapper.Map<ModelAiCreate, ModelAi>(model);
                var result = await repository.CreateAsync(item);
                return CreatedAtAction(nameof(GetOne), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ProblemDetails { Type = ex.GetType().FullName, Title = ex.Message, Detail = ex.InnerException?.Message });
            }
        }

        [EndpointSummary("Update Model Ai")]
        [HttpPut("{id}", Name = "UpdateModelAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModelAiResponse>> Update(string id, ModelAiUpdate model)
        {
            try
            {
                var modelAi = await repository.GetByAsync(r => r.Id == id);
                if (modelAi == null)
                {
                    return NotFound(Result.NotFound("Item not found make sure that id is true"));
                }
                var item = mapper.Map<ModelAiUpdate, ModelAi>(model);
                item.Id = id;
                await repository.UpdateAsync(item);
                var result = mapper.Map<ModelAiResponse>(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Result.Problem(ex));
            }
        }

        [EndpointSummary("Delete Model Ai")]
        [HttpDelete("{id}", Name = "DeleteModelAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeletedResponse>> Delete(string id)
        {
            try
            {
                if (!await repository.Exists(p => p.Id == id))
                {
                    return NotFound($"Model Ai with id {id} not exists");
                }
                await repository.RemoveAsync(p => p.Id == id);
                return Ok(new DeletedResponse { Id = id, Deleted = true });
            }
            catch (Exception ex)
            {
                return BadRequest(Result.Problem(ex));
            }
        }
    }
}
