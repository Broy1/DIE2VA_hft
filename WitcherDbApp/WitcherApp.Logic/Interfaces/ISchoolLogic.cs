using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherApp.Model;

namespace WitcherApp.Logic.Interfaces
{
    public interface ISchoolLogic
    {
        void Create(School item);
        void Delete(int id);
        School Read(int id);
        IQueryable<School> ReadAll();
        void Update(School item);
    }
}
