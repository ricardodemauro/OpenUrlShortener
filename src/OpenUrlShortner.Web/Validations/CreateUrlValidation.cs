using FluentValidation;
using OpenUrlShortner.Web.Application.Commands;
using OpenUrlShortner.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenUrlShortner.Web.Validations
{
    public class CreateUrlValidation : AbstractValidator<CreateShortUrlCmdReq>
    {
        public CreateUrlValidation()
        {
            RuleFor(x => x.Url)
                .NotEmpty()
                .Must(UrlHelper.IsValid);
        }
    }
}
