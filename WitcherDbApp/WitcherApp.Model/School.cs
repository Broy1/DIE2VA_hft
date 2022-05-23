using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WitcherApp.Model
{
    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Witcher> Witchers { get; set; }

        public School()
        {
            Witchers = new HashSet<Witcher>();
        }

        public School(string datastring)
        {
            string[] raw = datastring.Split('-');
            SchoolId = int.Parse(raw[0]);
            Name = raw[1];
            Witchers = new HashSet<Witcher>();
        }
    }
}
