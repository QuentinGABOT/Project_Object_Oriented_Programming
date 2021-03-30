using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
	class Entraineur : Salarie, ISaisieNombre, ISaisieBool
	{
		#region : Attributs

		int classement;
		int equipe;
		SortedList<Competition, bool> competitions = new SortedList<Competition, bool>();
		int points;
		int matchsVictoire;
		int matchsDefaite;
		#endregion
		#region : Constructeur(s)

		public Entraineur(Club club) : base(club)
		{
			this.Classe = ModifierClasse();
			this.classement = ModifierClassement();
			this.points = 0;
			this.matchsDefaite = 0;
			this.matchsVictoire = 0;
		}
		#endregion
		#region : Propriété

		public int Classement
		{
			get { return classement; }
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

		public bool ModifierClasse()
		{
			Console.WriteLine("Être-vous classé ? 'true' or 'false' ");
			bool reponse = SaisieBool();
			if (reponse)
				this.Classe = true;
			return this.Classe;
		}
		public int ModifierClassement()
		{
			if (this.Classe)
			{
				Console.WriteLine("Saisissez votre classement : ");
				this.classement = SaisieNombre();
			}
			else
			{
				this.classement = 41; // > 40 <=> "NC"
			}
			return this.classement;
		}
		public int ModifierEquipe()
		{
			Console.WriteLine("Saisissez le numero de votre equipe : ");
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
			string retour = base.ToString() + "Compétition(s) : \n" + AfficherListeCompetEntraineurs(competitions);
			return retour;
		}

		public string AfficherListeCompetEntraineurs(SortedList<Competition, bool> l) // afficher toutes les competitions d'un entraîneur
		{
			string retour = "";
			if (l != null)
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
