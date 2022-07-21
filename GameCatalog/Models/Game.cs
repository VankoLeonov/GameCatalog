using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCatalog
{
    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Developer { get; set; }

        public string Genre { get; set; }

        public int YearOfRelease { get; set; }

        public int Rating { get; set; }

        public int Price { get; set; }
    }
}
