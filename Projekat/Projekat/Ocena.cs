using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    internal class Ocena: Serializable
    {
        public Student Student_polozio { get; set; }
        public int Student_polozio_id { get; set; }
        public Predmet Predmet { get; set; }
        public int Predmet_id { get; set; }
        public int BrVrednostOcene { get; set; }
        public string DatumPolaganja { get; set; }

    public Ocena(){ }
    public Ocena(int st, int pr, int oc, string da)
        { 
            Student_polozio_id = st;
            Predmet_id = pr;
            BrVrednostOcene = oc;
            DatumPolaganja = da;
        }

    public string[] ToCSV()
        {
            string[] csvValues =
            {
                Student_polozio_id.ToString(),
                Predmet_id.ToString(),
                BrVrednostOcene.ToString(),
                DatumPolaganja
            };
            return csvValues;
        }
    public void FromCSV(string[] values)
        {
            Student_polozio_id = int.Parse(values[0]);
            Predmet_id = int.Parse(values[1]);
            BrVrednostOcene = int.Parse(values[2]);
            DatumPolaganja = values[3];
        }
    public override string ToString()
        {
            return String.Format("\nPodaci o oceni\n---------------------------------------\nID studenta koji je polozio: " + Student_polozio_id +
                                                                                           "\nID predmeta: " + Predmet_id +
                                                                                           "\nBrojna vrednost ocene: " + BrVrednostOcene +
                                                                                           "\nDatum polaganja: " + DatumPolaganja);
        }

    public void dodajOcenu(Ocena o) { }
    public void izmeniOcenu(int i) { }
    public void obrisiOcenu(int i) { }
    public void prikaziOcenu(int i) { }
    }
}
