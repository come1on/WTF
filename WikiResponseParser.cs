using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTF_WIKI_TRANS_FUN
{
    public class WikiResponseParser
    {
        public WikiResponse Parse(string Website)
        {
            char[] Brackets = {'[',']','"'};
            string WikiresponseString = null;
            WikiResponse response = new WikiResponse();
            string[] WikiresponseStringReplace = Website.Split(",");

            foreach (string blabla in WikiresponseStringReplace) 
            {
                string ParsedValue = blabla;
                ParsedValue = ParsedValue.TrimStart(Brackets);
                ParsedValue = ParsedValue.TrimEnd(Brackets);
                WikiresponseString = ParsedValue;
            }
            response.URL = WikiresponseString;
           
            return response;
        }
    }
}
