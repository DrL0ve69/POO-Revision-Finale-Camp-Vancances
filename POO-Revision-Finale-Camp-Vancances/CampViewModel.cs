using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace POO_Revision_Finale_Camp_Vancances
{
    class CampViewModel : INotifyPropertyChanged
    {
        // TODO : Ajouter les propriétés manquantes au besoin

        // TODO : Encapsuler les propriétés au besoin et programmer les setters
        public string Nom { get; set; } = "Camp-Reboul";
        public string Lieu { get; set; } = "Hull";
        public int CapaciteMax { get; set; } = 30;
        private int _nbInscrits;
        public int NbInscrits 
        {
            get { return _nbInscrits; }
            set
            {
                _nbInscrits = value;
                OnPropertyChanged(nameof(NbInscrits));
            }
        }
        public string NomEmploye { get; set; }
        public string PrenomEmploye { get; set; }
        public int AgeEmploye { get; set; }
        public int ExperienceEmploye { get; set; }
        public List<string> PostesDisponibles { get; set; } =
        [
            "Moniteur",
            "Animateur"
        ];
        private string _posteSelectionne;
        public string PosteSelectionne 
        {
            get => _posteSelectionne; 
            set
            {
                _posteSelectionne = value;
                OnPropertyChanged(nameof(PosteSelectionne));
            }
        }
        private ObservableCollection<Campeur> _campeurs;
        public ObservableCollection<Campeur> Campeurs 
        {
            get => _campeurs;
            set 
            {
                _campeurs = value;
                OnPropertyChanged(nameof(Campeurs));
                OnPropertyChanged(nameof(NbInscrits));
            } 
        }
        private ObservableCollection<Activite> _activites;
        public ObservableCollection<Activite> Activites 
        {
            get => _activites;
            set 
            {
                _activites = value;
                OnPropertyChanged(nameof(Activites));
            } 
        } 
        private Activite _activiteSelectionnee;
        public Activite ActiviteSelectionnee
        {
            get => _activiteSelectionnee;
            set
            {
                _activiteSelectionnee = value;
                OnPropertyChanged(nameof(ActiviteSelectionnee));
            }
        }
        private Campeur _campeurSelectionne;
        public Campeur CampeurSelectionne
        {
            get => _campeurSelectionne;
            set
            {
                _campeurSelectionne = value;
                OnPropertyChanged(nameof(CampeurSelectionne));
            }
        }
        private ObservableCollection<Employe> _listeEmployes;
        public ObservableCollection<Employe> ListeEmployes
        {
            get => _listeEmployes;
            set
            {
                _listeEmployes = value;
                OnPropertyChanged(nameof(ListeEmployes));
            }
        }
        private Employe _employeSelectionne;
        public Employe EmployeSelectionne
        {
            get => _employeSelectionne;
            set
            {
                _employeSelectionne = value;
                OnPropertyChanged(nameof(EmployeSelectionne));
            }
        }
        public ICommand InscrireCommand { get; }
        public ICommand AjoutResponsableCommand { get; }
        public ICommand AjouterEmployeCommand { get; }
        // TODO : Créer le constructeur du viewModel avec tout ce qui est nécessaire
        public CampViewModel()
        {
            // TODO : Initialiser les propriétés au besoin
            Campeurs = new ObservableCollection<Campeur>()
            {
            new Campeur()
            {
                Prenom = "Alex",
                Nom = "Leblanc",
                Age = 8,
                Allergies = "Arrachides"
            },
            new Campeur()
            {
                Prenom = "Joséphine",
                Nom = "Leduc",
                Age = 7,
                Allergies = "Oeufs"
            },
            new Campeur()
            {
                Prenom = "Bob",
                Nom = "Leclair",
                Age = 9,
                Allergies = "Aucune"
            }
            };

            Activites =
            [
            new Activite() {
                Nom = "Tie-Dye",
                Description = "Créer un t-shirt coloré",
                Horaire = "10h-12h",
                EmployeResponsable = new Moniteur()
                {
                    Prenom = "Jean",
                    Nom = "Dupont",
                    Age = 25,
                    Poste = "Moniteur"
                }
            }, new Activite() {
                Nom = "Loup-Garou"
            },
            new Activite()
            {
                Nom = "Nerf"
            },
            new Activite()
            {
                Nom = "Lego"
            },
            new Activite()
            {
                Nom = "Dessin"
            },
            new Activite()
            {
                Nom = "Multisport"
            }
            ];

            ListeEmployes =
            [
                new Moniteur()
                {
                    Prenom = "Jean",
                    Nom = "Dupont",
                    Age = 25,
                    Poste = "Moniteur"
                },
                new Moniteur()
                {
                    Prenom = "Marie",
                    Nom = "Lemoine",
                    Age = 30,
                    Poste = "Moniteur"
                },
                new Animateur()
                {
                    Prenom = "Luc",
                    Nom = "Lafleur",
                    Age = 22,
                    Poste = "Animateur"
                }
            ];
            NbInscrits = Campeurs.Count;
            InscrireCommand = new RelayCommand(Inscrire, CanInscrire);
            AjoutResponsableCommand = new RelayCommand(AjouterResponsable, CanAjouterResponsable);
            AjouterEmployeCommand = new RelayCommand(AjouterEmploye, CanAjouterEmploye);
        }
        // TODO : Gérer le bouton Inscription qui doit permettre d'inscrire les campeurs aux activités.
        // Lors de l'inscription, il doit y avoir des objets sélectionnés dans les 2 grilles 
        // On ajoute le campeur à la liste dans l'objet activité et on ajoute l'activité à la liste dans l'objet campeur
        // Utiliser une fonction anonyme pour désactiver le bouton si les 2 objets ne sont pas sélectionnés.

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        // TODO : Version longue : Ajouter la logique nécessaire pour vos ajouts à l'interface utilisateur.
        private void Inscrire()
        {
            if (ActiviteSelectionnee != null && CampeurSelectionne != null)
            {
                ActiviteSelectionnee.CampeursInscrits.Add(CampeurSelectionne);
                CampeurSelectionne.Activites.Add(ActiviteSelectionnee);
                NbInscrits = ActiviteSelectionnee.CampeursInscrits.Count;
                ActiviteSelectionnee = null;
                CampeurSelectionne = null;
            }
        }
        private bool CanInscrire()
        {
            return ActiviteSelectionnee != null && CampeurSelectionne != null && !ActiviteSelectionnee.CampeursInscrits.Contains(CampeurSelectionne);
        }
        public void AjouterResponsable()
        {
            // La méthode est appelée mais pas de responsable dans le grid...
            if (ActiviteSelectionnee != null && EmployeSelectionne != null)
            {
                ActiviteSelectionnee.EmployeResponsable = EmployeSelectionne;

                ObservableCollection<Activite> activitesCopie = [.. Activites];

                EmployeSelectionne.ActivitesEncadrees.Add(ActiviteSelectionnee);

                Activites = activitesCopie;
                ActiviteSelectionnee = null;
                EmployeSelectionne = null;
            }
        }
        private bool CanAjouterResponsable()
        {
            return ActiviteSelectionnee != null && EmployeSelectionne != null;
        }

        public void AjouterEmploye() 
        {
            if (PosteSelectionne == "Moniteur") 
            {
                Moniteur employeMoniteur = new Moniteur()
                {
                    Nom = NomEmploye,
                    Prenom = PrenomEmploye,
                    Age = AgeEmploye,
                    Poste = PosteSelectionne,
                    Experience = ExperienceEmploye
                };
                ListeEmployes.Add(employeMoniteur);
            }
            else if (PosteSelectionne == "Animateur")
            {
                Animateur employeAnimateur = new Animateur()
                {
                    Nom = NomEmploye,
                    Prenom = PrenomEmploye,
                    Age = AgeEmploye,
                    Poste = PosteSelectionne,
                    Experience = ExperienceEmploye
                };
                ListeEmployes.Add(employeAnimateur);
            }
            Employe employe = new Employe()
            {
                Nom = NomEmploye,
                Prenom = PrenomEmploye,
                Age = AgeEmploye,
                Poste = PosteSelectionne,
                Experience = ExperienceEmploye
            };
            
        }
        private bool CanAjouterEmploye()
        {
            // TODO : Vérifier si les champs sont valides
            // TODO : Vérifier si l'employé n'est pas déjà dans la liste
            
            return !string.IsNullOrEmpty(PosteSelectionne) && !string.IsNullOrEmpty(NomEmploye) &&
                !string.IsNullOrEmpty(PrenomEmploye) && AgeEmploye > 14 && AgeEmploye < 70;
        }
    }
}
