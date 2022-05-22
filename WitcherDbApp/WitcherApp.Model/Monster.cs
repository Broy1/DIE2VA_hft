using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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

        public virtual ICollection<Witcher> HuntedBy { get; set; }

        public virtual ICollection<Human> KilledHumans { get; set; }
    }
}
