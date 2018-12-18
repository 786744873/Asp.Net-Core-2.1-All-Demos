using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson10.ModelBinders
{
    public class UserModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //根据用户传递的用户ID,从数据库中读取数据，并实例化对应的User,绑定到参数上
            string parameterName = bindingContext.ModelMetadata.ParameterName;
            ValueProviderResult valueResult= bindingContext.ValueProvider.GetValue(parameterName);

            string value = valueResult.FirstValue;

            int id = 0;
            if (!int.TryParse(value,out id))
            {
                //告诉程序，当前绑定无效
                bindingContext.ModelState.AddModelError(parameterName, "当前要求ID必须为int类型");
                return Task.CompletedTask;
            }

            //从数据库中读取用户信息
            UserInfo user = new UserInfo { Id = id, Name = "用户姓名" };

            bindingContext.Result = ModelBindingResult.Success(user);
            return Task.CompletedTask;
        }
    }
}
