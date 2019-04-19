/* UserInterface.cs
 * Author: Easton Bolinger
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ksu.Cis300.TrieLibrary;


namespace Ksu.Cis300.ReportingStructureViewer
{
    /// <summary>
    /// This class handles all aspects of the UserInterface
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// intializes the components
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// field setting the default minimum prefix length
        /// </summary>
        private const int _minimumPrefixLength = 2;
        /// <summary>
        /// dictionary holding all names
        /// </summary>
        private Dictionary<string, List<Employee>> _namesDictionary;
        /// <summary>
        /// sorted trie containing all names
        /// </summary>
        private ITrie _names;
        /// <summary>
        /// looks to see if any prefix is presents
        /// </summary>
        /// <param name="prefix">the prefix ebing searched for</param>
        /// <returns>a set of names </returns>
        private SortedSet<Employee> PrefixSearch(string prefix)
        {
            uxListBox.Items.Clear();
            ITrie names = _names.GetCompletions(prefix);
            List<string> temp = new List<string>();

            if(names != null)
            {
                uxListBox.BeginUpdate();
                names.AddAll(new StringBuilder(prefix), temp);
                uxListBox.EndUpdate();
            }

            SortedSet<Employee> nNames = new SortedSet<Employee>();

            foreach(string s in temp)
            {
                int i = 0;
                if(_namesDictionary.TryGetValue(s,out List<Employee> tempList) == true)
                {
                    nNames.Add(tempList[i]);
                    i++;
                }
            }
            return nNames;
        }
        /// <summary>
        /// sets the employee list to the ux
        /// </summary>
        /// <param name="employee">the sortedlist of all employees needed</param>
        private void SetEmpolyeeList(SortedSet<Employee> employee)
        {
            uxListBox.Items.Clear();
            foreach(Employee e in employee)
            {
                uxListBox.Items.Add(e);
            }
        }
        /// <summary>
        /// Loads the userinterface at the beginning of the program
        /// </summary>
        /// <param name="sender">the ui</param>
        /// <param name="e">the event of starting the program</param>
        private void UserInterface_Load(object sender, EventArgs e)
        {
            if(uxOpenFile.ShowDialog() == DialogResult.OK)
            {
                string file = uxOpenFile.FileName;
                Dictionary<string, List<Employee>> temp = EmployeeLoader.GetNamesDictionary(file);
                _namesDictionary = EmployeeLoader.GetNamesDictionary(file);
                _names = EmployeeLoader.GetNamesTrie(temp);
            }
            else
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// handles when the text in the textbox is changed
        /// </summary>
        /// <param name="sender">the textbox</param>
        /// <param name="e">changing of text</param>
        private void uxTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = uxTextBox.Text.Trim();
            if(text.Length >= _minimumPrefixLength)
            {
                uxLookup.Enabled = true;
            }
            else
            {
                uxLookup.Enabled = false;
            }
        }
        /// <summary>
        /// hadnles when the user selects the lookup function
        /// </summary>
        /// <param name="sender">the ui</param>
        /// <param name="e">the lookup button</param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string toLookUp = uxTextBox.Text.Trim().ToLower();
            SortedSet<Employee> temp = PrefixSearch(toLookUp);
            SetEmpolyeeList(temp);
        }
        /// <summary>
        /// handles when the selected of the listbox is changed 
        /// </summary>
        /// <param name="sender">the lsitbox</param>
        /// <param name="e">changing selected index</param>
        private void uxListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(uxListBox.SelectedIndex >= 0)
            {
                uxGenerateReport.Enabled = true;
            }
            else
            {
                uxGenerateReport.Enabled = false;
            }
        }
        /// <summary>
        /// handles when the user wants to generate a report
        /// </summary>
        /// <param name="sender">the ui</param>
        /// <param name="e">the generate button</param>
        private void uxGenerateReport_Click(object sender, EventArgs e)
        {
            Employee temp = (Employee)uxListBox.SelectedItem;
            uxSaveFileDialog.FileName = temp.ToString();
            try
            {
                if(uxSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ReportGenerator.GenerateReport(temp, (int)uxUpDown.Value, uxSaveFileDialog.FileName);
                    uxWebBrowser.Navigate(uxSaveFileDialog.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// loads the user interface when program begins
        /// </summary>
        /// <param name="sender">the ui</param>
        /// <param name="e">starting the program</param>
        private void UserInterface_Load_1(object sender, EventArgs e)
        {
            if (uxOpenFile.ShowDialog() == DialogResult.OK)
            {
                string file = uxOpenFile.FileName;
                Dictionary<string, List<Employee>> temp = EmployeeLoader.GetNamesDictionary(file);
                _namesDictionary = EmployeeLoader.GetNamesDictionary(file);
                _names = EmployeeLoader.GetNamesTrie(temp);
            }
            else
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// handles when the textbox's text is altered
        /// </summary>
        /// <param name="sender">the textbox</param>
        /// <param name="e">changing the text</param>
        private void uxTextBox_TextChanged_1(object sender, EventArgs e)
        {
            string text = uxTextBox.Text.Trim();
            if (text.Length >= _minimumPrefixLength)
            {
                uxLookup.Enabled = true;
            }
            else
            {
                uxLookup.Enabled = false;
            }
        }

    }
}
