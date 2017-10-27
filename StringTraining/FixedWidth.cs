using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StringTraining
{
    public static class FixedWidth
    {
        public static List<String> GetFormattedTable()
        {           
            var source = new List<string>();
            source.Add("Pub Date,Title,Authors");
            source.Add("28 / 11 / 2008,Learning C# 3.0,Jesse Liberty & Brian MacDonald");
            source.Add("16 / 09 / 2013,Head First C#,Jennifer Greene & Andrew Stellman");
            source.Add("27 / 10 / 2015,Learn C# in One Day and Learn It Well: C# for Beginners with Hands-on Project: Volume 3,Jamie Chan");
            var table = new List<TableRow>();
            for(int i = 1; i<source.Count;i++)
            {
                table.Add(new TableRow(source[i]));
            }
            var fixedWidthTable = new List<string>();
            List<string> formatedTable = new List<string>();
            formatedTable.Add("| Pub Date    |                       Title | Authors                         |");
            formatedTable.Add(FormattedTableRow.GetLine());
            formatedTable.Add(FormattedTableRow.getFormattedTableRow((table[0])));
            formatedTable.Add(FormattedTableRow.getFormattedTableRow((table[1])));
            formatedTable.Add(FormattedTableRow.getFormattedTableRow((table[2])));
            return formatedTable;

        }

        
    }

    public static class FormattedTableRow
    {
        const int firstColwidth = 11;
        const int secondColWidth = 27;
        const int thirdColWidth = 31;

        public static string GetLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('|');
            for (int i = 0; i < firstColwidth + secondColWidth + thirdColWidth + 8; i++)
            {
                sb.Append('=');
            }
            sb.Append('|');
            return sb.ToString();
        }

        public static string getFormattedTableRow(TableRow tableRow)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('|');
            sb.Append(' ');
            sb.Append(TruncateOrPad(tableRow.PublicationDate,firstColwidth,false));
            sb.Append(' ');
            sb.Append('|');
            sb.Append(' ');
            sb.Append(TruncateOrPad(tableRow.Title, secondColWidth, true));
            sb.Append(' ');
            sb.Append('|');
            sb.Append(' ');
            sb.Append(TruncateOrPad(tableRow.Authors, thirdColWidth, false));
            sb.Append(' ');
            sb.Append('|');
            return sb.ToString();
        }

        private static string TruncateOrPad(string s, int maxWidth, bool PadLeft)
        {
            if (s.Length > maxWidth)
            {
                s = s.Substring(0, maxWidth - 3);
                s = s + "...";
            }
            else
            {
                if (PadLeft)
                {
                    s=s.PadLeft(maxWidth);
                }
                else
                {
                    s = s.PadRight(maxWidth);
                }
                
            }
            return s;
        }
    }

    public class TableRow
    {
        public string PublicationDate;
        public string Title;
        public string Authors;

        public TableRow(string publicationDate, string title, string authors)
        {
            PublicationDate = publicationDate;
            Title = title;
            Authors = authors;
        }

        public TableRow(string csv)
        {
            var x = csv.Split(',');
            if (x.Length != 3)
            {
                throw new Exception();
            }
            PublicationDate = DateTime.Parse(x[0]).ToString("dd MMM yyyy");
            Title = x[1];
            Authors = x[2];
        }
    }
}
