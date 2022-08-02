using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace PeliculasAPI.Helpers.ModelBinder
{
    public class TypeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nombrePropiedad = bindingContext.ModelName;
            var proveedorValores = bindingContext.ValueProvider.GetValue(nombrePropiedad);
            if (proveedorValores == ValueProviderResult.None) return Task.CompletedTask;

            try
            {
                var valorDeserializado = JsonConvert.DeserializeObject<List<int>>(proveedorValores.FirstValue);
                bindingContext.Result = ModelBindingResult.Success(valorDeserializado);
            }
            catch (Exception)
            {

                bindingContext.ModelState.TryAddModelError(nombrePropiedad, "Valor invalido para tipo List<int>");
            }

            return Task.CompletedTask;

        }
    }
}
