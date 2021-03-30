using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
    class Joueur_Loisir : Joueur
    {
        #region : Constructeur(s)

        public Joueur_Loisir(Club club) : base(club)
        {
        }
        #endregion
        #region : Méthodes

        public void ReserverCours()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
