using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgift2.DataStructures
{
    // This class is for saving search results.
    internal class SearchResult
    {
        internal string Document { get; set; }

        public int Count { get; set; }

        internal string SearchWord { get; set; }

    }
}
