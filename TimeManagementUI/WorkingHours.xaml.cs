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

    public partial class WorkingHours : Window
    {

        //-------------------------------------------------------------------------------------------------------\\

        //This method contains a regex function. This one is set to only accept numbers
        //Can be implemented into the interface if I write PreviewTextInput="PreviewTextInput" in the textbox XAML contents
        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Setting allowed values between 0 and 9 only!
            Regex ExHandled = new Regex("[^0-9]+");
            e.Handled = ExHandled.IsMatch(e.Text);
        }

        //-------------------------------------------------------------------------------------------------------\\

        //This regex function restricts the textboxes to letters only
        private void OnlyLetters(object sender, TextCompositionEventArgs a)
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(a.Text, "^[a-zA-Z]"))
            {
                a.Handled = true;
            }

        }

        //-------------------------------------------------------------------------------------------------------\\

        public WorkingHours()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------\\

        //Calculates the self study hours and makes sure fileds are filled correctly
        public void Calculate_RemainingSSH()
        {

            //Using a nested if statment, this was effective to make sure all fields are filled correctly without redundant error messages

            //Textbox won't be left empty
            if (ModuleName_WH.Text.Trim() == String.Empty || !SelectModuleLB.Items.Contains(ModuleName_WH.Text))
            {
                MessageBox.Show("Please enter a correct module name first!");
            }
            //Continues when criteria is met
            else
            {

                //If top textbox is the same as a module name from the list, program continues
                if (SelectModuleLB.Items.Contains(ModuleName_WH.Text))
                {

                    //Setting variables equal to start and end of the week, so that the user can enter their SSH for their current week

                    //
                    //Currently works with this current week except today, is my calnedar wrong? 
                    DateTime t = DateTime.Now;
                    t -= new TimeSpan((int)t.DayOfWeek - 1);

                    DateTime startWeek = t;
                    DateTime endWeek = startWeek.AddDays(6);

                    //Making sure the date selected is for the current week - This works 100% except for during the current date
                    if (WH_DatePicker.SelectedDate >= startWeek && WH_DatePicker.SelectedDate <= endWeek)
                    {

                        //Exception handling to make sure there are no empty values being processed
                        if (SSHSpecificDay.Text.Trim() == String.Empty)
                        {
                            MessageBox.Show("Make sure all textboxes and options have been filled before you continue");
                        }

                        //Now all requirement for wokring hours page have been met, we can run our Linq calculation
                        else
                        {
                            //Calculates the ssh then removes what the user entered in textbox
                            var WHModSSH = from g in UserModulePage.ModuleList let SSHAmount = ((((g.moduleCredits * 10) / g.SemesterWeeks) - g.ModuleHours) - Convert.ToInt32(SSHSpecificDay.Text)) select SSHAmount;
                            ReportSSHRemainLB.ItemsSource = WHModSSH;

                        }

                    }

                    //Error message so users will enter the correct value
                    else
                    {
                        MessageBox.Show("The date you selected doesn't fall under the current week\nSelect a day this week to calculate your remaining self study hours!");
                    }

                //Making sure module name is correct
                }
                else
                {
                    MessageBox.Show("Please enter the exact module name to calculate the remaining hours");
                }

            }
            
        }

        //-------------------------------------------------------------------------------------------------------\\

        //Button that calls my calculation method
        private void EditSSHButton(object sender, RoutedEventArgs e)
        {
            
            //Method with all calculations & exception handling
            Calculate_RemainingSSH();
            
        }

        //-------------------------------------------------------------------------------------------------------\\

        //Button used to exit program
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        //-------------------------------------------------------------------------------------------------------\\

        //Button that minmizes window
        private void MinimizeButton(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //-------------------------------------------------------------------------------------------------------\\

        //Declared, uncoded wpf items
        private void WorkingHoursTxt(object sender, TextChangedEventArgs e)
        {

        }

        public void ChangeHours(double hours)
        {

        }

        public void GetListItems()
        {

        }

        private void ModuleName_WH_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ModuleName_WH_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}

        //-------------------------------------------------------------------------------------------------------\\
