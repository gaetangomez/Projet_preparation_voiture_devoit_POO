using Projet_preparation_voiture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TP7
{
    internal class Program
    {
        public static int DemanderTypeVehicule()
        {
            Console.Write("---Bienvenue sur notre préparateur de voiture" + "\n" + "\n");
            Console.Write("L'interface de cette application marche de la manière suivante : \n");
            Console.Write("Il faut écrire le numéro associé a l'action que vous voulez effectuer suivie de la touche ENTRER \n \n");
            Console.Write($"Veuillez sélectionner un type de véhicule \n \n 1 Voiture \n 2 Moto \n \n");
            int OptionVehicule = Convert.ToInt32(Console.ReadLine());

            //Option choisie non existante affiche message d'erreur
            while (OptionVehicule != InitialisationCommande.Voiture && OptionVehicule != InitialisationCommande.Moto)
            {
                Console.Clear();
                Console.Write("Option non existante !" + "\n" + "veuillez choisir une option marqué" + "\n");
                Console.Write("Veuillez sélectionner un type de véhicule suivie de la touche ENTRER" +
                "\n" + "\n" + "1 Voiture" + "\n" + "2 Moto" + "\n" + "\n");
                OptionVehicule = Convert.ToInt32(Console.ReadLine());            
            }
            return OptionVehicule;
        }

        static void Main(string[] args)
        {
            PreparateurVoiture preparateurV = new PreparateurVoiture();
            PreparateurMoto preparateurM = new PreparateurMoto();

            int OptionVehicule = DemanderTypeVehicule();

            if (OptionVehicule == InitialisationCommande.Voiture)
                {
                    int OptionVoiture = preparateurV.AffichageOptionV();

                    while (OptionVoiture != InitialisationCommande.Sortir)
                    {
                        Console.Clear();

                        if (OptionVoiture == InitialisationCommande.Modele)
                        {
                            preparateurV.OptionModelenom = preparateurV.ChoisirModele();
                        }

                        if (OptionVoiture == InitialisationCommande.Motorisation)
                        {
                            preparateurV.OptionMotorisationnom = preparateurV.ChoisirMotorisation();
                        }

                        if (OptionVoiture == InitialisationCommande.Couleur)
                        {
                            preparateurV.OptionCouleurenom = preparateurV.ChoisirCouleur();
                        }

                        if (OptionVoiture == InitialisationCommande.KitCustomisation)
                        {
                            preparateurV.OptionKitCustomisationCarosserienom = preparateurV.ChoisirKitCustomisation();
                        }

                        if (OptionVoiture == InitialisationCommande.Sauvegarder)
                        {               
                            preparateurV.SauvegarderVoiture();
                            break;
                        }

                        if (OptionVoiture == InitialisationCommande.Creation)
                        {
                            preparateurV.AfficherFichierJson();
                        }

                        OptionVoiture = preparateurV.AffichageOptionV();
                    }
             }

            if (OptionVehicule == InitialisationCommande.Moto)
            {
                int OptionMoto = preparateurM.AffichageOptionM();

                while (OptionMoto != InitialisationCommande.Sortir)
                {
                    Console.Clear();

                    if (OptionMoto == InitialisationCommande.Modele)
                    {
                        preparateurM.OptionModelenom = preparateurM.ChoisirModeleMoto();
                    }

                    if (OptionMoto == InitialisationCommande.Motorisation)
                    {
                        preparateurM.OptionMotorisationnom = preparateurM.ChoisirMotorisationMoto();
                    }

                    if (OptionMoto == InitialisationCommande.Couleur)
                    {
                        preparateurM.OptionCouleurenom = preparateurM.ChoisirCouleurMoto();
                    }

                    if (OptionMoto == InitialisationCommande.KitCustomisation)
                    {
                        preparateurM.OptionkitCustomisationPhare = preparateurM.ChoisirKitCustomisationMoto();
                    }

                    if (OptionMoto == InitialisationCommande.Sauvegarder)
                    {
                        preparateurM.SauvegarderMoto();
                        break;
                    }

                    if (OptionMoto == InitialisationCommande.Creation)
                    {
                        preparateurM.AfficherFichierJson();
                    }

                    OptionMoto = preparateurM.AffichageOptionM();
                }
            }               
            Console.ReadKey();
        }
    }

}
