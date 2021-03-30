using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
    class Club : ISaisieNombre, ISaisieBool
    {
        #region : Attributs

        string nom;
        int code_postal;
        List<Membre> membres = new List<Membre>();
        List<Evenement> evenements = new List<Evenement>();
        List<Competition> competitions = new List<Competition>();
        List<Entraineur> entraineurs = new List<Entraineur>();
        List<Joueur_Competition> joueurs_compet = new List<Joueur_Competition>();
        List<Entraineur> entraineurs_joueurs = new List<Entraineur>(); //liste des entraineurs qui sont des joueurs compétition
        List<Membre> competiteurs = new List<Membre>();
        bool[] terrains; //terrains disponibles pour réserver un cours
        #endregion
        #region : Constructeur(s)

        public Club(string nom, int code_postal)
        {
            this.nom = nom;
            this.code_postal = code_postal;
            this.competiteurs = ModifierCompetiteurs();
        }
        #endregion
        #region : Propriété

        public string Nom
        { get { return nom; } }
        public int Code_Postal
        { get { return code_postal; } }
        public List<Membre> Membres
        {
            get { return membres; }
            set { membres = value; }
        }
        public List<Evenement> Evenements
        {
            get { return evenements; }
            set { evenements = value; }
        }
        public List<Entraineur> Entraineurs
        {
            get { return entraineurs; }
            set { entraineurs = value; }
        }
        public List<Joueur_Competition> Joueurs_Compet
        {
            get { return joueurs_compet; }
            set { joueurs_compet = value; }
        }
        public List<Entraineur> Entraineurs_Joueurs
        {
            get { return entraineurs_joueurs; }
            set { entraineurs_joueurs = value; }
        }
        public List<Membre> Competiteurs
        {
            get { return this.competiteurs; }
            set { this.competiteurs = value; }
        }
        public bool[] Terrains
        {
            get { return terrains; }
            set { terrains = value; }
        }
        #endregion
        #region : Méthodes

        public List<Membre> ModifierCompetiteurs()
        {
            foreach (Entraineur e in entraineurs_joueurs)
                competiteurs.Add(e);
            foreach (Joueur_Competition j in joueurs_compet)
                competiteurs.Add(j);
            return competiteurs;
        }
        public void AjoutMembre(Club c)
        {
            Console.WriteLine("Si le membre à ajouter est un joueur, tapez 1, si c'est un salarié, tapez 2 : ");
            int reponse = SaisieNombre();
            if (reponse == 1)
            {
                Console.WriteLine("Si le joueur est un joueur loisir, tapez 1, si c'est un joueur compétition, tapez 2 : ");
                reponse = SaisieNombre();
                if (reponse == 1)
                {
                    Membre m = new Joueur_Loisir(c);
                    membres.Add(m);
                }
                else
                {
                    Membre m = new Joueur_Competition(c);
                    membres.Add(m);
                    joueurs_compet.Add((Joueur_Competition)m);
                }
            }
            else
            {
                Console.WriteLine("Si le salarié est un entraineur, tapez 1, s'il fait partie du personnel administratif, tapez 2 : ");
                reponse = SaisieNombre();
                if (reponse == 1)
                {
                    DateTime entree = new DateTime(1988, 12, 13);
                    Membre m = new Entraineur(c);
                    membres.Add(m);
                    entraineurs.Add((Entraineur)m);
                    if (m.Classe)
                    {
                        entraineurs_joueurs.Add((Entraineur)m);
                    }
                }
                else
                {
                    DateTime entree = new DateTime(1988, 12, 13);
                    Membre m = new Administratif(c);
                    membres.Add(m);
                }
            }
        }
        #region : SupprimerMembre

        public delegate void SuppressionMembre(Object obj, Club c);
        public void Suppression_Joueur_Competition(Object obj, Club c)
        {
            membres.Remove((Joueur_Competition)obj);
            joueurs_compet.Remove((Joueur_Competition)obj);
        }
        public void Suppression_Joueur_Loisir(Object obj, Club c)
        {
            membres.Remove((Joueur_Loisir)obj);
        }
        public void Suppression_Entraineur(Object obj, Club c)
        {
            membres.Remove((Entraineur)obj);
            entraineurs.Remove((Entraineur)obj);
        }
        public void Suppression_Administratif(Object obj, Club c)
        {
            membres.Remove((Administratif)obj);
        }
        public void SupprimerMembre(SuppressionMembre o, Object obj, Club c)
        {
            o(obj, c);
        }
		#endregion
		public void OrganiserEvent(Club c)
        {
            Console.WriteLine("Quel type d'évènement souhaitez-vous créer ? \nTapez 1 pour un stage, 2 pour un tournoi des familles," +
                "3 pour une compétition : ");

            int reponse = SaisieNombre();
            switch (reponse)
            {
                case 1:
                    Evenement stage = new Stage(c);
                    evenements.Add(stage);
                    break;

                case 2:
                    Evenement tournoi = new Tournoi_Familles(c);
                    evenements.Add(tournoi);
                    break;

                case 3:
                    Console.WriteLine("Pour une compétition Simple, tapez 1, pour une compétition Équipe, tapez 2 : ");
                    int type = SaisieNombre();
                    switch (type)
                    {
                        case 1:
                            Competition simple = new Simple(c);
                            evenements.Add(simple);
                            competitions.Add(simple);
                            AttribuerCompet();

                            break;

                        case 2:
                            Competition equipe = new Equipe(c);
                            evenements.Add(equipe);
                            competitions.Add(equipe);
                            AttribuerCompet();
                            break;
                    }
                    break;
            }
        }
        public void AttribuerCompet()
        {
            bool reponse;
            if (joueurs_compet != null) // on vérifie qu'il existe des joueurs pro
            {
                foreach (Joueur_Competition j in joueurs_compet)
                {
                    Console.WriteLine("Joueur " + j.Nom + " " + j.Prenom + ", voulez-vous participer à la compétition suivante : " +
                        competitions.Last().Nom + "\ntrue or false");
                    reponse = SaisieBool();
                    if (reponse)
                    {
                        j.ParticiperCompetition(competitions.Last());
                        Console.WriteLine("Participation validée ! \n");
                    }
                    else
                    {
                        j.Competitions.Add(competitions.Last(), false);
                        Console.WriteLine("Vous avez refusé de participer. \n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Le club ne contient aucun joueur compétition... \n");
            }

            if (entraineurs_joueurs != null) // on vérifie qu'il existe des entraîneurs
            {
                foreach (Entraineur e in entraineurs_joueurs)
                {// pour chaque entraineur qui est un joueur,
                    Console.WriteLine("Joueur " + e.Nom + " " + e.Prenom + ", voulez-vous participer à la compétition suivante : " +
                        competitions.Last().Nom + "\ntrue or false");
                    reponse = SaisieBool();
                    if (reponse)
                    {
                        e.ParticiperCompetition(competitions.Last()); // on lui attribue la compétition
                        Console.WriteLine("Participation validée ! \n");
                    }
                    else
                    {
                        e.Competitions.Add(competitions.Last(), false); // ou pas !
                        Console.WriteLine("Vous avez refusé de participer. \n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Le club ne contient aucun entraîneurs jouant en compétition... \n");
            }
        }
        #region : SupprimerEvenement

        public delegate void SuppressionEvenement(Object obj, Club c);
        public void Suppression_Stage(Object obj, Club c)
        {
            evenements.Remove((Stage)obj);
        }
        public void Suppression_Tournoi_Familles(Object obj, Club c)
        {
            evenements.Remove((Tournoi_Familles)obj);
        }
        public void Suppression_Competition(Object obj, Club c)
        {
            evenements.Remove((Competition)obj);
            competitions.Remove((Competition)obj);
        }
        public void SupprimerEvenement(SuppressionEvenement o, Object obj, Club c)
        {
            o(obj, c);
        }
		#endregion
		public Membre RechercheEvenement()
        {
            try
            {
                DateTime[] duree = new DateTime[2];

                Console.WriteLine("Saisissez le nom de l'évènement : ");
                string nom = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Saisissez la date de début de l'évènement : le jour ? ");
                int jour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Le mois ? ");
                int mois = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("L'année ? ");
                int annee = Convert.ToInt32(Console.ReadLine());
                DateTime debut = new DateTime(annee, mois, jour);
                duree[0] = debut;

                Console.WriteLine("Saisissez la date de fin de l'évènement : le jour ? ");
                int jour2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Le mois ? ");
                int mois2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("L'année ? ");
                int annee2 = Convert.ToInt32(Console.ReadLine());
                DateTime fin = new DateTime(annee2, mois2, jour2);
                duree[1] = fin;

                bool trouve = false;
                int i = 0;
                for (i = 0; i < evenements.Count || !trouve; i++)
                {
                    if (evenements[i].Nom == nom && evenements[i].Duree[0] == duree[0] && evenements[i].Duree[1] == duree[1])
                        trouve = true;
                }
                return membres[i - 1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public Membre RechercheMembre()
        {
            try
            {
                Console.WriteLine("Saisissez le nom du membre : ");
                string nom = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Saisissez le prénom du membre : ");
                string prenom = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Saisissez l'adresse du membre : ");
                string adresse = Convert.ToString(Console.ReadLine());

                bool trouve = false;
                int i = 0;
                for (i = 0; i < membres.Count || !trouve; i++)
                {
                    if (membres[i].Nom == nom && membres[i].Prenom == prenom && membres[i].Adresse == adresse)
                        trouve = true;
                }
                return membres[i - 1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }   
        public void Trier()
        {
            do
            {
                Console.WriteLine("Comment souhaitez-vous trier la liste de membres de club ? ");
                Console.WriteLine("Tri par section (Loisir ou Compétition), tapez 1");
                Console.WriteLine("Tri par ordre alphabétique, tapez 2");
                Console.WriteLine("Tri par classement, tapez 3");
                Console.WriteLine("Tri par sexe, tapez 4");
                Console.WriteLine("Tri par cotisation (payée ou non), tapez 5");
                int reponse = SaisieNombre();
                switch (reponse)
                {
                    case 1:
                        Console.WriteLine("Tri par section : \n");
                        List<Joueur> joueurs = RecupererJoueurs();
                        joueurs.Sort((a, b) => a.Classe.CompareTo(b.Classe));
                        Console.WriteLine(joueurs.ToString());
                        Console.WriteLine("Pour quitter le mode Tri, écrivez 'fintri', sinon tapez Entrée...");
                        break;

                    case 2:
                        Console.WriteLine("Tri par ordre alphabétique : \n");
                        membres.Sort();
                        Console.WriteLine(membres.ToString());
                        Console.WriteLine("Pour quitter le mode Tri, écrivez 'fintri', sinon tapez Entrée...");
                        break;

                    case 3:
                        Console.WriteLine("Tri par classement : \n");
                        List<Membre> classes = RecupererClasses();
                        classes.Sort((a, b) => a.Classement.CompareTo(b.Classement));
                        Console.WriteLine(classes.ToString());
                        Console.WriteLine("Pour quitter le mode Tri, écrivez 'fintri', sinon tapez Entrée...");
                        break;

                    case 4:
                        Console.WriteLine("Tri par sexe : \n");
                        membres.Sort((a, b) => a.Sexe.CompareTo(b.Sexe));
                        Console.WriteLine(membres.ToString());
                        Console.WriteLine("Pour quitter le mode Tri, écrivez 'fintri', sinon tapez Entrée...");
                        break;

                    case 5:
                        Console.WriteLine("Tri par cotisation : \n");
                        List<Joueur> joueurs_paiement = RecupererJoueurs();
                        joueurs_paiement.Sort((a, b) => a.Paiement.CompareTo(b.Paiement));
                        Console.WriteLine(joueurs_paiement.ToString());
                        Console.WriteLine("Pour quitter le mode Tri, écrivez 'fintri', sinon tapez Entrée...");
                        break;
                }
            }
            while (Console.ReadLine() != "fintri");
        }
        public List<Joueur> RecupererJoueurs()
        {
            List<Joueur> joueurs = new List<Joueur>();
            foreach (Joueur_Competition jc in membres)
                joueurs.Add(jc);
            foreach (Joueur_Loisir jl in membres)
                joueurs.Add(jl);
            return joueurs;
        }
        public List<Membre> RecupererClasses()
        {
            List<Membre> classes = new List<Membre>();
            foreach (Entraineur m in membres)
            {
                if (m.Classement <= 40) // 40 = classement minimum
                    classes.Add(m);
            }
            foreach (Joueur_Competition jc in membres)
                classes.Add(jc);

            return classes;
        } // récupérer tous les membres classés
        public override string ToString()
        {
            string retour = "Nom : " + this.nom + "\n" + "Code Postal : " + this.code_postal + "\n" + "Le club est composé des membres suivants : \n";
            foreach (Membre m in membres)
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
