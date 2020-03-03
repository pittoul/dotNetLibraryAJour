using System;
using System.Collections.Generic;
using System.Text;
using TPLibrairiev03;

namespace TPLibrairiev03.Abstraction
{
    public interface IEtagere
    {
        void Insert(Etagere Etagere);
        void Update(Etagere Etagere);
        void Remove(Etagere Etagere);
        List<Etagere> GetAllEtageres();
        Etagere FindById(int id);
    }
}