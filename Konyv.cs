using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyv
{
    public class Konyv
    {
        public string cim { get; set; }
        public List<string> szerzok { get; set; }
        public Kiado kiado { get; set; }
        public int oldalszam { get; set; }
        public List<string> kategoriak { get; set; }
        public int ar { get; set; }
        public bool elkeszult { get; set; }

        public override string ToString()
        {
            return $"{cim} - Szerzők: {string.Join(", ", szerzok)} " +
                   $"({kiado.nev}, {kiado.orszag}, {kiado.kiadas_ev}) " +
                   $"Oldalszám: {oldalszam} " +
                   $"Kategóriák: [{string.Join(", ", kategoriak)}] " +
                   $"Ára: {ar} Ft " +
                   $"Elkészült: {(elkeszult ? "Igen" : "Nem")}";
        }
    }
}
