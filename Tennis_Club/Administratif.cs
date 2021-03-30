using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
    class Administratif : Salarie
    {
        #region : Constructeur(s)

        public Administratif(Club club) : base(club)            
        {
        }
        #endregion
        #region : Méthodes

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
