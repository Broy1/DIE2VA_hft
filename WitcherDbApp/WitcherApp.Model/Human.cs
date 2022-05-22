using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherApp.Model
{
    public class Human
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HumanId { get; set; }

        public string Name { get; set; }

        public int WitcherId { get; set; }

        public int? MonsterId { get; set; }

        public virtual Witcher WitcherFriend { get; set; }

        public virtual Monster KilledBy { get; set; }

        public Human(string datastring)
        {
            string[] raw = datastring.Split('-');
            HumanId = int.Parse(raw[0]);
            WitcherId = int.Parse(raw[1]);
            MonsterId = int.Parse(raw[2]);
            Name = raw[3];
        }
    }
}
