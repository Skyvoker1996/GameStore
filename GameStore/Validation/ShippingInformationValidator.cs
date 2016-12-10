using FluentValidation;
using GameStore.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Validation
{/// <summary>
/// Walidator dla tabeli ShippingInformation, dodane reguł walidacji
/// </summary>
    public class ShippingInformationValidator : AbstractValidator<ShippingInformation>
    {
            public ShippingInformationValidator()
            {
                RuleFor(info => info.FullName).NotEmpty().WithMessage("Please enter your Name and Last name");
                RuleFor(info => info.Country).NotEmpty().WithMessage("Please enter your country");
                RuleFor(info => info.City).NotEmpty().WithMessage("Please enter your city/village");
                RuleFor(info => info.StreetAndHouse).NotEmpty().WithMessage("Please enter street and home/apartment information");
                RuleFor(info => info.Zip).NotEmpty().WithMessage("Please enter your zip");
            }
    }
}