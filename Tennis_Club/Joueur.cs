using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
    abstract class Joueur : Membre, ISaisieBool
    {
        #region : Attributs

        bool paiement;
        int charge;
        #endregion
        #region : Constructeur(s)

        public Joueur(Club club) : base(club)
        {
            this.charge = CalculCharge();
            this.paiement = PayerCharge();
        }
        #endregion
        #region : Propriétés

        public bool Paiement
        {
            get { return this.paiement; }
            set { this.paiement = value; }
        }
        public int Charge
        {
            get { return this.charge; }
            set { this.charge = value;
 }
        }
        #endregion
        #region : Méthodes

        public int CalculCharge()
        {
            int charge = 0;
            if (Code_Postal == Club.Code_Postal)
            {
                if (Categorie == true) //adulte
                {
                    charge = 200;
                }
                else
                {
                    charge = 130;
                }
            }
            else
            {
                if (Categorie == true)
                {
                    charge = 280;



                }
                else
                {
                    charge = 180;
                }
            }
            return charge;
        }
        public bool PayerCharge()
        {
            Console.WriteLine("Souhaitez-vous payer les charges s'élévant à : " + charge + " (true si oui, false si non)");
            return SaisieBool();
        }
        public void VerifPaiement()
        {
            if(this.paiement)
            {
                Console.WriteLine("Paiement effectué ! \n");
            }
            else
            {
                Console.WriteLine("Paiement en attente... \n");
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + "Prix de la charge :" + this.charge + "\n" + "Paiement payée ? : " + this.paiement + "\n";
        }

        public bool SaisieBool()
        {
            bool a;
            while (bool.TryParse(Console.ReadLine(), out a) != true)
            {
                Console.WriteLine("Saisissez une valeur entre true et false : ");
            }
            return a;
        }
        #endregion
    }
}
