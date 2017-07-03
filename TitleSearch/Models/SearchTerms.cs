using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TitleSearch.Models
{
    public class SearchTerms
    {
        public static IEnumerable<string> getSearchTermList(string searchTerms)
        {
            return searchTerms.Split('+');
        }
    }
}
