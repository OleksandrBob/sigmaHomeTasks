using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTask.Models
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }

        public Country()
        {
            this.Cities = new HashSet<City>();
        }
    }
}
