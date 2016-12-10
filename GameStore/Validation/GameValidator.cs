using FluentValidation;
using GameStore.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Validation
{/// <summary>
/// Walidator dla tabeli Game, dodane reguł walidacji
/// </summary>
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(game => game.Name).NotEmpty().WithMessage("Please enter a game name");
            RuleFor(game => game.Category).NotEmpty().WithMessage("Please write a game category");
            RuleFor(game => game.Price).GreaterThan(0).NotEmpty().WithMessage("Please enter a positive price");
            RuleFor(game => game.Description).NotEmpty().WithMessage("Please add a description");
            RuleFor(game => game.Platform).NotEmpty().WithMessage("Please enter a game platform");
        }
    }
}