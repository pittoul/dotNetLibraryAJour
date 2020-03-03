using LibrairieDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPLibrairiev03.Abstraction;

namespace TPLibrairiev03.EFClasses
{
    // le implement est ici représenté par ':'
    public class EtagereRepoEF : IEtagere
    {
        public LibrairieDbContext db = new LibrairieDbContext();

        public Etagere FindById(int id)
        {
            Etagere etagere = new Etagere();
            try
            {

                etagere = db.Etageres.First(i => i.Id == id);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Oups, erreur dans FindById mais on continue !");
                etagere.Id = 0;
            }
            //finally
            //{
            //}

            return etagere;
        }


        public List<Etagere> GetAllEtageres()
        {
            return db.Etageres.ToList();
        }

        public void Insert(Etagere etagere)
        {
            db.Etageres.Add(etagere);
            db.SaveChanges();
        }

        public void Remove(Etagere etagere)
        {
            db.Remove(etagere);
            db.SaveChanges();
        }


        public void Update(Etagere etagere)
        {
            db.Update(etagere);
            db.SaveChanges();


        }
    }
}
