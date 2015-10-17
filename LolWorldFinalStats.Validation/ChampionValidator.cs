using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using LolWorldFinalStats.Models.Domain;

namespace LolWorldFinalStats.Validation
{
    public class ChampionValidator : AbstractValidator<Champion>
    {
        public ChampionValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty();
        }
    }
}
