using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using OOPGProject.Models; 

namespace OOPGProject.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
		[Required(ErrorMessage = "Enter your email")]
		public string Email { get; set; }

        [BindProperty]
		[Required(ErrorMessage = "Enter your first name")]
		public string FirstName { get; set; }

        [BindProperty]
		[Required(ErrorMessage = "Enter your last name")]
		public string LastName { get; set; }

        [BindProperty]
		[Required(ErrorMessage = "Enter your address")]
		public string Address { get; set; }

        [BindProperty]
        public string Country { get; set; }

		[BindProperty]
		[Required(ErrorMessage = "Enter your postal code")]
		public string PostalCode { get; set; }

		[BindProperty]
		public string Shipping { get; set; }

		[BindProperty]
		public DateTime Delivery { get; set; } = System.DateTime.Now;

		[BindProperty]
		public string Payment { get; set; }

		[BindProperty]
		public string Items { get; set; }

		[BindProperty]
        public string SubmitValue { get; set; }

        public string Message { get; set; }

		public float TotalCost { get; set; }

		public List<Item> FinalProductInfo { get; set; } = new List<Item>(); 
		public List<string> CartList { get; set; }

		public string[] CountryList = { "Afghanistan","Albania","Algeria","American Samoa","Andorra","Angola","Anguilla","Antarctica","Antigua and Barbuda",
			"Argentina","Armenia","Aruba","Australia","Austria","Azerbaijan","Bahamas (the)","Bahrain","Bangladesh","Barbados","Belarus","Belgium","Belize","Benin",
			"Bermuda","Bhutan","Bolivia (Plurinational State of)","Bonaire, Sint Eustatius and Saba","Bosnia and Herzegovina","Botswana","Bouvet Island","Brazil",
			"British Indian Ocean Territory (the)","Brunei Darussalam","Bulgaria","Burkina Faso","Burundi","Cabo Verde","Cambodia","Cameroon","Canada","Cayman Islands (the)",
			"Central African Republic (the)","Chad","Chile","China","Christmas Island","Cocos (Keeling) Islands (the)","Colombia","Comoros (the)","Congo (the)",
			"Cook Islands (the)","Costa Rica","Croatia","Cuba","Curaçao","Cyprus","Czechia","Côte d'Ivoire","Denmark","Djibouti","Dominica","Dominican Republic (the)",
			"Faroe Islands (the)","Fiji","Finland","France","French Guiana","French Polynesia","French Southern Territories (the)","Gabon","Gambia (the)","Georgia",
			"Germany","Ghana","Gibraltar","Greece","Greenland","Grenada","Guadeloupe","Guam","Guatemala","Guernsey","Guinea","Guinea-Bissau","Guyana","Haiti",
			"Heard Island and McDonald Islands","Holy See (the)","Honduras","Hong Kong","Hungary","Iceland","India","Indonesia","Iran (Islamic Republic of)","Iraq",
			"Ireland","Isle of Man","Israel","Italy","Jamaica","Japan","Jersey","Jordan","Kazakhstan","Kenya","Kiribati","Korea (the Democratic People's Republic of)",
			"Korea (the Republic of)","Kuwait","Kyrgyzstan","Lao People's Democratic Republic (the)","Latvia","Lebanon","Lesotho","Liberia","Libya","Liechtenstein",
			"Lithuania","Luxembourg","Macao","Madagascar","Malawi","Malaysia","Maldives","Mali","Malta","Marshall Islands (the)","Martinique","Mauritania","Mauritius",
			"Mayotte","Mexico","Micronesia (Federated States of)","Moldova (the Republic of)","Monaco","Mongolia","Montenegro","Montserrat","Morocco","Mozambique",
			"Myanmar","Namibia","Nauru","Nepal","Netherlands (the)","New Caledonia","New Zealand","Nicaragua","Niger (the)","Nigeria","Niue","Norfolk Island",
			"Northern Mariana Islands (the)","Norway","Oman","Pakistan","Palau","Palestine, State of","Panama","Papua New Guinea","Paraguay","Peru","Philippines (the)",
			"Pitcairn","Poland","Portugal","Puerto Rico","Qatar","Republic of North Macedonia","Romania","Russian Federation (the)","Rwanda","Réunion","Saint Barthélemy",
			"Saint Helena, Ascension and Tristan da Cunha","Saint Kitts and Nevis","Saint Lucia","Saint Martin (French part)","Saint Pierre and Miquelon","Saint Vincent and the Grenadines",
			"Samoa","San Marino","Sao Tome and Principe","Saudi Arabia","Senegal","Serbia","Seychelles","Sierra Leone","Singapore","Sint Maarten (Dutch part)","Slovakia",
			"Slovenia","Solomon Islands","Somalia","South Africa","South Georgia and the South Sandwich Islands","South Sudan","Spain","Sri Lanka","Sudan (the)","Suriname",
			"Svalbard and Jan Mayen","Sweden","Switzerland","Syrian Arab Republic","Taiwan","Tajikistan","Tanzania, United Republic of","Thailand","Timor-Leste","Togo","Tokelau",
			"Tonga","Trinidad and Tobago","Tunisia","Turkey","Turkmenistan","Turks and Caicos Islands (the)","Tuvalu","Uganda","Ukraine","United Arab Emirates (the)",
			"United Kingdom of Great Britain and Northern Ireland (the)","United States Minor Outlying Islands (the)","United States of America (the)","Uruguay","Uzbekistan",
			"Vanuatu","Venezuela (Bolivarian Republic of)","Viet Nam","Virgin Islands (British)","Virgin Islands (U.S.)","Wallis and Futuna","Western Sahara","Yemen","Zambia","Åland Islands" };

		public void OnGet()
        {
			if (TempData.Peek("FinalProductInfo") != null && TempData.Peek("ProductInfo") != null)
			{
				FinalProductInfo = JsonSerializer.Deserialize<List<Item>>(TempData.Peek("FinalProductInfo") as string); 
			}
			else
			{
				FinalProductInfo = new List<Item>();
				TempData["FinalProductInfo"] = JsonSerializer.Serialize(FinalProductInfo); 
			}
			
		}

		public IActionResult OnPost()
		{
			if (SubmitValue == "CLEAR")
            {
				TempData.Remove("FinalProductInfo");
				return Page();
			}

			if (ModelState.IsValid)
			{
				TempData.Keep("Product Info");

				CartList = JsonSerializer.Deserialize<List<string>>(TempData.Peek("FinalProductInfo") as string);

				//TotalCost = ProductInfo[2];

				if (Shipping == "Local Standard" || Shipping == "Local Tracked")
				{
					if (Delivery < System.DateTime.Now.AddDays(3))
					{
						Message = "Preferred delivery date must be at least 3 days from the current date";

						return Page();
					}
				}
                else
                {
					if (Delivery < System.DateTime.Now.AddDays(14))
					{
						Message = "Preferred delivery date must be at least 14 days from the current date";

						return Page();
					}
				}

				return Page();
			}
			else
			{
				return Page();
			}
		}
	}
}
