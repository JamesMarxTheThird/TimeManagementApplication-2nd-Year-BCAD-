using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TimeManagementUI
{
    
//-------------------------------------------------------------------------------------------------------\\

    public partial class UserModulePage : Window
    {
       

        //List declared using the Module_Details class in Application_Processing project where the variables are stored
        public static List<Module_Information> ModuleList = new List<Module_Information>();

        public static WorkingHours WH = new WorkingHours();

        public static DateTime SemesterStart; //To store the starting date of the semester

        //This method contains a regex function. This one is set to only accept numbers
        //Can be implemented into the interface if I write PreviewTextInput="PreviewTextInput" in the textbox XAML contents
        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            //Setting allowed values between 0 and 9 only!
            Regex ExHandled = new Regex("[^0-9]+");
            e.Handled = ExHandled.IsMatch(e.Text);
        }

        //-------------------------------------------------------------------------------------------------------\\

        //This advanced feature restricts the textboxes to letters only
        private void OnlyLetters(object sender, TextCompositionEventArgs a)
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(a.Text, "^[a-zA-Z]"))
            {
                a.Handled = true;
            }

        }

        //-------------------------------------------------------------------------------------------------------\\

        public UserModulePage()
        {
            InitializeComponent();
           // WH.Hide();
        }

        //-------------------------------------------------------------------------------------------------------\\

        public void AddAnotherModule()
        {

            //ModuleList - adding new input (e.g ModuleCodeTB.Text) to variables (e.g moduleCode)
            ModuleList.Add(new Module_Information
                {
                    moduleCode = ModuleCodeTB.Text,
                    moduleName = ModuleNameTB.Text,
                    moduleCredits = Convert.ToInt32(ModuleCreditsTB.Text),
                    moduleHours = Convert.ToInt32(HoursPWTB.Text),
                    semesterWeeks = Convert.ToInt32(NoWeeksTB.Text),
                    semesterStart = StartDatePicker.SelectedDate.Value
            });

            var ModName = from Name in ModuleList select Name.moduleName;

            var ModSSH = from g in ModuleList let SSHAmount = (((g.moduleCredits * 10) / g.semesterWeeks) - g.moduleHours) select SSHAmount;

            //Adding the module name to the List box with From and Select Linq 
            ModuleListBox.ItemsSource = ModName;

           
            //Linq calculation being directly added to the Listbox to display to the user
            SSHListBox.ItemsSource = ModSSH;

        }

        //-------------------------------------------------------------------------------------------------------\\

        public void AddModuleButton(object sender, RoutedEventArgs e)
        {

            //Makes sure user selects a start date
            if (!StartDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a start date for the semester");
            }

            //If they entered one, this code runs
            else
            {

                //Exception handling to make sure no textboxes are left empty
                if (ModuleCodeTB.Text.Trim() == string.Empty || ModuleNameTB.Text.Trim() == string.Empty || ModuleCreditsTB.Text == "" || HoursPWTB.Text == "" || NoWeeksTB.Text == "")
                {
                    MessageBox.Show("Please fill in all the textboxes before you add the module!");
                    //This return helps the program to keep running after error message has been red and accepteed by user
                    return; 
                }

                //Calling method to add the module
                AddAnotherModule();

                //Adding the users input from the list, to listboxes on the next page in order to perform different functions there
                //These use Linq to manipulate the data

                var WHModName = from Name in ModuleList select Name.ModuleName;

                var WHModCode = from Code in ModuleList select Code.ModuleCode;

                var WHModSSH = from g in ModuleList let SSHAmount = (((g.moduleCredits * 10) / g.SemesterWeeks) - g.ModuleHours) select SSHAmount;
                  
                WH.SelectModuleLB.ItemsSource = WHModName;

                WH.ModCodeLB.ItemsSource = WHModCode;

                //

                //Adding a start date stored in the memory
                SemesterStart = (DateTime)StartDatePicker.SelectedDate;
                            
                //Clear all the textboxes after button is clicked
                ModuleCodeTB.Clear();
                ModuleNameTB.Clear();
                ModuleCreditsTB.Clear();
                HoursPWTB.Clear();
                NoWeeksTB.Clear();
              
            }

        }

        //-------------------------------------------------------------------------------------------------------\\

        private void ViewListButton(object sender, RoutedEventArgs e)
        {
            WH.Show();
            Close(); 
        }

        //-------------------------------------------------------------------------------------------------------\\

        //Button that exits program
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        //-------------------------------------------------------------------------------------------------------\\

        //Button that minimizes program
        private void MinimizeButton(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //-------------------------------------------------------------------------------------------------------\\

        //WPF Items that needed to be delcared but not coded inside

        //Uses regex function to only allow 0 - 9 
        private void MCreditsTxt(object sender, TextChangedEventArgs e)
        {

        }

        //Uses regex function to only allow 0 - 9 
        private void ClassHoursTxt(object sender, TextChangedEventArgs e)
        {

        }

        //Uses regex function to only allow 0 - 9 
        private void NoWeeksTxt(object sender, TextChangedEventArgs e)
        {

        }

        private void StartDateTxt(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MCodeTxt(object sender, TextChangedEventArgs e)
        {

        }

        private void MNameTxt(object sender, TextChangedEventArgs e)
        {

        }



    }
}

        //-------------------------------------------------------------------------------------------------------\\
