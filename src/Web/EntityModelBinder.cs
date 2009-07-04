using System.Web.Mvc;
using Homework2.Models;

namespace Homework2
{
    public class EntityModelBinder : DefaultModelBinder
    {
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var entity = bindingContext.Model as Entity;
            if (entity == null)
            {
                base.OnModelUpdated(controllerContext, bindingContext);
                return;
            }

            ValidationResults results = entity.Validate();

            if (!results.IsValid)
            {
                foreach (ValidationResult result in results)
                    bindingContext.ModelState.AddModelError(result.Key, result.Message);
            }
        }
    }
}