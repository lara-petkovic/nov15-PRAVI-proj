using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum STATUS { B, S };

namespace Projekat
{
    internal class Student: Serializable
    {
        public int Id { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string Datum_rodjenja { get; set; }
        public int Adresa_id { get; set; }
        public Adresa Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Broj_indexa { get; set; }
        public int Godina_upisa { get; set; }
        public int Trenutna_godina_studija { get; set; }
        public STATUS Status { get; set; }
        public double Prosecna_ocena { get; set; }
        public List<Predmet> Polozeni_ispiti { get; set; }   //spisak Ocena
        public List<Predmet> Nepolozeni_ispiti { get; set; }

        public Student() 
        {
            Polozeni_ispiti = new List<Predmet>();
            Nepolozeni_ispiti = new List<Predmet>();
        }
        public Student(string pr, string im, string dr, int ad, string te, string em, string bi, int gu, int tg, STATUS st, double pro)
        {
            Prezime = pr;
            Ime = im;
            Datum_rodjenja = dr;
            Adresa_id = ad;
            Telefon = te;
            Email = em;
            Broj_indexa = bi;
            Godina_upisa = gu;
            Trenutna_godina_studija = tg;
            Status = st;
            Prosecna_ocena = pro;
            Polozeni_ispiti = new List<Predmet>();
            Nepolozeni_ispiti = new List<Predmet>();
        }

        public string[] ToCSV()
        {
            string s;
            if(Status == STATUS.B)
            {
                s = "Budzet";
            }
            else
            {
                s = "Samofinansiranje";
            }
            string[] csvValues =
            {
                Prezime,
                Ime,
                Datum_rodjenja,
                Adresa_id.ToString(),
                Telefon,
                Email,
                Broj_indexa,
                Godina_upisa.ToString(),
                Trenutna_godina_studija.ToString(),
                s,
                Prosecna_ocena.ToString()
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
            Broj_indexa = values[6];
            Godina_upisa = int.Parse(values[7]);
            Trenutna_godina_studija = int.Parse(values[8]);
            if(values[9] == "Budzet")
            {
                Status = STATUS.B;
            }
            else
            {
                Status = STATUS.S;
            }
            Prosecna_ocena = double.Parse(values[10]);
        }
        public override string ToString()
        {
            return String.Format("\nPODACI O STUDENTU\n-------------------------------------\nPrezime: " + Prezime +
                                                                                           "\nIme: " + Ime +
                                                                                           "\nDatum rodjenja: " + Datum_rodjenja +
                                                                                           "\nID adrese: " + Adresa_id +
                                                                                           "\nTelefon: " + Telefon +
                                                                                           "\nemail: " + Email +
                                                                                           "\nBroj indeksa: " + Broj_indexa +
                                                                                           "\nGodina upisa: " + Godina_upisa +
                                                                                           "\nTrenutna godina studija: " + Trenutna_godina_studija +
                                                                                           "\nStatus: " + Status +
                                                                                           "\nProsecna ocena: " + Prosecna_ocena +
                                                                                           "\nSpisak polozenih ispita: " + Polozeni_ispiti +
                                                                                           "\nSpisak neppolozenih ispita: " + Nepolozeni_ispiti);
        }
    }
}
