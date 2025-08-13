using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biograf_Opg
{
    internal class Biograf
    {
        
        public int AntalSal  { get; set; }
        public int AntalRække  { get; set; }
        public int AntalSæds { get; set; }

        public Biograf(int antalSal, int antalRække, int antalSæde)
        {
            AntalSal = antalSal;
            AntalRække = antalRække;
            AntalSæds = antalSæde;
            
        }
    }
  
}
