using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
    abstract class Membre : ISaisieNombre, IComparable
    {
        #region : Attributs

        string nom;
        string prenom;
        char sexe;
        DateTime date_de_naissance;
        bool categorie; //if false => junior       
        int telephone;
        int code_postal;
        string adresse;
        Club club;
        bool classe; //si le membre est classé ou non
        double classement;
        #endregion
        #region : Constructeur(s)
        /// <summary>
        /// Constructeur membre en tant que joueurs ou entraineurs
        /// </summary>
        /// <param name="club"></param>
        /// <param name="categorie"></param>
        public Membre(Club club)
        {
            this.nom = ModifierNom().ToUpper();
            this.prenom = ModifierPrenom();
            this.sexe = Char.ToUpper(ModifierSexe());
            this.date_de_naissance = ModifierDateNaissance();
            if ((DateTime.Now.Year - this.date_de_naissance.Year) > 18) { this.categorie = true; } else { this.categorie = false; }
            this.telephone = ModifierTel();
            this.code_postal = ModifierCodePostal();
            this.adresse = ModifierAdresse();
            this.club = club;
            this.classe = false;
        }
        #endregion
        #region : Propriétés

        public string Nom
        {
            get { return nom; }
            set { this.nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { this.prenom = value; }
        }
        public char Sexe
        {
            get { return sexe; }
            set { this.sexe = value; }
        }
        public DateTime Date_De_Naissance
        {
            get { return date_de_naissance; }
            set { this.date_de_naissance = value; }
        }
        public int Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public int Code_Postal
        {
            get { return code_postal; }
            set { this.code_postal = value; }
        }
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        public bool Categorie
        {
            get { return categorie; }
            set { this.categorie = value; }
        }
        public Club Club
        {
            get { return club; }           
        }
        public bool Classe
        {
            get { return this.classe; }
            set { this.classe = value; }
        }
        public double Classement
        {
            get { return this.classement; }
            set { this.classement = value; }
        }
        #endregion
        #region : Méthodes

        public void ModificationDomicile()
        {
            ModifierAdresse();
            ModifierCodePostal();
        }
        public string ModifierAdresse()
        {
            bool test = false;
            SortedList<int, string> adresseTest = new SortedList<int, string>();
            char separateurs = ' ';
            do
            {
                int j = 0;               
                Console.WriteLine("Saisissez une nouvelle adresse : ");
                this.adresse = Console.ReadLine();
                for (int i = 0; i < 2; i++) // on vérifie que que l'adresse est bien au format : "(int)xx rue ...", "(int)xx boulevard ...", etc.
                {
                    string tampon = "";
                    while (this.adresse[j] != separateurs)
                    {
                        tampon += this.adresse[j];
                        j++;                        
                    }
                    adresseTest.Add(i, tampon);                    
                    j++;
                }
                string mot1 = adresseTest[0];
                int a;
                if (int.TryParse(mot1, out a) == true)
                {
                    string mot2 = adresseTest[1];
                    if (mot2 == "rue" || mot2 == "avenue" || mot2 == "boulevard" || mot2 == "chemin" || mot2 == "impasse")
                    {
                        test = true;
                    }
                    else
                    {
                        Console.WriteLine("L'adresse est incorrecte : vous n'avez pas saisi un terme valide pour l'adresse... ");
                    }
                }
                else
                {
                    Console.WriteLine("L'adresse est incorrecte : vous n'avez pas saisi un numéro pour l'adresse... ");
                }

            } while (test == false);
            return this.adresse;
        } // corrigée
        public int ModifierCodePostal()
        {
            Console.WriteLine("Saisissez un nouveau code postal (5 chiffres sont donc attendus) : ");
            do
            {
                this.code_postal = SaisieNombre();
            } while (this.code_postal.ToString().Length != 5);
            return code_postal;
        } // corrigée
        public int ModifierTel()
        {
            Console.WriteLine("Saisissez un nouveau numéro de téléphone (10 chiffres sont donc attendus) : ");
            do
            {
                this.telephone = SaisieNombre();                                    
            } while (this.telephone.ToString().Length != 9);            
            return this.telephone;
        } // corrigée
        public DateTime ModifierDateNaissance()
        {
            Console.WriteLine("Saisissez l'année de votre naissance (une année comprise entre 1950 et 2015 est donc attendue) : ");
            int annee;
            do
            {
                annee = SaisieNombre();
            } while (annee < 1950 || annee > 2015);           
            Console.WriteLine("Saisissez le mois de votre naissance (un nombre compris entre 1 et 12 est donc attendu) : ");
            int mois;
            do
            {
                mois = SaisieNombre();
            } while (mois < 1 || mois > 12);            
            Console.WriteLine("Saisissez le jour de votre naissance (un nombre compris entre 1 et 31 est donc attendu) : ");
            int jour;
            do
            {
                jour = SaisieNombre();
            } while (jour < 1 || jour > 31);            
            this.date_de_naissance = new DateTime(annee, mois, jour);
            return this.date_de_naissance;
        } // corrigée
        public string ModifierNom()
        {
            Console.WriteLine("Saisissez le nom du membre : ");                           
            this.nom = Console.ReadLine();            
            return this.nom;
        }
        public string ModifierPrenom()
        {
            Console.WriteLine("Saisissez le prenom du membre : ");
            this.prenom = Console.ReadLine();
            return this.prenom;
        }
        public char ModifierSexe() // corrigée 
        {
            Console.WriteLine("Saisissez le sexe du membre (h pour homme ou f pour femme) : ");
            string a = "";
            do
            {
                a = Console.ReadLine();                               
            } while (a != "h" ||a != "f");          
            return this.sexe;
        }
        

        public override string ToString()
        {
            string retour = this.nom.ToUpper() + " " + this.prenom + " " + this.sexe + " " + (DateTime.Today.Year - this.date_de_naissance.Year) +
                " ans " + "né(e) le " + this.date_de_naissance.Day + "/" + this.date_de_naissance.Month + "/" + this.date_de_naissance.Year +
                "\n" + "Tel : 0" + this.telephone + "\n" + "Code Postal : " + this.code_postal + "\n" + "Adresse : "
                + this.adresse + "\n" + "Catégorie : ";
            if (this.categorie)
                retour += "Adulte \n";
            else
                retour += "Junior \n";
            if(!this.classe)
            {
                retour += "NC";
            }
            return retour;
        }

        public bool EligibiliteStage()
        {
            return (DateTime.Today.Year - this.date_de_naissance.Year > 18);     
        }
        public int SaisieNombre()
        {
            int a;
            while (int.TryParse(Console.ReadLine(), out a) != true) { }
            return a;
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

        public int CompareTo(object obj)
        {
            return this.Nom.CompareTo(((Membre)(obj)).Nom); 
        }          
        #endregion
    }
}
