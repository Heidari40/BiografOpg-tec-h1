using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biograf_Opg
{
    internal class Film
    {
        public string Titel {get; set;}
        public string Beskrivelse { get; set;}
        public string Instruktør { get; set; }
        public string Genre { get; set;}
        public string Aldersgrænse { get; set;}

        public Film (string title, string beskricelse, string instruktør, string genre, string aldersgrænse)
        {
            Titel = title;
            Beskrivelse = beskricelse;
            Instruktør = instruktør;
            Genre = genre;
            Aldersgrænse = aldersgrænse;
        }
    }
}
