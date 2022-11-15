using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class Adresa : Serializable
    {
        public string Ulica { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public int Broj { get; set; }

    public Adresa() { }
    public Adresa(string ul, string gr, string dr, int br)
            {
                Ulica = ul;
                Grad = gr;
                Drzava = dr;
                Broj = br;
            }

    public string[] ToCSV()
            {
                string[] csvValues =
                {
                Ulica,
                Grad,
                Drzava,
                Broj.ToString()
                };
                return csvValues;
            }
    public void FromCSV(string[] values)
            {
                Ulica = values[0];
                Grad = values[1];
                Drzava = values[2];
                Broj = int.Parse(values[3]);
            }
    public override string ToString()
    {
            return String.Format("\nPodaci o adresi\n---------------------------------------\nUlica: " + Ulica +
                                                                                           "\nGrad: " + Grad +
                                                                                           "\nDrzava: " + Drzava +
                                                                                           "\nBroj: " + Broj);
    }

    public void dodajAdresu(Adresa ad) { }
    public void izmeniAdresu(int i) { }
    public void obrisiAdresu(int i) { }
    public void prikaziAdresu(int i) {
        }
    }
}

