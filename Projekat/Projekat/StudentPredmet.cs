using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class StudentPredmet : Serializable
    {
        public int Id_studenta { get; set; }

        public int Sifra_predmeta { get; set; }

        public StudentPredmet() { }

        public StudentPredmet(int student, int predmet)
        {
            Id_studenta = student;
            Sifra_predmeta = predmet;
        }

        public void FromCSV(string[] values)
        {
            Id_studenta = int.Parse(values[0]);
            Sifra_predmeta = int.Parse(values[1]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id_studenta.ToString(),
                Sifra_predmeta.ToString()
            };
            return csvValues;
        }
    }
}
