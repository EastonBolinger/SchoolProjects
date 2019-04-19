/* Employee.cs
 * Author: Easton Bolinger
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.ReportingStructureViewer
{
    /// <summary>
    /// this class handles the assigning of values for the output 
    /// </summary>
    public class Employee : IComparable<Employee>
    {
        /// <summary>
        /// private field holding the completed display name 
        /// </summary>
        private string _displayName;
        /// <summary>
        /// string holding the person's ID number
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// string holding the person's first name 
        /// </summary>
        public string FirstName { get; }
        /// <summary>
        /// string holding the person's last name 
        /// </summary>
        public string LastName { get; }
        /// <summary>
        /// DateTime holding the person's start date 
        /// </summary>
        public DateTime StartDate { get; }
        /// <summary>
        /// a SortedSet<Employee> that holds their direct reports 
        /// </summary>
        public SortedSet<Employee> DirectReports { get; }
        /// <summary>
        /// string holding the ID number of their manager 
        /// </summary>
        public string ManagerID { get; }
        /// <summary>
        /// public constructor for the Employee class 
        /// </summary>
        /// <param name="id">unformated id number for person</param>
        /// <param name="firstName">unformated first name for person</param>
        /// <param name="lastName">unformated last name for person</param>
        /// <param name="startDate">unformated start date for person</param>
        /// <param name="managerID">unformated manager ID number</param>
        public Employee(string id, string firstName, string lastName, DateTime startDate, string managerID)
        {
            Id = id.Trim();
            string tempFirst = firstName.ToLower().Trim();
            FirstName = tempFirst;
            string tempLast = lastName.ToLower().Trim();
            LastName = tempLast;
            DateTime tempStart = startDate;
            StartDate = tempStart;
            string tempManager = managerID.Trim();
            ManagerID = tempManager;

            DirectReports = new SortedSet<Employee>();
            StringBuilder sb = new StringBuilder();
            sb.Append(tempLast + ", " + tempFirst);
            _displayName = sb.ToString().ToUpper();
        }
        /// <summary>
        /// custom toString for the completed user profile elements 
        /// </summary>
        /// <returns>the formated string</returns>
        public override string ToString()
        {
            return _displayName;
        }
        /// <summary>
        /// custom compareTo to handle the comparison to formated display
        /// </summary>
        /// <param name="e">the employee being passed in</param>
        /// <returns>the result of the compare to</returns>
        public int CompareTo(Employee e)
        {
            int result = _displayName.CompareTo(e._displayName);
            return result;
        }
    }
}
