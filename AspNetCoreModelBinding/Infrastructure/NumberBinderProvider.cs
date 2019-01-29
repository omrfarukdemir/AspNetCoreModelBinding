using System;
using AspNetCoreModelBinding.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AspNetCoreModelBinding.Infrastructure
{
    public class NumberBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Number))
            {
                return new BinderTypeModelBinder(typeof(NumberBinder));
            }

            return null;
        }
    }
}