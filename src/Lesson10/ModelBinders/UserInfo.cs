using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson10.ModelBinders
{
    //[ModelBinder(BinderType = typeof(UserModelBinder))]
    public class UserInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
