using System.Web.Mvc;

namespace AspectCore.Sample.Net45.Mvc.Interceptors
{
    public class FromServiceAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new ModelBinder();
        }

        private class ModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                return bindingContext.Model;
            }
        }
    }
}