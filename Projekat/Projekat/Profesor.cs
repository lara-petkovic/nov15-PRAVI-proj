using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class Profesor : Serializable
    {
        public int Id { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string Datum_rodjenja { get; set; }
        public Adresa Adresa_stanovanja { get; set; }
        public int Adresa_id { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public Adresa Adresa_kancelarije { get; set; }
        public int Adresa_kancelarije_id { get; set; }
        public string Broj_licne_karte { get; set; }
        public string Zvanje { get; set; }
        public int Godine_staza { get; set; }
        public List<Predmet> Spisak_predmeta { get; set; }

    public Profesor() { Spisak_predmeta = new List<Predmet>(); }
    public Profesor(string pr, string im, string da, int ad_id , string te, string em, int adk, string br, string zv, int go)
        {
            Prezime = pr;
            Ime = im;
            Datum_rodjenja = da;
            Adresa_id= ad_id;
            Telefon = te;
            Email = em;
            Adresa_kancelarije_id= adk;
            Broj_licne_karte = br;
            Zvanje = zv;
            Godine_staza = go;
            Spisak_predmeta = new List<Predmet>();
        }
        
    public string[] ToCSV()
        {
            string[] csvValues =
            {
                Prezime,
                Ime,
                Datum_rodjenja,
                Adresa_id.ToString(),
                Telefon,
                Email,
                Adresa_kancelarije_id.ToString(),
                Broj_licne_karte,
                Zvanje,
                Godine_staza.ToString()
            };
            return csvValues;
        }
    public void FromCSV(string[] values)
        {
            Prezime = values[0];
            Ime = values[1];    
            Datum_rodjenja = values[2]; 
            Adresa_id = int.Parse(values[3]);
            Telefon = values[4];
            Email = values[5];
            Adresa_kancelarije_id = int.Parse(values[6]);
            Broj_licne_karte = values[7];
            Zvanje = values[8];
            Godine_staza = int.Parse(values[9]);
        }
    public override string ToString()
        {
            return String.Format("\nPODACI O PROFESORU\n------------------------------------\nPrezime: " + Prezime +
                                                                                           "\nIme: " + Ime +
                                                                                           "\nDatum rodjenja: " + Datum_rodjenja +
                                                                                           "\nID adrese: " + Adresa_id,
                                                                                           "\nTelefon: " + Telefon +
                                                                                           "\nemail: " + Email +
                                                                                           "\nID adrese kancelarije: " + Adresa_kancelarije_id,
                                                                                           "\nBroj licne karte: " + Broj_licne_karte +
                                                                                           "\nZvanje: " + Zvanje +
                                                                                           "\nGodine staza: " + Godine_staza +                                                                                          
                                                                                           "\nSpisak predmeta: " + Spisak_predmeta);
        }

    public void dodajProfesora(Profesor p) { }
    public void izmeniProfesora(int i) { }
    public void obrisiProfesora(int i) { }
    public void prikaziProfesora(int i) { }
    }
}
