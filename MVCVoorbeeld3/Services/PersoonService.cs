using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCVoorbeeld3.Models;

namespace MVCVoorbeeld3.Services
{
    public class PersoonService
    {
        private static Dictionary<int, Persoon> personen = new Dictionary<int, Persoon>
        {
            {
                1, new Persoon {ID=1, Voornaam="Jesse", Familienaam="James",
                    Score =5, Wedde=1000, Passwoord="123", Geboren=new DateTime(1966,1,1),
                    Gehuwd =true, Opmerkingen="Schurk van het Wilde Westen", Geslacht=Geslacht.Man }
            },
            {
                2, new Persoon {ID=2, Voornaam="Jane", Familienaam="Calamity",
                    Score =4, Wedde=2000 , Passwoord="123", Geboren = new DateTime(1966,2,2),
                    Gehuwd =true, Opmerkingen="Martha Jane Cannary", Geslacht=Geslacht.Vrouw}
            },
            {
                3, new Persoon {ID=3, Voornaam="Billy", Familienaam="The Kid",
                    Score =5, Wedde=3000, Passwoord="123", Geboren = new DateTime(1966,3,3),
                    Gehuwd =false, Opmerkingen="William H. Bonney", Geslacht=Geslacht.Man }
            },
            {
                4, new Persoon {ID=4, Voornaam="Sarah", Familienaam="BernHardt",
                    Score =3, Wedde=4000, Passwoord="123", Geboren= new DateTime(1966,4,4),
                    Gehuwd =false, Opmerkingen="Rosine Bernardt", Geslacht=Geslacht.Vrouw }
            }
        };

        public List<Persoon> FindAll()
        {
            return personen.Values.ToList();
        }
        public Persoon FindById(int id)
        {
            return personen[id];
        }

        public void Delete(int id)
        {
            personen.Remove(id);
        }
        public void Opslag(decimal vanWedde, decimal totWedde, decimal percentage)
        {
            foreach (var p in from persoon in personen.Values where persoon.Wedde >= vanWedde && persoon.Wedde <= totWedde select persoon)
            {
                p.Wedde += p.Wedde * percentage / 100;
            }
        }

        public List<Persoon> VanTotWedde(decimal van, decimal tot)
        {
            return (from persoon in personen.Values where persoon.Wedde >= van && persoon.Wedde <= tot select persoon).ToList();
        }
    }
}