using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Diagnostics;
using OOPGProject.Models; 

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

        public Item ProductInfo { get; set; } = new Item(); 

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Added to Cart!";
                ProductInfo = new Item();
                ProductInfo.Name = "Work Pad";
                ProductInfo.Price = 9.90f;
                ProductInfo.Colours.Add(Colour);
                ProductInfo.Quantity.Add(Quantity);

                //TempData["ProductInfo"] = JsonSerializer.Serialize(new List<string> { JsonSerializer.Serialize(ProductInfo) });

                if (TempData.Peek("ProductInfo") == null)
                {
                    TempData["ProductInfo"] = JsonSerializer.Serialize(ProductInfo); 
                    //TempData["ProductInfo"] = new Item { Name = "", Price = 0, Quantity = new List<int>(), Colours = new List<string>() };
                }
                else
                {
                    if (TempData.Peek("FinalProductInfo") == null)
                    {
                        TempData["FinalProductInfo"] = JsonSerializer.Serialize(new List<Item> { ProductInfo });  
                    }
                    else
                    {
                        var temp = JsonSerializer.Deserialize<List<Item>>(TempData.Peek("FinalProductInfo") as string);
                        temp.Add(ProductInfo);
                        TempData["FinalProductInfo"] = JsonSerializer.Serialize(temp);
                    }

                }
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
