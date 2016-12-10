using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace GameStore.Validation
{/// <summary>
/// Klasa która konwertuje błędy otrzymane przez FluentValidation w błędy typu ModelState dla poprawnej pracy Html.Helper ValidationSummary
/// </summary>
    public static class FluentValidationErrorToStateModelError
    {
        public static void Update(this System.Web.Mvc.ModelStateDictionary modelState, ValidationResult result, bool usePropertyNames = false)
        {
            if (result.IsValid)
                return;

            foreach (var error in result.Errors)
            {
                // If we exclude the property name the error will show up in the validation summary
                var propertyName = usePropertyNames ? error.PropertyName : "";
                modelState.AddModelError(propertyName, error.ErrorMessage);
            }
        }

        public static void AddModelError<TModel>(this System.Web.Mvc.ModelStateDictionary modelState, Expression<Func<TModel, object>> expr, string error)
        {
            var propertyName = ExpressionHelper.GetExpressionText(expr);
            modelState.AddModelError(propertyName, error);
        }
    }
}