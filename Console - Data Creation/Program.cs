using System;
using EFDataAccess;
using Domain;

namespace Console___Data_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konzolna aplikacija za dodavanje podataka u bazu posle migracije

            var context = new ProizvodiContext();

            //kategorije
            context.Kategorijas.Add(new Kategorija
            {
                
                Naziv = "Kategorija 1",
                ModifiedOn = null

            });
            context.Kategorijas.Add(new Kategorija
            {

                Naziv = "Kategorija 2",
                ModifiedOn = null

            });
            context.Kategorijas.Add(new Kategorija
            {

                Naziv = "Kategorija 2",
                ModifiedOn = null

            });
            context.SaveChanges();

            //dobavljaci
            context.Dobavljacs.Add(new Dobavljac
            {

                Naziv = "Dobavljac 1",
                ModifiedOn = null

            });
            context.Dobavljacs.Add(new Dobavljac
            {

                Naziv = "Dobavljac 2",
                ModifiedOn = null

            });
            context.Dobavljacs.Add(new Dobavljac
            {

                Naziv = "Dobavljac 3",
                ModifiedOn = null

            });
            context.SaveChanges();

            //proizvodjaci
            context.Proizvodjacs.Add(new Proizvodjac
            {

                Naziv = "Proizvodjac 1",
                ModifiedOn = null

            });
            context.Proizvodjacs.Add(new Proizvodjac
            {

                Naziv = "Proizvodjac 2",
                ModifiedOn = null

            });
            context.Proizvodjacs.Add(new Proizvodjac
            {

                Naziv = "Proizvodjac 3",
                ModifiedOn = null

            });
            context.SaveChanges();

            //proizvodi
            context.Proizvods.Add(new Proizvod
            {

                Naziv = "Proizvod 1",
                Opis = "Opis opis opis",
                Cena = 10000,
                KatId = 1,
                ProId = 1,
                DobId = 1,
                ModifiedOn = null

            });
            context.Proizvods.Add(new Proizvod
            {

                Naziv = "Proizvod 2",
                Opis = "Opis opis opis",
                Cena = 10000,
                KatId = 2,
                ProId = 2,
                DobId = 2,
                ModifiedOn = null

            });
            context.Proizvods.Add(new Proizvod
            {

                Naziv = "Proizvod 3",
                Opis = "Opis opis opis",
                Cena = 10000,
                KatId = 3,
                ProId = 3,
                DobId = 3,
                ModifiedOn = null

            });
            context.SaveChanges();



        }
    }
}
