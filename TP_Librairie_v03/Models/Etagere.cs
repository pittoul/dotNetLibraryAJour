using System;
using System.Collections.Generic;

namespace TPLibrairiev03
{
    public class Etagere
    {
        public int Id { get; set; }
        public decimal PoidsMaximum { get; set; }
        public int IdSecteur { get; set; }
        public Secteur Secteur { get; set; }
        public ICollection<PositionMagasin> PositionMagasins { get; set; }

    }
}
