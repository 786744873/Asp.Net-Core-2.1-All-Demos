using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson5.Pages
{
    public class TestPageModel:PageModel
    {

        public IActionResult OnGet()
        {
            return RedirectToPage("/home/product/1");
        }

        public void OnPost(string username,string password)
        {
            ViewData["postdata"] = username + ":" + password;
        }

        public void OnPostDelete()
        { }

        public void OnPostUpdate()
        { }
    }
}
