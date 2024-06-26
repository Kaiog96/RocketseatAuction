﻿using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : RocketseatAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromServices] CreateOfferUseCase useCase, [FromRoute] int itemId, [FromBody] RequestCreateOfferJson request)
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}

