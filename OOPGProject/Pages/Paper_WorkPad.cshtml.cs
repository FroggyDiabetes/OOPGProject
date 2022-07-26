using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Diagnostics;

namespace OOPGProject.Pages
{
    public class WorkPadModel : PageModel
    {
        [BindProperty]
        public string Colour { get; set; }

        [BindProperty]
        [Range(1, 100, ErrorMessage = "Invalid Quantity")]
        public int Quantity { get; set; }

        public string[] ColourList = { "Black", "Toffee", "Pistachio", "Cornflower", "Pink"};

        public string Message;

        public List<String> ProductInfo = new List<String> { "Work Pad", "9.90" };

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Added to Cart!";

                ProductInfo.Add(Colour);
                ProductInfo.Add(Quantity.ToString());

                TempData["ProductInfo"] = JsonSerializer.Serialize(ProductInfo);
                //Debug.WriteLine(TempData["ProductInfo"]); 

                return Page();
            }
            else
            {
                Message = "Invalid quantity";
                return Page();
            }
        }
    }
}
