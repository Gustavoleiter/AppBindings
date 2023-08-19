using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppBindings.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }

        private string name = string.Empty;//CTRL + R, E
        public string Name
        {
            get => name;
            set
            {
                if (name == null)
                    return;

                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName => $"Nome digitado: {Name}";
        
        public async Task CountCharacters()
        {
            string nameLength = string.Format("Seu nome tem {0} Letras", name.Length);
            await Application.Current.MainPage.DisplayAlert("Informação", nameLength, "Ok");

        }
        
        public ICommand CountCommand { get; }

        public UsuarioViewModel()
        {
           
            CountCommand = new Command(async() => await CountCharacters());
        }
    }
}
