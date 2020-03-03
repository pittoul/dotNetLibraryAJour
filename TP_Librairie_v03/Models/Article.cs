using System;
using System.Collections.Generic;

namespace TPLibrairiev03
{
    public class Article
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string SKU { get; set; }
        public DateTime DateSortie { get; set; }
        public decimal PrixInitial { get; set; }
        public decimal Poids { get; set; }
        public ICollection<PositionMagasin> PositionMagasins { get; set; }
    }
}
