using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    internal class Katedra : Serializable
    {
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public string Sef { get; set; }
        public List<Profesor> Profesori { get; set; }

    public Katedra() { Profesori = new List<Profesor>(); }
    public Katedra(int si, string na, string se)
        {
            Sifra = si;
            Naziv = na;
            Sef = se;
            Profesori = new List<Profesor>();
        }

    public string[] ToCSV()
        {
            string[] csvValues =
            {
                Sifra.ToString(),
                Naziv,
                Sef
            };
            return csvValues;
        }
    public void FromCSV(string[] values)
        {
            Sifra = int.Parse(values[0]);
            Naziv = values[1];
            Sef = values[2];
        }
    public override string ToString()
    {
        return String.Format("\nPodaci o katedri\n--------------------------------------\nSifra: " + Sifra +
                                                                                       "\nNaziv: " + Naziv +
                                                                                       "\nSef: " + Sef +
                                                                                       "\nProfesori: " + Profesori);
    }

    public void dodajkatedru(Katedra k) { }
    public void izmeniKatedru(int i) { }
    public void obrisiKatedru(int i) { }
    public void prikaziKatedru(int i) { }
    }
}
