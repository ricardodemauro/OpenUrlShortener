using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OpenUrlShortner.Domain;
using OpenUrlShortner.Web.Application.Commands;
using OpenUrlShortner.Web.Helpers;
using OpenUrlShortner.Web.Options;
using OpenUrlShortner.Web.Validations;
using System;
using System.Linq;
using System.Net.Http;

namespace OpenUrlShortner.Web.Controllers
{
    [Route("api/[controller]")]
    public class RandomController : Controller
    {
        [HttpGet("[action]/{size}")]
        public IActionResult Create([FromQuery] int size = 9)
            => Ok(UrlHelper.RandomString(size));


        [HttpGet("[action]")]
        public IActionResult CreateUrl([FromQuery] string url = null, [FromServices] UrlOptions urlOptions = null)
        {
            if (ModelState.IsValid)
            {
                if (UrlHelper.IsValid(url))
                {
                    var shortModel = new ShortUrl();

                    shortModel.OriginalUrl = url;
                    shortModel.Url = $"{urlOptions.BaseUrl}{UrlHelper.RandomString(10)}";

                    return Ok(shortModel);
                }
                ModelState.AddModelError(nameof(url), "Url not valid");
            }

            return BadRequest(ModelState.Values);
        }

        [HttpPost("[action]")]
        public IActionResult Create(
            [FromBody] CreateShortUrlCmdReq req,
            [FromServices] UrlOptions urlOptions,
            [FromServices] CreateUrlValidation validation)
        {
            var result = validation.Validate(req);

            if (result.IsValid)
            {
                var shortModel = new ShortUrl();

                shortModel.OriginalUrl = req.Url;
                shortModel.Url = $"{urlOptions.BaseUrl}{UrlHelper.RandomString(10)}";

                var link = LinkHelper<ShortUrl>.Create(shortModel)
                    .WithLink($"/links/{shortModel.Id}", "self", HttpMethod.Get);
                return Ok(link);
            }

            return BadRequest(result.Errors.Select(x => new { x.AttemptedValue, x.PropertyName, x.ErrorMessage }));
        }
    }
}
