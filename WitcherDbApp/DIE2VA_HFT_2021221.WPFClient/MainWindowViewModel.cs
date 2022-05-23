using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WitcherApp.Model;

namespace DIE2VA_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Monster> Monsters { get; set; }

        private Monster selectedMonster;

        public Monster SelectedMonster
        {
            get { return selectedMonster; }
            set
            {
                if (value != null)
                {
                    selectedMonster = new Monster()
                    {
                        Name = value.Name,
                        MonsterId = value.MonsterId
                    };
                    OnPropertyChanged();
                    (DeleteMonsterCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateMonsterCommand { get; set; }

        public ICommand DeleteMonsterCommand { get; set; }

        public ICommand UpdateMonsterCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Monsters = new RestCollection<Monster>("http://localhost:53500/", "monster", "hub");
                CreateMonsterCommand = new RelayCommand(() =>
                {
                    Monsters.Add(new Monster()
                    {
                        Name = SelectedMonster.Name
                    });
                });

                UpdateMonsterCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Monsters.Update(SelectedMonster);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteMonsterCommand = new RelayCommand(() =>
                {
                    Monsters.Delete(SelectedMonster.MonsterId);
                },
                () =>
                {
                    return SelectedMonster != null;
                });
                SelectedMonster = new Monster();
            }

        }
    }
}
