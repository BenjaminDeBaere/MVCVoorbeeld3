using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCVoorbeeld3.Models;

namespace MVCVoorbeeld3.Services
{
    public class HoofdZetelService
    {
        public HoofdZetel Read()
        {
            return new HoofdZetel
            {
                Straat = "Keizerslaan",
                HuisNr = "11",
                PostCode = "1000",
                Gemeente = "Brussel"
            };
        }
    }
}