


using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DotNet8MauiBugs
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public ICommand EditVendorCommand { get; private set; } 
        public ICommand ChangePasswordCommand { get; private set; } 
      
       

        public event PropertyChangedEventHandler PropertyChanged;

       
        ObservableCollection<Venue> filteredVendors;
      public  ObservableCollection<Venue> FilteredVendors
        {
            get => filteredVendors;
            set => SetProperty(ref filteredVendors, value);
                
        }


        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            FilteredVendors = new ObservableCollection<Venue>
            {
                new Venue { FullName = "Venue 1", City = "City 1" },
                new Venue { FullName = "Venue 2", City = "City 2" },
                new Venue { FullName = "Venue 3", City = "City 3" },
                new Venue { FullName = "Venue 4", City = "City 4" },

            };

            EditVendorCommand = new Command<Venue>(async(venue)=>await EditVendor(venue));
            ChangePasswordCommand = new Command<Venue>(async (venue)=>await ChangePassword(venue));
        }

      

        async Task EditVendor(Venue venue)
        {
            

        }

      
        async Task ChangePassword(Venue venue)    
        {
           
        }
    }
}
