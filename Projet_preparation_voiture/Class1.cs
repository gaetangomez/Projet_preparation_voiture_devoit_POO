using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Projet_preparation_voiture
{
    public class PreparateurVehicule
    {
        public List<string> ToutMotorisation { get; set; }
        public List<string> ToutCouleur { get; set; }
        public String OptionMotorisationnom { get; set; }
        public String OptionCouleurenom { get; set; }
        public string filePath { get; set; }
        public string json { get; set; }

        public PreparateurVehicule()
        {
            ToutMotorisation = new List<string> { "Auto", "Mannuelle" };
            ToutCouleur = new List<string> { "Rouge", "Noir", "Vert", "Jaune", "gris" };
            OptionMotorisationnom = "defaut";
            OptionCouleurenom = "defaut";
            filePath = @"D:\CDAN\Moi\C#\Projet_preparation_voiture\Projet_preparation_voiture\jsconfig1.json";
            json = File.ReadAllText(filePath);
        }
        public void AfficherFichierJson()
        {
            PreparateurVehicule preparateur = new PreparateurVehicule();
            var deserialized = JsonConvert.DeserializeObject<sauvegarde>(preparateur.json);

            Console.WriteLine("Voici les configuration déjà enregister");

            for (int i=0; i< deserialized.Prenom.Count; i++)
            {
                Console.WriteLine("------------------------------------------- \n");
                Console.WriteLine($"Prénom: {deserialized.Prenom[i]} \n" );
                Console.WriteLine($"Véhicule: {deserialized.Véhicule[i]} \n");
                Console.WriteLine($"Modèle: {deserialized.Modèle[i]} \n");
                Console.WriteLine($"Motorisation: {deserialized.Motorisation[i]} \n");
                Console.WriteLine($"Couleur: {deserialized.Couleur[i]} \n");
                Console.WriteLine($"KitCustomisation: {deserialized.Motorisation[i]} \n");
            }
            Console.WriteLine("------------------------------------------- \n");
            Console.WriteLine("Appuiez sur 2 pour puis ENTRER pour revenir à la configuration");
            int OptionCouleur = Convert.ToInt32(Console.ReadLine());
        }
    }

    public class PreparateurVoiture : PreparateurVehicule
    {
        public List<string> ToutModèle { get; set; }
        public List<string> ToutKitCustomisationCarosserie { get; set; }
        public String OptionModelenom { get; set; }
        public String OptionKitCustomisationCarosserienom { get; set; }

        public PreparateurVoiture()
        {
            ToutModèle = new List<string> { "Bmw", "Mercedes", "Audi", "Citroen", "Dodge" };
            ToutKitCustomisationCarosserie = new List<string> { "Sport", "Rallie", "Ville" };
            OptionModelenom = "model par defaut Dodge";
            OptionKitCustomisationCarosserienom = "defaut";
        }

        public void SauvegarderVoiture()
        {
            Console.Clear();
            Console.Write("Voulez-vous sauvegarder ?" + "\n" + "\n");
            Console.Write("1 Oui" + "\n" + "2 Non" + "\n");
            int OptionSauvegarder = Convert.ToInt32(Console.ReadLine());

            if (OptionSauvegarder == InitialisationCommande.Oui)
            {
                var deserialized = JsonConvert.DeserializeObject<sauvegarde>(json);
                Console.Write("Veuillez entrer votre prénom" + "\n");
                String Optionprenom = Console.ReadLine();
                deserialized.Prenom.Add(Optionprenom);
                deserialized.Véhicule.Add("Voiture");
                deserialized.Modèle.Add(OptionModelenom);
                deserialized.Motorisation.Add(OptionMotorisationnom);
                deserialized.Couleur.Add(OptionCouleurenom);
                deserialized.KitCustomisation.Add(OptionKitCustomisationCarosserienom);
                string updatedJson = JsonConvert.SerializeObject(deserialized, Formatting.Indented);
                File.WriteAllText("D:\\CDAN\\Moi\\C#\\Projet_preparation_voiture\\Projet_preparation_voiture\\jsconfig1.json", updatedJson);
                Console.Clear();
                Console.Write("Création sauvegardé !" + "\n" + "Merci pour votre confiance");
            }
        }

        public int AffichageOptionV()
        {
            Console.Clear();
            Console.Write("-Vous avez choisie une voiture !" + "\n" + "\n");
            Console.Write($"Veuillez maintenant choisir les pièces à modifier suivie de la touche ENTRER" +
            "\n" + "\n" + "1 Modele: " + OptionModelenom + "\n" + "2 Motorisation: " + OptionMotorisationnom + "\n"
            + "3 Couleur: " + OptionCouleurenom + "\n" + "4 KitCustomisation: " + OptionKitCustomisationCarosserienom + "\n"
            + "5 Sortir" + "\n" + "6 Sauvegarder" + "\n" + "7 Creation" + "\n");
            int OptionVoiture = Convert.ToInt32(Console.ReadLine());

            return OptionVoiture;
        }

        public string ChoisirModele()
        {
            Console.Clear();
            Console.Write("Veuillez choisir le modèle" + "\n" + "\n");
            for (int i = 0; i < ToutModèle.Count; i++)
            {
                Console.WriteLine(i + " " + ToutModèle[i]);
            }
            int OptionModele = Convert.ToInt32(Console.ReadLine());
            return ToutModèle[OptionModele];
        }

        public string ChoisirMotorisation()
        {
            Console.Clear();
            Console.Write("Veuillez choisir la motorisation" + "\n" + "\n");
            for (int i = 0; i < ToutMotorisation.Count; i++)
            {
                Console.WriteLine(i + " " + ToutMotorisation[i]);
            }
            int OptionMotorisation = Convert.ToInt32(Console.ReadLine());
            return ToutMotorisation[OptionMotorisation];
        }

        public string ChoisirCouleur()
        {
            Console.Clear();
            Console.Write("Veuillez choisir la couleur" + "\n" + "\n");
            for (int i = 0; i < ToutCouleur.Count; i++)
            {
                Console.WriteLine(i + " " + ToutCouleur[i]);
            }
            int OptionCouleur = Convert.ToInt32(Console.ReadLine());
            return ToutCouleur[OptionCouleur];
        }

        public string ChoisirKitCustomisation()
        {
            Console.Clear();
            Console.Write("Veuillez choisir le KitCustomisation" + "\n" + "\n");
            for (int i = 0; i < ToutKitCustomisationCarosserie.Count; i++)
            {
                Console.WriteLine(i + " " + ToutKitCustomisationCarosserie[i]);
            }
            int OptionKitCustomisation = Convert.ToInt32(Console.ReadLine());
            return ToutKitCustomisationCarosserie[OptionKitCustomisation];
        }
    }

    public class PreparateurMoto : PreparateurVehicule
    {
        public List<string> ToutModèle { get; set; }
        public List<string> kitCustomisationPhare { get; set; }
        public String OptionModelenom { get; set; }
        public String OptionkitCustomisationPhare { get; set; }
        public PreparateurMoto()
        {
            ToutModèle = new List<string> { "Yamaha", "Honda", "Kawasaki", "KTM", "Triumph" };
            kitCustomisationPhare = new List<string> { "Led", "laser", "halogènes" };
            OptionModelenom = "model par defaut Triumph";
            OptionkitCustomisationPhare = "defaut";
        }

        public void SauvegarderMoto()
        {
            Console.Clear();
            Console.Write("Voulez-vous sauvegarder ?" + "\n" + "\n");
            Console.Write("1 Oui" + "\n" + "2 Non" + "\n");
            int OptionSauvegarder = Convert.ToInt32(Console.ReadLine());

            if (OptionSauvegarder == InitialisationCommande.Oui)
            {
                var deserialized = JsonConvert.DeserializeObject<sauvegarde>(json);
                Console.Write("Veuillez entrer votre prénom" + "\n");
                String Optionprenom = Console.ReadLine();
                deserialized.Prenom.Add(Optionprenom);
                deserialized.Véhicule.Add("Moto");
                deserialized.Modèle.Add(OptionModelenom);
                deserialized.Motorisation.Add(OptionMotorisationnom);
                deserialized.Couleur.Add(OptionCouleurenom);
                deserialized.KitCustomisation.Add(OptionkitCustomisationPhare);
                string updatedJson = JsonConvert.SerializeObject(deserialized, Formatting.Indented);
                File.WriteAllText("D:\\CDAN\\Moi\\C#\\Projet_preparation_voiture\\Projet_preparation_voiture\\jsconfig1.json", updatedJson);
                Console.Clear();
                Console.Write("Création sauvegardé !" + "\n" + "Merci pour votre confiance");
            }
        }
        public int AffichageOptionM()
        {
            Console.Clear();
            Console.Write("-Vous avez choisie une voiture !" + "\n" + "\n");
            Console.Write($"Veuillez maintenant choisir les pièces à modifier suivie de la touche ENTRER" +
            "\n" + "\n" + "1 Modele: " + OptionModelenom + "\n" + "2 Motorisation: " + OptionMotorisationnom + "\n"
            + "3 Couleur: " + OptionCouleurenom + "\n" + "4 KitCustomisation: " + OptionkitCustomisationPhare + "\n"
            + "5 Sortir" + "\n" + "6 Sauvegarder" + "\n" + "7 Creation" + "\n");
            int OptionMoto = Convert.ToInt32(Console.ReadLine());

            return OptionMoto;
        }

        public string ChoisirModeleMoto()
        {
            Console.Clear();
            Console.Write("Veuillez choisir le modèle" + "\n" + "\n");
            for (int i = 0; i < ToutModèle.Count; i++)
            {
                Console.WriteLine(i + " " + ToutModèle[i]);
            }
            int OptionModele = Convert.ToInt32(Console.ReadLine());
            return ToutModèle[OptionModele];
        }

        public string ChoisirMotorisationMoto()
        {
            Console.Clear();
            Console.Write("Veuillez choisir la motorisation" + "\n" + "\n");
            for (int i = 0; i < ToutMotorisation.Count; i++)
            {
                Console.WriteLine(i + " " + ToutMotorisation[i]);
            }
            int OptionMotorisation = Convert.ToInt32(Console.ReadLine());
            return ToutMotorisation[OptionMotorisation];
        }

        public string ChoisirCouleurMoto()
        {
            Console.Clear();
            Console.Write("Veuillez choisir la couleur" + "\n" + "\n");
            for (int i = 0; i < ToutCouleur.Count; i++)
            {
                Console.WriteLine(i + " " + ToutCouleur[i]);
            }
            int OptionCouleur = Convert.ToInt32(Console.ReadLine());
            return ToutCouleur[OptionCouleur];
        }

        public string ChoisirKitCustomisationMoto()
        {
            Console.Clear();
            Console.Write("Veuillez choisir le KitCustomisation pour les phares" + "\n" + "\n");
            for (int i = 0; i < kitCustomisationPhare.Count; i++)
            {
                Console.WriteLine(i + " " + kitCustomisationPhare[i]);
            }
            int OptionKitCustomisation = Convert.ToInt32(Console.ReadLine());
            return kitCustomisationPhare[OptionKitCustomisation];
        }
    }

    public class InitialisationCommande
    {
        public const int Voiture = 1;
        public const int Moto = 2;
        public const int Modele = 1;
        public const int Motorisation = 2;
        public const int Couleur = 3;
        public const int KitCustomisation = 4;
        public const int Sortir = 5;
        public const int Sauvegarder = 6;
        public const int Oui = 1;
        public const int Non = 2;
        public const int Creation = 7;
        public const int retour = 2;
    }

    public class sauvegarde
    {
        public List<string> Prenom { get; set; }
        public List<string> Véhicule { get; set; }
        public List<string> Modèle { get; set; }
        public List<string> Motorisation { get; set; }
        public List<string> Couleur { get; set; }
        public List<string> KitCustomisation { get; set; }
    }
}