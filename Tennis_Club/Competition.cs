using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
    abstract class Competition : Evenement
    {
        char sexe;
        string niveau;
        int nbJoueursMin;
        double classementMax;
        int age; //de la compétition, ex: + de 35 ans...
        bool[,] tableau_tournoi;
        List<Equipe_Competition> competiteurs = new List<Equipe_Competition>();

        public Competition(Club c) : base(c)
        {
            this.sexe = ModifierSexe();
            this.niveau = ModifierNiveau();
            this.nbJoueursMin = ModifierNbJoueursMin();
            this.classementMax = ModifierClassementMax();
            this.age = ModifierAge();
        }

        public char Sexe
        {
            get { return sexe; }
            set { this.sexe = value; }
        }
        public string Niveau
        {
            get { return niveau; }
            set { this.niveau = value; }
        }
        public int NbJoueursMin
        {
            get { return nbJoueursMin; }
            set { this.nbJoueursMin = value; }
        }
        public double ClassementMax
        {
            get { return classementMax; }
            set { this.classementMax = value; }
        }
        public int Age
        {
            get { return age; }
            set { this.age = value; }
        }        

        public char ModifierSexe()
        {
            Console.WriteLine("Saisissez la catégorie de la compétition  'H' ou 'F' ? ");
            char reponse = Convert.ToChar(Console.ReadLine());
            this.sexe = reponse;
            return this.sexe;
        }
        public string ModifierNiveau()
        {
            Console.WriteLine("Saisissez le niveau de la compétition : régional, départemental... ? ");
            string reponse = Convert.ToString(Console.ReadLine());
            this.niveau = reponse;
            return this.niveau;
        }
        public int ModifierNbJoueursMin()
        {
            Console.WriteLine("Saisissez le nombre de joueurs minimum de la compétition ? ");
            int reponse = Convert.ToInt32(Console.ReadLine());
            this.nbJoueursMin = reponse;
            return this.nbJoueursMin;
        }
        public double ModifierClassementMax()
        {
            Console.WriteLine("Saisissez le classement maximum de la compétition ? ");
            double reponse = Convert.ToDouble(Console.ReadLine());
            this.classementMax = reponse;
            return this.classementMax;
        }
        public int ModifierAge()
        {
            Console.WriteLine("Saisissez l'âge minimum de la compétition ? ");
            int reponse = Convert.ToInt32(Console.ReadLine());
            this.age = reponse;
            return this.age;
        }
        public List<Equipe_Competition> Competiteurs
        {
            get { return this.competiteurs; }
            set { this.competiteurs = value; }
        }

        public override string ToString()
        {
            string retour = base.ToString() + "\n" + " Sexe (catégorie) : " + this.sexe + "\n" + " Niveau : " + this.niveau + "\n" + " Classement maximum autorisé : "
                + this.classementMax + "\n" + "Age minmimum : " + this.age + "\n";
            return retour; //il manque l'affichage de la matrice !
        }

        public static void AfficherMatrice(bool[,] matrice)
        {
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    Console.Write(matrice[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
