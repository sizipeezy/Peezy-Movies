namespace PeezyMovies.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if(context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(Decimal?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }
}
