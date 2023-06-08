using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASender.Model
{
    public class SearchType
    {
        public List<string> divLocations { get; set; }
        public List<string> headerTexts { get; set; }

        public SearchType(List<string> divLocations, List<string> headerTexts)
        {
            this.divLocations = divLocations;
            this.headerTexts = headerTexts;
        }
    }
    public class LinkedInDivs
    {
        public Dictionary<string, SearchType> searchTypes = new Dictionary<string, SearchType>();

        public LinkedInDivs()
        {
            searchTypes["people"] = new SearchType(new List<string>()
            {
                "div/div[1]/div/span[1]/span/a/span/span[1]",
                "div/div[2]/div[1]",
                "div/div[2]/div[2]",
                "div/div[1]/div/span[1]/span/span/div/span/span[1]"
            },
            new List<string>()
            {
                "Name",
                "Job Position",
                "Location",
                "Connections",
                "Contact Link"
            });

            searchTypes["companies"] = new SearchType(new List<string>()
            {
                "div[1]/div[1]/div/span/span/a",
                "div[1]/div[2]/div[1]",
                "div[1]/div[2]/div[2]",
                "div[2]/p"
            },
            new List<string>()
            {
                "Name",
                "Type",
                "Followers",
                "Description"
            });

            searchTypes["products"] = new SearchType(new List<string>()
            {
                "div[1]/div[1]/div/span/span/a",
                "div[1]/div[2]/div[1]",
                "div[1]/div[2]/div[2]",
                "div[2]/p"
            },
            new List<string>()
            {
                "Name",
                "Product Type",
                "Made By",
                "Description"
            });

            searchTypes["groups"] = new SearchType(new List<string>()
            {
                "div[1]/div[1]/div/span/span/a",
                "div[1]/div[2]/div",
                "div[2]/p"
            },
            new List<string>()
            {
                "Name",
                "Members",
                "Description"
            });

            searchTypes["services"] = new SearchType(new List<string>()
            {
                "div[1]/div[1]/div/span[1]/span/a/span/span[1]",
                "div[1]/div[2]/div[1]",
                "div[1]/div[2]/div[2]",
                "div[2]/p"
            },
           new List<string>()
           {
                "Name",
                "Title(s)",
                "Location",
                "Skills"
           });

           searchTypes["events"] = new SearchType(new List<string>()
            {
                "div[1]/div[1]/div/span/span/a",
                "div[1]/div[2]/div[1]",
                "div[1]/div[2]/div[2]",
                "div[2]/p",
                "div[3]/div/div[2]/span"
            },
           new List<string>()
           {
                "Name",
                "Time",
                "Made By",
                "Description",
                "Attendees"
           });

            searchTypes["courses"] = new SearchType(new List<string>()
             {
                "div[1]/div[1]/div/span/span/a/strong",
                "div[1]/div[2]/div[1]",
                "div[1]/div[2]/div[2]",
                "div[2]/div/div/span"
            },
           new List<string>()
           {
                "Name",
                "Length",
                "Made By",
                "Viewers"
           });

          searchTypes["schools"] = new SearchType(new List<string>()
            {
                "div[1]/div[1]/div/span/span/a",
                "div[1]/div[2]/div[1]",
                "div[1]/div[2]/div[2]",
                "div[2]/p"
            },
          new List<string>()
          {
                "Name",
                "Location",
                "Students",
                "Description"
          });

          searchTypes["jobs"] = new SearchType(new List<string>()
           {
                "",
                "",
                "",
                ""
            },
          new List<string>()
          {
                "Name",
                "Company",
                "Location",
                "Job Type",
                "Posted",
                "Applicants",
                "Job Duration",
                "Employees",
                "Skills Required"
          });

        }
    }
}
