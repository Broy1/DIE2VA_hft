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
    public class Monster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MonsterId { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        public int Bounty { get; set; }

        [JsonIgnore]
        public virtual ICollection<Witcher> HuntedBy { get; set; }

        [JsonIgnore]
        public virtual ICollection<Human> KilledHumans { get; set; }


        public Monster()
        {

        }
        public Monster(string datastring)
        {
            string[] raw = datastring.Split('-');
            MonsterId = int.Parse(raw[0]);
            Name = raw[1];
            Bounty = int.Parse(raw[2]);
        }
    }
}
