using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LolWorldFinalStats.Models.Domain;

namespace LolWorldFinalStats.Validation
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty();
            RuleFor(a => a.StartDateUtc)
                .NotNull();
        }
    }
}
