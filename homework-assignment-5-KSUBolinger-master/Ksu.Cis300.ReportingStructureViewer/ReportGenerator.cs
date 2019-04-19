/* ReportGenerator.cs
 * Author: Easton Bolinger
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ksu.Cis300.ReportingStructureViewer
{
    /// <summary>
    /// this class generates the report
    /// </summary>
    public class ReportGenerator
    {
        /// <summary>
        /// generates the list of items 
        /// </summary>
        /// <param name="e">the employee</param>
        /// <param name="depth">the total depth requested by user in ui</param>
        /// <param name="maxDepth">the max depth allowed</param>
        /// <param name="sw">the streamwriter used to compile all data</param>
        /// <returns>total length of report</returns>
        private static int GenerateListItem(Employee e,int depth,int maxDepth, StreamWriter sw)
        {
            if (depth <= maxDepth)
            {
                sw.WriteLine("<li>");
                sw.WriteLine(e.ToString() + " (" + e.Id + ") - Started " + e.StartDate.ToString("d"));
                sw.WriteLine("<ul>");
            }
            int count = 1;
            foreach(Employee i in e.DirectReports)
            {
                count += GenerateListItem(i, depth + 1, maxDepth, sw);
            }
            if (depth <= maxDepth)
            {
                sw.WriteLine("</ul>");
                sw.WriteLine(e.ToString() + " Driect Reports: " + e.DirectReports.Count + "; Total Team Member: " + count);
                sw.WriteLine("</li>");
            }
            return count;
        }
        /// <summary>
        /// generates the entire report
        /// </summary>
        /// <param name="e">employee being used</param>
        /// <param name="maxDepth">maximum depth allowed</param>
        /// <param name="fileName">the file saving to</param>
        public static void GenerateReport(Employee e, int maxDepth, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<title>Team Structure Report</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<style>");
                sw.WriteLine("li {");
                sw.WriteLine("list-style-type: square;");
                sw.WriteLine("}");
                sw.WriteLine("</style>");
                sw.WriteLine("Team Structure for: <strong>" + e.ToString() + "</strong>");
                sw.WriteLine("<ul>");
                GenerateListItem(e, 0, maxDepth, sw);
                sw.WriteLine("</ul>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
        }
    }
}
