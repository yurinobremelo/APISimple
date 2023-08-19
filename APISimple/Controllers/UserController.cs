using Application.Commands;
using Application.Queries;
using Application.Requests;
using Application.Responses;
using Application.Validators;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APISimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly IValidator<UserAddCommand> _userAddValidator;
        private readonly IValidator<UserModifyCommand> _userModifyValidator;
        public UserController(ILogger<UserController> logger,IMediator mediator, IValidator<UserAddCommand> userAddValidator, IValidator<UserModifyCommand> userModifyValidator)
        {
            _logger = logger;
            _mediator = mediator;
            _userAddValidator = userAddValidator;
            _userModifyValidator = userModifyValidator;

        }

    // GET: api/<UserController>
    [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userGetAllQuery = new UserGetAllQuery();
            var result = await _mediator.Send(userGetAllQuery);
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            UserGetByIdQuery userGetByIdQuery = new()
            {
                Id = id
            };
            var result = await _mediator.Send(userGetByIdQuery);
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(
            [FromForm] UserAddCommand command)
        {
            var validationResults = await _userAddValidator.ValidateAsync(command);

            if (!validationResults.IsValid) {
              
                return BadRequest(validationResults.Errors);
            }
            var result= await _mediator.Send(command);
            return Ok(result);
        }
       
        // PUT api/<ValuesController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put([FromBody] UserModifyCommand command)
        {
            var validationResults = await _userModifyValidator.ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<ValuesController>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            UserDeleteCommand command = new()
            {
                Id = id
            };

            await _mediator.Send(command);
            return NoContent();
        }
       
    }
}
