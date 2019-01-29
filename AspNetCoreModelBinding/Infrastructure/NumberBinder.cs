using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreModelBinding.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Remotion.Linq.Utilities;

namespace AspNetCoreModelBinding.Infrastructure
{
    public class NumberBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string modelName = bindingContext.ModelName;

            Dictionary<string, ValueProviderResult> data = new Dictionary<string, ValueProviderResult>();

            data.Add("first", GetValue(bindingContext, modelName, "first"));
            data.Add("second", GetValue(bindingContext, modelName, "second"));
            data.Add("add", GetValue(bindingContext, modelName, "op", "add"));
            data.Add("double", GetValue(bindingContext, modelName, "op", "double"));

            if (data.All(x => x.Value != null))
            {
                bindingContext.Model = CreateInstance(data);
                bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);

            }

            return Task.FromResult(Task.CompletedTask);
        }

        private ValueProviderResult GetValue(ModelBindingContext context, params string[] names)
        {
            for (int i = 0; i < names.Length - 1; i++)
            {
                string prefix = string.Join(".", names.Skip(i).Take(names.Length - (i + 1)));

                if (context.ValueProvider.ContainsPrefix(prefix))
                {
                    return context.ValueProvider.GetValue(prefix + "." + names.Last());
                }
            }

            return context.ValueProvider.GetValue(names.Last());
        }

        private T Convert<T>(ValueProviderResult result)
        {
            try
            {
                return (T)System.Convert.ChangeType(result.FirstValue, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        private Number CreateInstance(Dictionary<string, ValueProviderResult> data)
        {
            return new Number(Convert<int>(data["first"]), Convert<int>(data["second"]), new Operation
            {
                Add = Convert<bool>(data["add"]),
                Double = Convert<bool>(data["double"])
            });
        }
    }
}