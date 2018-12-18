using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson10.ModelBinders
{
    public class UserModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            //判断参数类型
            if (context.Metadata.ModelType == typeof(UserInfo))
            {
                return new BinderTypeModelBinder(typeof(UserModelBinder));
                //return new UserModelBinder();
            }

            return null;
        }
    }
}
