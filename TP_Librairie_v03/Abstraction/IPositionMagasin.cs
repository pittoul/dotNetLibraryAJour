using System;
using System.Collections.Generic;
using System.Text;
using TPLibrairiev03;

namespace TPLibrairiev03.Abstraction
{
    public interface IPositionMagasin
    {
        void Insert(PositionMagasin PositionMagasin);
        void Update(PositionMagasin PositionMagasin);
        void Remove(PositionMagasin PositionMagasin);
        List<PositionMagasin> GetAllPositions();
        PositionMagasin FindById(int idArticle, int idEtagere);
    }
}