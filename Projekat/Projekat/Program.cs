using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projekat
{
     class Program
    {
        static void Main(string[] args)
        {
            List<Profesor> profesori = primerProfesora();
            List<Predmet>  predmeti = primerPredmeta(profesori);
            List<Student>  studenti = primerStudenta(predmeti);

            ispisiProfesore(profesori);
            ispisiPredmete(predmeti);
            ispisiStudente(studenti);

            //UTF8Encoding utf8 = new UTF8Encoding();     //Da obezbedimo korektan prikaz srpske ćirilice/latinice
            //Nisam jos uspela da napravim da funkcionise. Treba proguglati
            Console.ReadKey();
            

        }
        static List<Profesor> primerProfesora()
        {
            Adresa ad1 = new Adresa("Bulevar oslobodjenja", "Novi Sad", "Srbija", 13);
            Adresa ad2 = new Adresa("Bulevar oslobodjenja", "Novi Sad", "Srbija", 15);
            Adresa ad3 = new Adresa("Puskinova", "Novi Sad", "Srbija", 23);
            Adresa ad4 = new Adresa("Gogoljeva", "Novi Sad", "Srbija", 43);
            Adresa ad5 = new Adresa("Bulevar Jovana Ducica", "Novi sad", "Srbija", 13);

            // Serijalizacija profesora
            List<Profesor> profesori = new List<Profesor>
            {
                new Profesor("Mikic", "Dusan", "1.2.1977.", 1, "060000888", "mikiduki@gmail.com", 5, "10108564", "Profesor istorije", 24),
                new Profesor("Bulajic", "Snezana", "10.12.1980.", 2, "067901868", "bulaja@gmail.com", 6, "74653901", "Profesor fizike", 18),
                new Profesor("Dimitrieski", "Vladimir", "7.7.1985.", 3, "786478068", "dovla@uns.ac.rs", 7, "348756901", "Profesor baza podataka 1", 19)
            };

            Serializer<Profesor> SerializerProfesora = new Serializer<Profesor>();
            SerializerProfesora.toCSV("profesori", profesori);

            // Deserijalizacija profesora
            profesori = SerializerProfesora.fromCSV("profesori.txt");

            return profesori;
        }
        static List<Predmet> primerPredmeta(List<Profesor> professors)
        {
            // Serijalizacija predmeta
            List<Predmet> predmeti = new List<Predmet>
            {
                new Predmet(1, "Armirani beton 2", SEMESTAR.LETNJI, 1, 1, 8),
                new Predmet(2, "Anatomija", SEMESTAR.ZIMSKI, 2, 2, 9),
                new Predmet(3, "Istorija", SEMESTAR.LETNJI, 2, 3, 4)
            };
            Serializer<Predmet> SerializerPredmeta = new Serializer<Predmet>();
            SerializerPredmeta.toCSV("predmeti.txt", predmeti);

            // Deserijalizacija predmeta
            predmeti = SerializerPredmeta.fromCSV("predmeti.txt");

            // Uvezivanje predmeta sa profesoraima (one to many)
            foreach (Predmet predmet in predmeti)
            {
                Profesor professor = professors.Find(p => p.Id == predmet.Profesor_id);
                professor.Spisak_predmeta.Add(predmet);
                predmet.Profesor_id = professor.Id;
            }
            return predmeti;
        }
        static List<Student> primerStudenta(List<Predmet> subjects)
        {
            Adresa ad1 = new Adresa("Jugoslovenske armije", "Backa Palanka", "Srbija", 20);
            Adresa ad2 = new Adresa("Put kanalizacije", "Puckaros", "Srbija?",32);

            // Serijalizacija studenata
            List<Student> studenti = new List<Student>
            {
                new Student("Dragic", "Goran", "10.10.2001.", 1, "0695006622", "dragon@gmail.com", "RA318/2020", 2020, 3, STATUS.B, 9.73),
                new Student("Kisic", "Milica", "16.4.2002.", 2, "0646778900", "korni@gmail.com", "RA05/2021", 2021, 2, STATUS.S, 7.32)
            };
            Serializer<Student> SerializerStudenata = new Serializer<Student>();
            SerializerStudenata.toCSV("studenti.txt", studenti);

            // Deserijalizacija studenata
            studenti = SerializerStudenata.fromCSV("studenti.txt");


            // Veza student - predment je many to many
            // Serijalizujemo je pomocu klase StudentSubject, koja ima one to many vezu sa oba entiteta

            List<StudentPredmet> PredmetiStudenata = new List<StudentPredmet>
            {
                new StudentPredmet(1, 1),
                new StudentPredmet(2, 2),
                new StudentPredmet(4, 1),
                new StudentPredmet(4, 3)
            };
            Serializer<StudentPredmet> SerializerPredmetaStudenata = new Serializer<StudentPredmet>();
            SerializerPredmetaStudenata.toCSV("studentSubject.txt", PredmetiStudenata);

            PredmetiStudenata = SerializerPredmetaStudenata.fromCSV("studentSubject.txt");


            // Uvezivanje studenata i predmeta
            foreach (StudentPredmet PredmetStudenta in PredmetiStudenata)
            {
                Student student = studenti.Find(s => s.Id == PredmetStudenta.Id_studenta);
                Predmet predmet = subjects.Find(s => s.Sifra == PredmetStudenta.Sifra_predmeta);
                student.Nepolozeni_ispiti.Add(predmet);
                predmet.Studenti_nisu_polozili.Add(student);
            }
            return studenti;
        }

        static void ispisiPredmete(List<Predmet> predmeti)
        {
            Console.WriteLine("### Predmeti ###");
            foreach (Predmet s in predmeti)
            {
                string text = "ID: " + s.Sifra.ToString() + ", ";
                text += "NAME: " + s.Naziv + ", ";
                text += "ESPB: " + s.ESPB + ", ";
                text += "STUDENTI KOJI SU POLOZILI: ";
                foreach (Student st in s.Studenti_jesu_polozili)
                {
                    text += st.Broj_indexa + ", ";
                }
                text += "STUDENTI KOJI NISU POLOZILI: ";
                foreach (Student st in s.Studenti_nisu_polozili)
                {
                    text += st.Broj_indexa + ", ";
                }
                Console.WriteLine(text);
            }
        }
        static void ispisiStudente(List<Student> studenti)
        {
            Console.WriteLine("### Studenti ###");

            foreach (Student s in studenti)
            {
                Console.WriteLine(s);
            }
        }
        static void ispisiProfesore(List<Profesor> profesori)
        {
            Console.WriteLine("### Profesori ###");

            foreach (Profesor p in profesori)
            {
                string text = "ID: " + p.Broj_licne_karte + ", ";
                text += "NAME: " + p.Ime + ", ";
                text += "SUBJECTS: ";
                foreach (Predmet s in p.Spisak_predmeta)
                {
                    text += s.Naziv + ", ";
                }
                Console.WriteLine(text);
            }
        }
    }
}
