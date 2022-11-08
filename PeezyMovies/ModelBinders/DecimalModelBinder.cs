namespace PeezyMovies.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Globalization;

    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if(result != ValueProviderResult.None && !string.IsNullOrEmpty(result.FirstValue))
            {
                var decimalValue = 0M;
                var success = false;
                var currentValue = result.FirstValue;

                try
                {
                    currentValue = currentValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    currentValue = currentValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decimalValue = Convert.ToDecimal(currentValue, CultureInfo.CurrentCulture);
                    success = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                   
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(decimalValue);

                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
