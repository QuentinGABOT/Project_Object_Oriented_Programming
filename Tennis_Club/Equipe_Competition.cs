using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
	class Equipe_Competition
	{
		List<Membre> competiteurs = new List<Membre>();
		

		public Equipe_Competition(List<Membre> competiteurs) => this.competiteurs = competiteurs;

		public Membre[,] RandomEquipes(int nombreEquipes)
		{
			int longueurListe = LongueurListe();
			Membre[,] ficheTournoi = new Membre[2, longueurListe / 2];
			List<Membre> competiteurs1 = competiteurs;
			Membre test;
			Random random = new Random();
			Random random1 = new Random();			
			int compteur = 1;
			int a = 1;
			int b = 1;
			int c = 0;
			while (compteur < nombreEquipes)
			{
				while(a == b)
				{
					a = random.Next(1, longueurListe);
					b = random.Next(1, longueurListe);
				}
				foreach (Membre m in competiteurs1)
					test = m;
					compteur++;
					if (compteur == a)
			     	{
					 ficheTournoi[0, c] = test;
			     	}
					  
			}
	    }

		public int LongueurListe()
		{
			int retour = 0;
			if (competiteurs != null)
			{
				foreach (Membre m in competiteurs)
					retour++;
			}
			return retour;
		}
	}
}
