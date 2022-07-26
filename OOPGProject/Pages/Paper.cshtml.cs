using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OOPGProject.Pages
{
    public class PaperModel : PageModel
    {
        [BindProperty]
        public bool All { get; set; }

        [BindProperty]
        public bool FPlanners { get; set; }

        [BindProperty]
        public bool FNotepads { get; set; }

        [BindProperty]
        public bool FSketchpads { get; set; }

        [BindProperty]
        public bool FOthers { get; set; }

        public int FCount { get; set; } //this is to keep track of the amount of filters selected

        //this is a nested list that contains the details of all the paper products
        public List<List<String>> Paper = new List<List<String>>  
        {
            new List<String>{"Work Pad", "9.90", "WorkPadBlack.png", "Paper_WorkPad"},
            new List<String>{"Weekly Notepad", "12.50", "WeeklyNotepadPaleBlue.png", "test"},
            new List<String>{"Desktop Notepad", "13.50", "DesktopNotepadMidGrey.png", "Paper_DesktopNotepad"},
            new List<String>{"Everyday Notes", "6.90", "EverydayNotesCoralWhite.jpg", "Paper_EverydayNotes"},
            new List<String>{"Mini Notepad", "5.50", "MiniNotepadPaleBlue.png", "Paper_MiniNotepad"},
            new List<String>{"Two-In-One Pad", "10.00", "2in1PaleBlue.png", "Paper_2in1"},
            new List<String>{"One Year Planner (Monthly + To Do)", "20.00", "OneYearPlannerStoneBlue.png", "Paper_"},
            new List<String>{"Sketch Pad", "15.00", "SketchPadDarkGrey.png", "Paper_SketchPad"},
            new List<String>{"Layflat Swiss Bound Notebook", "7.90", "LayflatNotebookBlack.png", "Paper_Layflat"},
            new List<String>{"Mini Brick", "5.00", "MiniBrick.png", "Paper_MiniBrick"},
            new List<String>{"Riso Colour Chart Set", "3.50", "RisoColourChartWhite.png", "Paper_Riso"},
            new List<String>{"Onigiri Paper Clips", "5.00", "OnigiriClips.png", "Paper_Onigiri"}
        };


        //this list and the others below are product subcategories used for a product filtering system
        public List<List<String>> AllCategories = new List<List<String>> 
        {
            new List<String>{"Work Pad", "9.90", "WorkPadBlack.png", "Paper_WorkPad"},
            new List<String>{"Weekly Notepad", "12.50", "WeeklyNotepadPaleBlue.png", "Paper_WeeklyNotepad"},
            new List<String>{"Desktop Notepad", "13.50", "DesktopNotepadMidGrey.png", "Paper_DesktopNotepad"},
            new List<String>{"Everyday Notes", "6.90", "EverydayNotesCoralWhite.jpg", "Paper_EverydayNotes"},
            new List<String>{"Mini Notepad", "5.50", "MiniNotepadPaleBlue.png", "Paper_MiniNotepad"},
            new List<String>{"Two-In-One Pad", "10.00", "2in1PaleBlue.png", "Paper_2in1"},
            new List<String>{"One Year Planner (Monthly + To Do)", "20.00", "OneYearPlannerStoneBlue.png", "Paper_"},
            new List<String>{"Sketch Pad", "15.00", "SketchPadDarkGrey.png", "Paper_SketchPad"},
            new List<String>{"Layflat Swiss Bound Notebook", "7.90", "LayflatNotebookBlack.png", "Paper_Layflat"},
            new List<String>{"Mini Brick", "5.00", "MiniBrick.png", "Paper_MiniBrick"},
            new List<String>{"Riso Colour Chart Set", "3.50", "RisoColourChartWhite.png", "Paper_Riso"},
            new List<String>{"Onigiri Paper Clips", "5.00", "OnigiriClips.png", "Paper_Onigiri"}
        };

        public List<List<String>> Planners = new List<List<String>>
        {
            new List<String>{"Weekly Notepad", "12.50", "WeeklyNotepadPaleBlue.png", "Paper_WeeklyNotepad"},
            new List<String>{"One Year Planner (Monthly + To Do)", "20.00", "OneYearPlannerStoneBlue.png", "Paper_"},
        };

        public List<List<String>> Notepads = new List<List<String>>
        {
            new List<String>{"Work Pad", "9.90", "WorkPadBlack.png", "Paper_WorkPad"},
            new List<String>{"Desktop Notepad", "13.50", "DesktopNotepadMidGrey.png", "Paper_DesktopNotepad"},
            new List<String>{"Everyday Notes", "6.90", "EverydayNotesCoralWhite.jpg", "Paper_EverydayNotes"},
            new List<String>{"Mini Notepad", "5.50", "MiniNotepadPaleBlue.png", "Paper_MiniNotepad"},
            new List<String>{"Two-In-One Pad", "10.00", "2in1PaleBlue.png", "Paper_2in1"},
            new List<String>{"Layflat Swiss Bound Notebook", "7.90", "LayflatNotebookBlack.png", "Paper_Layflat"},
            new List<String>{"Mini Brick", "5.00", "MiniBrick.png", "Paper_MiniBrick"}
        };

        public List<List<String>> Sketchpads = new List<List<String>>
        {
            new List<String>{"Sketch Pad", "15.00", "SketchPadDarkGrey.png", "Paper_SketchPad"},
        };

        public List<List<String>> Others = new List<List<String>>
        {
            new List<String>{"Riso Colour Chart Set", "3.50", "RisoColourChartWhite.png", "Paper_Riso"},
            new List<String>{"Onigiri Paper Clips", "5.00", "OnigiriClips.png", "Paper_Onigiri"}

        };

        public string[] Categories = { "All", "Planners", "Notepads", "Sketchpads", "Others" };

        public List<List<String>> Filtered = new List<List<String>>();

        public void OnPost()
        {
            FCount = 0;

            if (All)
            {
                Paper = AllCategories;
                FCount++;
            }
            else
            {
                if (FNotepads)
                {
                    foreach (List<String> i in Notepads)
                    {
                        Filtered.Add(i);
                    }
                    FCount++;
                }
                if (FPlanners)
                {
                    foreach (List<String> i in Planners)
                    {
                        Filtered.Add(i);
                    }
                    FCount++;
                }
                if (FSketchpads)
                {
                    foreach (List<String> i in Sketchpads)
                    {
                        Filtered.Add(i);
                    }
                    FCount++;
                }
                if (FOthers)
                {
                    foreach (List<String> i in Others)
                    {
                        Filtered.Add(i);
                    }
                    FCount++;
                }
                
                Paper = Filtered;
            }

            if (FCount == 0) //if no filters are selected, display all products
            {
                Paper = AllCategories;
            }
        }
    }
}