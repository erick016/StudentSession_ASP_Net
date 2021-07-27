using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentSession_Oct12.Models;

namespace StudentSession_Oct12.Models
{
    public class InstIndexModel : PageModel
    {

        



        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            //Console.Beep();


            if (!ModelState.IsValid)
            {
                return Page();
            }


            //Console.WriteLine(result);


            return RedirectToPage();
        }
    }
}
