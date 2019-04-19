/* EmployeeLoader.cs
 * Author: Easton Bolinger
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ksu.Cis300.TrieLibrary;
using System.Windows.Forms;

namespace Ksu.Cis300.ReportingStructureViewer
{
    /// <summary>
    /// the class handles the building of the employee class 
    /// </summary>
    public class EmployeeLoader
    {
        /// <summary>
        /// adds an employee to the dictionary 
        /// </summary>
        /// <param name="e">the employee being added</param>
        /// <param name="key">the name being passed</param>
        /// <param name="destination">the dictionary being added to</param>
        private static void AddEmployee(Employee e, string key, Dictionary<string,List<Employee>> destination)
        {
            if(destination.TryGetValue(key,out List<Employee> tempList) == false)
            {
                tempList = new List<Employee>();
                destination.Add(key, tempList);
            }
            tempList.Add(e);
        }
        /// <summary>
        /// adds employees to a manager's team
        /// </summary>
        /// <param name="allEmployees"></param>
        private static void AddTeamMembers(Dictionary<string,Employee> allEmployees)
        {
                foreach (Employee current in allEmployees.Values)
                {
                    if (current.ManagerID != "0")
                    {
                        bool result = allEmployees.TryGetValue(current.ManagerID, out Employee e);
                        if (result == false)
                        {
                            string error = "There is no manager with ID " + current.ManagerID;
                            MessageBox.Show(error);
                            throw new IOException("There is no manager with ID " + current.ManagerID);
                        }
                         e.DirectReports.Add(current);
                    }
                }
        }
        /// <summary>
        /// gets a dictionary of names 
        /// </summary>
        /// <param name="fileName">the file being searched through</param>
        /// <returns>the dictionary of names</returns>
        public static Dictionary<string, List<Employee>> GetNamesDictionary(string fileName)
        {
            Dictionary<string, Employee> tempDictionary = new Dictionary<string, Employee>();
            Dictionary<string, List<Employee>> tempList = new Dictionary<string, List<Employee>>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while(!sr.EndOfStream)
                {
                    string fileLine = sr.ReadLine();
                    string[] temp = fileLine.Split(',');
                    if(temp.Length != 5)
                    {
                        string error = "An input line contains the wrong number of fields";
                        MessageBox.Show(error);
                        throw new IOException("An input line contains the wrong number of fields");
                    }
                    
                        Employee newEmployee = new Employee(temp[0], temp[2], temp[1], Convert.ToDateTime(temp[3].Trim()), temp[4]);
                        tempDictionary.Add(newEmployee.Id, newEmployee);

                        AddEmployee(newEmployee, newEmployee.FirstName, tempList);
                        AddEmployee(newEmployee, newEmployee.LastName, tempList);
                    
                }
            }
            AddTeamMembers(tempDictionary);
            return tempList;
        }
        /// <summary>
        /// Gets a trie of names 
        /// </summary>
        /// <param name="names">a dictionary used to create the trie</param>
        /// <returns>the trie created</returns>
        public static ITrie GetNamesTrie(Dictionary<string,List<Employee>> names)
        {
            ITrie trie = new TrieWithNoChildren();
            foreach(string s in names.Keys)
            {
                trie = trie.Add(s);
            }
            return trie;
        }
    }
}
