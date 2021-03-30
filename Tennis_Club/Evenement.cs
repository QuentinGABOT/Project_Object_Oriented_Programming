using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
    abstract class Evenement : ISaisieNombre
    {
        #region : Attributs

        Club c;
        string nom;
        DateTime[] duree = new DateTime[2];
        List<Membre> participants = new List<Membre>();
        #endregion
        #region : Constructeur(s)

        public Evenement(Club c)
        {
            this.c = c;
            this.nom = ModifierNom();
            this.duree = ModifierDuree();
        }
        #endregion
        #region : Propriété

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public DateTime[] Duree
        {
            get { return duree; }
            set { this.duree = value; }
        }
        public List<Membre> Participants
        {
            get { return participants; }
            set { this.participants = value; }
        }
        #endregion
        #region : Méthodes

        public string ModifierNom()
        {
            Console.WriteLine("Saisissez le nom de l'évènement : ");
            string reponse = Convert.ToString(Console.ReadLine());
            this.nom = reponse;
            return this.nom;
        }
        public DateTime[] ModifierDuree()
        {
            Console.WriteLine("Saisissez la date de début de l'évènement : le jour ? ");
            int jour = SaisieNombre();
            Console.WriteLine("Le mois ? ");
            int mois = SaisieNombre();
            Console.WriteLine("L'année ? ");
            int annee = SaisieNombre();
            DateTime debut = new DateTime(annee, mois, jour);
            duree[0] = debut;

            Console.WriteLine("Saisissez la date de fin de l'évènement : le jour ? ");
            int jour2 = SaisieNombre();
            Console.WriteLine("Le mois ? ");
            int mois2 = SaisieNombre();
            Console.WriteLine("L'année ? ");
            int annee2 = SaisieNombre();
            DateTime fin = new DateTime(annee2, mois2, jour2);
            duree[1] = fin;
            return this.duree;

        }

        public override string ToString()
        {
            string retour = "L'évènement " + this.nom + " débute le " + duree[0] + " et prend fin le " + duree[1] + "\n" + "Participants : ";
            foreach (Membre m in participants)
                retour += m + "\n";
            return retour;
        }
        public int SaisieNombre()
        {
            int a;
            while (int.TryParse(Console.ReadLine(), out a) != true)
            {
                Console.WriteLine("Saisissez une valeur entière : ");
            }
            return a;
        }
        #endregion
    }
}
