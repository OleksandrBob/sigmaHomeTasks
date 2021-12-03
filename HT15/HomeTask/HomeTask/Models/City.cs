using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeTask.Models
{
    public class City
    {
        public long Id { get; set; }
        public string Name  { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }

        [NotMapped]
        public string MyCountry { get { return this.Country?.Name; } }
    }
}
