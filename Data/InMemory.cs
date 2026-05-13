using DrugiPutKlk.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DrugiPutKlk.Data
{
    public class InMemory
    {

        public static List<Student> Students { get; set; }= new List<Student>() {
        new Student{FirstName="Marko", LastName="Markovic", Index="2022/0001" },
         new Student { FirstName = "Ana", LastName = "Anic", Index= "2020/0002" },
            new Student { FirstName = "Petar", LastName = "Petrovic", Index = "2020/0003" },
            new Student { FirstName = "Jovana", LastName = "Jovanovic", Index = "2020/0004" },
            new Student { FirstName = "Nikola", LastName = "Nikolic", Index  = "2020/0005" },
            new Student { FirstName = "Milica", LastName = "Milic", Index = "2020/0006" },
            new Student { FirstName = "Stefan", LastName = "Stefanovic", Index = "2020/0007" },
            new Student { FirstName = "Ivana", LastName = "Ivic", Index = "2020/0008" },
            new Student { FirstName = "Luka", LastName = "Lukic", Index = "2020/0009" },
            new Student { FirstName = "Teodora", LastName = "Teodorovic", Index = "2020/0010" },
            new Student { FirstName = "Milos", LastName = "Milosevic", Index = "2020/0011" },
            new Student { FirstName = "Sara", LastName = "Saric", Index = "2020/0012" },
            new Student { FirstName = "Vuk", LastName = "Vukovic", Index = "2020/0013" },
            new Student { FirstName = "Katarina", LastName = "Katic", Index = "2020/0014" },
            new Student { FirstName = "Dusan", LastName = "Dusanic", Index= "2020/0015" }



        };

        public static List<Predmet> Predmeti { get; set; } = new() {
        new Predmet{Sifra="CS101", Naziv="Programiranje", Espb=6},
        new Predmet{Sifra="DB101", Naziv="Baze podataka", Espb=6},
        new Predmet{Sifra="WEB101", Naziv="Web programiranje", Espb=5},
        new Predmet{Sifra="123", Naziv="Programiranje", Espb=5},
        };
        public static List<PolozenIspit> PolozeniIspiti { get; set; } = new()
{
    new PolozenIspit { Student = Students[0], Predmet = Predmeti[0], Grade = 10 },
    new PolozenIspit { Student = Students[0], Predmet = Predmeti[1], Grade = 9 },

    new PolozenIspit { Student = Students[1], Predmet = Predmeti[0], Grade = 10 },
    new PolozenIspit { Student = Students[1], Predmet = Predmeti[1], Grade = 10 },
    new PolozenIspit { Student = Students[1], Predmet = Predmeti[2], Grade = 9 },

    new PolozenIspit { Student = Students[2], Predmet = Predmeti[0], Grade = 8 },
    new PolozenIspit { Student = Students[2], Predmet = Predmeti[1], Grade = 9 },

    new PolozenIspit { Student = Students[3], Predmet = Predmeti[0], Grade = 7 },
    new PolozenIspit { Student = Students[3], Predmet = Predmeti[2], Grade = 8 },

    new PolozenIspit { Student = Students[4], Predmet = Predmeti[0], Grade = 6 },
    new PolozenIspit { Student = Students[4], Predmet = Predmeti[1], Grade = 7 },

    new PolozenIspit { Student = Students[5], Predmet = Predmeti[0], Grade = 10 },
    new PolozenIspit { Student = Students[5], Predmet = Predmeti[2], Grade = 10 },

    new PolozenIspit { Student = Students[6], Predmet = Predmeti[1], Grade = 9 },
    new PolozenIspit { Student = Students[6], Predmet = Predmeti[2], Grade = 8 },

    new PolozenIspit { Student = Students[7], Predmet = Predmeti[0], Grade = 9 },
    new PolozenIspit { Student = Students[7], Predmet = Predmeti[1], Grade = 10 },

    new PolozenIspit { Student = Students[8], Predmet = Predmeti[2], Grade = 7 },

    new PolozenIspit { Student = Students[9], Predmet = Predmeti[0], Grade = 10 },
    new PolozenIspit { Student = Students[9], Predmet = Predmeti[1], Grade = 10 },
    new PolozenIspit { Student = Students[9], Predmet = Predmeti[2], Grade = 10 },

    new PolozenIspit { Student = Students[10], Predmet = Predmeti[0], Grade = 8 },
    new PolozenIspit { Student = Students[10], Predmet = Predmeti[1], Grade = 8 },

    new PolozenIspit { Student = Students[11], Predmet = Predmeti[2], Grade = 9 }
};

    }
}
