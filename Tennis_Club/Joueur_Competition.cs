using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
    class Joueur_Competition : Joueur, ISaisieNombre, ISaisieBool
    {
        #region : Attributs

        double classement;
        int equipe;
        SortedList<Competition, bool> competitions = new SortedList<Competition, bool>();
        int points;
        int matchsDefaite;
		int matchsVictoire;
        #endregion
        #region : Constructeur(s)

        public Joueur_Competition(Club club) : base(club)
        {
            this.Classe = true;
            this.classement = ModifierClassement();
            this.points = 0;
            this.matchsDefaite = 0;
            this.matchsVictoire = 0;
        }
        #endregion
        #region : Propriétés

        public double Classement
        {
            get { return this.classement; }
            set { this.classement = value; }
        }
        public int Equipe
        {
            get { return equipe; }
            set { this.equipe = value; }
        }
        public SortedList<Competition, bool> Competitions
        {
            get { return competitions; }
            set { this.competitions = value; }
        }
        public int Points
        {
            get { return points; }
            set { this.points = value; }
        }
        public int MatchsVictoire
        {
            get { return matchsVictoire; }
            set { this.matchsVictoire = value; }
        }
        public int MatchsDefaite
        {
            get { return matchsDefaite; }
            set { this.matchsDefaite = value; }
        }
        #endregion
        #region : Méthodes

        public double ModifierClassement()
        {
            Console.WriteLine("Saisissez le classement : ");
            this.classement = SaisieNombreDouble();
            return this.classement;
        }
        public int ModifierEquipe()
        {
            Console.WriteLine("Saisissez le numéro d'équipe : ");
            this.equipe = SaisieNombre();
            return this.equipe;
        }

        public void ParticiperCompetition(Competition c)
        {            
                competitions[c] = true;
                Console.WriteLine("Participation validée ! \n");          
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + "Classement : " + this.classement + "\n" + "Equipe : " +
                this.equipe + "\n" + "Compétitions : " + AfficherListeCompetJoueursPro(competitions);
        }

        public string AfficherListeCompetJoueursPro(SortedList<Competition, bool> l) // afficher toutes les competitions d'un joueur
        {
            string retour = "";
            if(l != null)
            {
                foreach (KeyValuePair<Competition, bool> c in competitions)
                    retour += c.Key.Nom + " --> Participation : " + c.Value;
            }
            else
            {
                retour += "Liste vide... \n";
            }
            return retour;
        }

        public bool EligibiliteCompet(Competition c)
        {
            return (DateTime.Today.Year - this.Date_De_Naissance.Year >= c.Age && this.classement <= c.ClassementMax);
        }
            
        static double SaisieNombreDouble()
        {
            double a;
            while (double.TryParse(Console.ReadLine(), out a) != true)
            {
                Console.WriteLine("Saisissez une valeur comprise entre 0.0 et 100.0 : ");
            }
            return a;
        }
        public int SaisieNombre()
        {
            int a;
            while (int.TryParse(Console.ReadLine(), out a) != true)
            {
                Console.WriteLine("Saisissez un nombre entier : ");
            }
            return a;
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
