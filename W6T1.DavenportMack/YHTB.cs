using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

/*
    This is a relatively simple applet designed to take a user's expenses and determine the approximate monthly
    cost of each of them combined. Users can also add monthly expenses for convenience. This is a great tool
    for quickly estimating what you would need to save monthly on expenses that occur annually such as isurance
    premiums, car service, dental visits, etc.

    It's currently limited to 10 entries for simplicity's sake. Users can enter '$' signs if they wish, but
    only one, as well as en-US numeric separators like '.' and ','. Other non-numeric characters are not accepted. 
    Issues with any entry are provided to the user through an on screen MessageBox and handled by clearing the field
    and processing the correctly filled out boxes.
*/

namespace FinalProject.DavenportMack
{
    public partial class YHTB : Form
    {
        public YHTB()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double count = 0;
            double tmpNum = 0;

            bool fail1 = false; bool fail2 = false; bool fail3 = false; bool fail4 = false;
            bool fail5 = false; bool fail6 = false; bool fail7 = false; bool fail8 = false;
            bool fail9 = false; bool fail10 = false;

            // boolean output of TryParse is used as the try catch
            if (!string.IsNullOrEmpty(amt1.Text))
                if (double.TryParse(parseDollar(amt1.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual1.Checked, rdoBiannual1.Checked, rdoMonthly1.Checked));
                else
                {
                    fail1 = true; amt1.Text = "";
                }

            if (!string.IsNullOrEmpty(amt2.Text))
                if (double.TryParse(parseDollar(amt2.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual2.Checked, rdoBiannual2.Checked, rdoMonthly2.Checked));
                else
                {
                    fail2 = true; amt2.Text = "";
                }

            if (!string.IsNullOrEmpty(amt3.Text))
                if (double.TryParse(parseDollar(amt3.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual3.Checked, rdoBiannual3.Checked, rdoMonthly3.Checked));
                else
                {
                    fail3 = true; amt3.Text = "";
                }

            if (!string.IsNullOrEmpty(amt4.Text))
                if (double.TryParse(parseDollar(amt4.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual4.Checked, rdoBiannual4.Checked, rdoMonthly4.Checked));
                else
                {
                    fail4 = true; amt4.Text = "";
                }

            if (!string.IsNullOrEmpty(amt5.Text))
                if (double.TryParse(parseDollar(amt5.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual5.Checked, rdoBiannual5.Checked, rdoMonthly5.Checked));
                else
                {
                    fail5 = true; amt5.Text = "";
                }

            if (!string.IsNullOrEmpty(amt6.Text))
                if (double.TryParse(parseDollar(amt6.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual6.Checked, rdoBiannual6.Checked, rdoMonthly6.Checked));
                else
                {
                    fail6 = true; amt6.Text = "";
                }

            if (!string.IsNullOrEmpty(amt7.Text))
                if (double.TryParse(parseDollar(amt7.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual7.Checked, rdoBiannual7.Checked, rdoMonthly7.Checked));
                else
                {
                    fail7 = true; amt7.Text = "";
                }

            if (!string.IsNullOrEmpty(amt8.Text))
                if (double.TryParse(parseDollar(amt8.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual8.Checked, rdoBiannual8.Checked, rdoMonthly8.Checked));
                else
                {
                    fail8 = true; amt8.Text = "";
                }

            if (!string.IsNullOrEmpty(amt9.Text))
                if (double.TryParse(parseDollar(amt9.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual9.Checked, rdoBiannual9.Checked, rdoMonthly9.Checked));
                else
                {
                    fail9 = true; amt9.Text = "";
                }

            if (!string.IsNullOrEmpty(amt10.Text))
                if (double.TryParse(parseDollar(amt10.Text), out tmpNum))
                    count += (tmpNum / getFrequency(rdoAnnual10.Checked, rdoBiannual10.Checked, rdoMonthly10.Checked));
                else
                {
                    fail10 = true; amt10.Text = "";
                }

            ifError(new bool[] {
                fail1, fail2, fail3, fail4, fail5, fail6, fail7, fail8, fail9, fail10
            });

            if (count != 0)
            {
                lbl_FinalMessage.Left = 260;
                lbl_FinalMessage.Text = "If all your bills were monthly, you would pay: ";
                lbl_finalValue.Text = "$ " + formatDouble(count);
            }
            else
            {
                lbl_FinalMessage.Left = 350;
                lbl_FinalMessage.Text = "Try entering some values! ";
            }
        }

        // used for loop instead of foreach to pass index to error line dictionary
        private void ifError(bool[] rows)
        {
            if (rows.Any(row => row))
            {
                string errors = "";
                for (int index = 1; index <= rows.Length; index++)
                    if (rows[index - 1])
                        errors += "There was an error with " + getErrorLine(index) + ".\n";
                MessageBox.Show(errors, "Please check the values you entered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string getErrorLine(int row)
        {
            Dictionary<int, string> errorMap = new Dictionary<int, string>
            {
                { 1,  string.IsNullOrEmpty(expense1.Text)  ? "line 1"  : "expense " + expense1.Text  },
                { 2,  string.IsNullOrEmpty(expense2.Text)  ? "line 2"  : "expense " + expense2.Text  },
                { 3,  string.IsNullOrEmpty(expense4.Text)  ? "line 3"  : "expense " + expense3.Text  },
                { 4,  string.IsNullOrEmpty(expense4.Text)  ? "line 4"  : "expense " + expense4.Text  },
                { 5,  string.IsNullOrEmpty(expense5.Text)  ? "line 5"  : "expense " + expense5.Text  },
                { 6,  string.IsNullOrEmpty(expense6.Text)  ? "line 6"  : "expense " + expense6.Text  },
                { 7,  string.IsNullOrEmpty(expense7.Text)  ? "line 7"  : "expense " + expense7.Text  },
                { 8,  string.IsNullOrEmpty(expense8.Text)  ? "line 8"  : "expense " + expense8.Text  },
                { 9,  string.IsNullOrEmpty(expense9.Text)  ? "line 9"  : "expense " + expense9.Text  },
                { 10, string.IsNullOrEmpty(expense10.Text) ? "line 10" : "expense " + expense10.Text },
            };

            // operation should never be false, unless the form is modified
            return errorMap.ContainsKey(row) ? errorMap[row] : "one of the expenses";
        }

        private int getFrequency(bool annual, bool biannual, bool monthly)
        {
            // would be a more useful structure with more values
            Dictionary<string, int> freqMap = new Dictionary<string, int>
            {
                { "annual",  12 },
                { "biannual", 6 },
                { "monthly",  1 },
            };

            if (biannual) return freqMap["biannual"];
            else if (monthly) return freqMap["monthly"];
            else return freqMap["annual"];
        }

        private string formatDouble(double count)
        {
            // Just converts and forces trailing 0s
            return string.Format(
                new CultureInfo("en-US"), "{0:0.00}",
                Math.Truncate(count * 100) / 100
            );
        }

        private string parseDollar(string txt)
        {
            // replace $ with space for numerical parsing, if there's only one
            return (txt.Contains("$") && (txt.IndexOf("$") == txt.LastIndexOf("$"))) ?
                txt.Replace(@"$", "") :
                txt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            expense1.Text = expense2.Text = expense3.Text = expense4.Text = expense5.Text = 
            expense6.Text = expense7.Text = expense8.Text = expense9.Text = expense10.Text = 
            amt1.Text = amt2.Text = amt3.Text = amt4.Text = amt5.Text = amt6.Text = amt7.Text = 
            amt8.Text = amt9.Text = amt10.Text = lbl_FinalMessage.Text = lbl_finalValue.Text = "";

            rdoAnnual1.Checked = rdoAnnual2.Checked = rdoAnnual3.Checked = rdoAnnual4.Checked = 
            rdoAnnual5.Checked = rdoAnnual6.Checked = rdoAnnual7.Checked = rdoAnnual8.Checked = 
            rdoAnnual9.Checked = rdoAnnual10.Checked = true;
        }
    }
}