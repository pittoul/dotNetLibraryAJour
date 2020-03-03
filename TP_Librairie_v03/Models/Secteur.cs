using System;
using System.Collections.Generic;

namespace TPLibrairiev03
{
    public class Secteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Etagere> Etageres { get; }
    }
}
