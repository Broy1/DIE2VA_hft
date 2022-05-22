using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherApp.Model
{
    public class Witcher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WitcherId { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        [Range(0, 5000)]
        public int Wage { get; set; }

        public int Age { get; set; }

        public int SchoolId { get; set; }

        public virtual ICollection<Monster> HuntedMonsters { get; set; }

        public virtual ICollection<Human> Friends { get; set; }

        public virtual School School { get; set; }

        public Witcher(string datastring)
        {
            string[] raw = datastring.Split('-');
            WitcherId = int.Parse(raw[0]);
            Name = raw[1];
            Wage = int.Parse(raw[2]);
            SchoolId = int.Parse(raw[3]);
            Age = int.Parse(raw[4]);
        }
    }
}
