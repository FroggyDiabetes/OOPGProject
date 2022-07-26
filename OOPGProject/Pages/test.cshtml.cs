using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace OOPGProject.Pages
{
    public class WeeklyNotepadModel : PageModel
    {
        [BindProperty]
        public string Colour { get; set; }

        [BindProperty]
        public List<string> ColourList { get; set; }

        [BindProperty]
        [Range(1, 100, ErrorMessage = "Invalid Quantity")]
        public int Quantity { get; set; }

        public string Message;

        //This nested list contains the basic info of 
        public List<List<String>> Paper = new List<List<String>>
        {

            new List<String>{},
            new List<String>{"Mini Brick", "5.00", "MiniBrick.png"},
            new List<String>{"Riso Colour Chart Set", "3.50", "RisoColourChartWhite.png"},
            new List<String>{"Onigiri Paper Clips", "5.00", "OnigiriClips.png"}
        };

        //this nested list contains the information of all the paper products
        public List<List<String>> ProductInfo = new List<List<String>>
        {
            new List<String> //Work Pad
            {
                "Work Pad", "9.90", "WorkPadBlack.png",
                "A sturdy and compact pocket companion that is durable and easy to carry even if you are " +
                "always out and about.This notepad is protected by a hard flip cover, letting you write whatever " +
                "you want anytime and anywhere, so that you don’t ever miss even a single detail.",
                "120 x 90 x 21 mm", "120 gsm FSC® Certified Paper", "RISO Ink: Grey (403U)", "3mm GRAPHS | 100 SHEETS"
            },
            new List<String> //Weekly Notepad
            {
                "Weekly Notepad", "12.50", "WeeklyNotepadPaleBlue.png",
                "This notepad consists of 52 weeks, and will help you plan your entire year however you like," +
                " without missing out even a single day.",
                "209 x 147 x 13 mm", "160 gsm FSC® Certified Paper ", "RISO Ink: Grey (403U)", "52 SHEETS"
            },
            new List<String> //Desktop Notepad
            {
                "Desktop Notepad", "13.50", "DesktopNotepadMidGrey.png",
                "A large notepad with a number of options for you to organise yourself and to jot down what you " +
                "need to do over the week, as well as to scribble down your thoughts or ideas; anything that brings " +
                "you inspiration throughout the day.",
                "297 x 210 x 9 mm", "160 gsm FSC® Certified Paper ", "RISO Ink: Aqua (637 U) + Black (Black U)", "40 SHEETS"
            },
            new List<String> //Everyday Notes
            {
                "Everyday Notes", "6.90", "EverydayNotesCoralWhite.jpg",
                "With a total of 140 pages of blank pages, the Everyday Notes allows you to write just about anything you" +
                " like, as much as you like.The Everyday Notes consists of premium quality paper made from 100% post-consumer" +
                " waste, and protected by a thick cover.The layflat pages are bound together securely, with an extra layer of" +
                " gauze for addition strength to the spine.",
                "196 x 141 x 14 mm", "118 gsm 100% Post-Consumer Waste Paper", "RISO Ink: Grey (403U)", "Blank | 140 PAGES"
            },
            new List<String> //Mini Notepad
            {
                "Mini Notepad", "5.50", "MiniNotepadPaleBlue.png",
                "A little notepad for you to carry around and write down your thoughts and ideas at any time.",
                "138 x 90 x 9 mm", "160 gsm FSC® Certified Paper ", "RISO Ink: Fluoro-orange (805U)", "40 SHEETS"
            },
            new List<String> //Two-In-One Pad
            {
                "Two-In-One Pad", "10.00", "2in1PaleBlue.png",
                "Two-toned with a 50/50 share of grids and lines in one notepad, allowing you the flexibility to " +
                "choose what suits you best at any particular moment.",
                "122 x 88 x 20 mm", "120 gsm FSC® Certified Paper ", "RISO Ink: Grey (403U)", "120 SHEETS"
            },
            new List<String> //One Year Planner
            {
                "One Year Planner (Monthly + To Do)", "20.00", "OneYearPlannerStoneBlue.png",
                "With a total of 140 pages and with an abundance of to-do lists, there is ample space to plan for the year" +
                " ahead with your 12-month planner. The One Year Planner consists of premium quality paper made from 100% " +
                "post-consumer waste, and protected by a two-toned duplexed thick cover.The layflat pages are bound together " +
                "securely, with an extra layer of gauze for addition strength to the spine. ",
                "196 x 141 x 14 mm", "18 gsm 100% Post-Consumer Waste Paper ", "RISO Ink: Grey (403U)", "Monthly Planner + To Do | 140 PAGES"
            },
            new List<String> //Sketch Pad
            {
                "Sketch Pad", "15.00", "SketchPadDarkGrey.png",
                "Consisting of 40 sheets and a solid back to keep the pages straight and sturdy, the Sketch Pad is ideal" +
                " for those who like to draw, doodle, or just generally be creative. The blank pages are made from 100% " +
                "post-consumer waste paper, and the back is made from a two-toned duplexed thick card. ",
                "295 x 210 x 8 mm", "118 gsm 100% Post-Consumer Waste Paper ", "RISO Ink: Grey (403U)", "BLANK | 40 SHEETS"
            },
            new List<String> //Layflat Swiss Bound Notebook
            {
                "Layflat Swiss Bound Notebook", "7.90", "LayflatNotebookBlack.png",
                "A notebook with a minimal concept, allowing you room to write, doodle, and/or draw with a creative and " +
                "open mind. It can be laid completely flat, and has the capacity for its pages to be torn off cleanly without " +
                "ruining the rest of the notebook. Inserts are printed with Riso ink, and the cover is foil-block printed on" +
                " FSC® Certified, carbon neutral recycled paper made using 100% wind power.",
                "135 x 89 mm", "120 gsm Acid-Free FSC® Certified Paper ", "RISO Ink: Grey (403U)", "100 PAGES"
            },
        };



        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Added to Cart!";



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
