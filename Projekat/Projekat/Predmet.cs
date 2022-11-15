using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum SEMESTAR {LETNJI, ZIMSKI};

namespace Projekat
{
    internal class Predmet : Serializable
    {
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public SEMESTAR Semestar { get; set; }
        public int GodinaIzvodjenja { get; set; }
        public int Profesor_id { get; set; }
        public Profesor Profesor { get; set; }
        public int ESPB { get; set; }
        public List<Student> Studenti_jesu_polozili { get; set; }
        public List<Student> Studenti_nisu_polozili { get; set; }

    public Predmet()
        {
            Studenti_jesu_polozili = new List<Student>();
            Studenti_nisu_polozili = new List<Student>();
        }
    public Predmet(int si, string na, SEMESTAR se, int go, int pr, int es)
        {
            Sifra = si;
            Naziv = na;
            Semestar = se;
            GodinaIzvodjenja = go;
            Profesor_id = pr;
            ESPB = es;
            Studenti_jesu_polozili = new List<Student>();
            Studenti_nisu_polozili = new List<Student>();
        }

    public string[] ToCSV()
        {
            string s;
            if (Semestar == SEMESTAR.LETNJI) { s = "Letnji"; }
            else { s = "Zimski"; }

            string[] csvValues =
            {
                Sifra.ToString(),
                Naziv,
                s,
                GodinaIzvodjenja.ToString(),
                Profesor_id.ToString(),
                ESPB.ToString()

            };
            return csvValues;
        }
    public void FromCSV(string[] values)
        {
            Sifra = int.Parse(values[0]);
            Naziv = values[1];
            if (values[2] == "Letnji") { Semestar = SEMESTAR.LETNJI; }
            else { Semestar = SEMESTAR.ZIMSKI; }

            GodinaIzvodjenja = int.Parse(values[3]);
            Profesor_id = int.Parse(values[4]);
            ESPB = int.Parse(values[5]);
        }
    public override string ToString()
        {
            string s;
            if (Semestar == SEMESTAR.LETNJI) { s = "Letnji"; }
            else { s = "Zimski";}
            return String.Format("\nPODACI O PREDMETU\n-------------------------------------\nSifra: " + Sifra +
                                                                                           "\nNaziv: " + Naziv +
                                                                                           "\nSemestar: " + s +
                                                                                           "\nGodina: " + GodinaIzvodjenja +
                                                                                           "\nID profesora: " + Profesor_id +
                                                                                           "\nESPB: " + ESPB);
        }

    public void dodajPredmet(Predmet p) { }
    public void izmeniPredmet(int i) { }
    public void obrisiPredmet(int i) { }
    public void prikaziPredmet(int i) { }
    }
}
