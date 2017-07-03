using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TitleSearch.Controllers
{
    [Route("[controller]")]
    public class TitlesController : Controller
    {
        private Models.TitlesDBConnection _dbConnection = new Models.TitlesDBConnection();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Get()
        {
            return "";
        }

        /* Return information about a specific title */
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "";
        }

        [HttpGet("{searchTerms}")]
        public IEnumerable<string> Get(string terms)
        {
            return _dbConnection.searchForTitles(Models.SearchTerms.getSearchTermList(terms));
            //string[] searchTerms;
            // Convert json into searchTerms
            //return dbConnection.searchForTitle(searchTerms);
        }
    }
}