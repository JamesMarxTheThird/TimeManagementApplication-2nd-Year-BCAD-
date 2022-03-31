using System;
using System.Collections.Generic;


namespace Console_Processing
{

    class Module
    {

    }

    public static class ModuleInformation
    {

        private static string moduleCode;

        private static string moduleName;

        private static int moduleCredits;

        private static int moduleHours;

        public static string ModuleCode { get => moduleCode; set => moduleCode = value; }
        public static string ModuleName { get => moduleName; set => moduleName = value; }
        public static int ModuleCredits { get => moduleCredits; set => moduleCredits = value; }
        public static int ModuleHours { get => moduleHours; set => moduleHours = value; }

        //List to contain module information
        public static List<object> ModuleInfo = new List<object>();

        

    }


}
