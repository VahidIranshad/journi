using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Headphones.Application.Dtos.HeadphonesDtos;
using MediatR;
using Headphones.Application.Features.Headphones.Queries.GetList;
using Headphones.Application.Features.Headphones.Queries.GetByID;
using System.Collections.Generic;
using Headphones.Application.Features.Headphones.Commands.Create;
using Headphones.Application.Features.Headphones.Commands.Update;
using Headphones.Application.Features.Headphones.Commands.Delete;
using System.Net.Mime;

namespace headphones_market.core.Api.Endpoints;

[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces("application/json")]
[ApiController]
public class HeadphonesController : ControllerBase
{
    private readonly IMediator _mediator;
    public HeadphonesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await _mediator.Send(new GetHedphoneListQuery());
        return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var item = await _mediator.Send(new GetHeadphoneById() { Id = id});

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] HeadphoneCrudDto crudDto)
    {
        var command = new CreateHeadphoneCommand { headphonesCrudDto = crudDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] HeadphoneCrudDto crudDto)
    {
        var command = new UpdateHeadphoneCommand { headphonesCrudDto = crudDto };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteHeadphoneCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}