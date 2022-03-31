using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagementUI
{

    //-------------------------------------------------------------------------------------------------------\\

    public class Module_Information
    {

        //Setting get and set variables for the generic List (ModuleList)
        public string moduleCode;

        public string moduleName;

        public int moduleCredits;

        public int moduleHours;

        public int semesterWeeks;

        public DateTime semesterStart;


        public string ModuleCode { get => moduleCode; set => moduleCode = value; }
        public string ModuleName { get => moduleName; set => moduleName = value; }
        public int ModuleCredits { get => moduleCredits; set => moduleCredits = value; }
        public int ModuleHours { get => moduleHours; set => moduleHours = value; }
        public int SemesterWeeks { get => semesterWeeks; set => semesterWeeks = value; }
        public DateTime SemesterStart { get => semesterStart; set => semesterStart = value; }

        //-------------------------------------------------------------------------------------------------------\\

        //Method overriding ToString that returns the name
        public override string ToString()
        {          
            return ModuleName;
        }
           
    }
}

        //-------------------------------------------------------------------------------------------------------\\
