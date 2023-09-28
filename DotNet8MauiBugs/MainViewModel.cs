

using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace DotNet8MauiBugs
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Venue> filteredVendors;
        public MainViewModel()
        {
            FilteredVendors = new ObservableCollection<Venue>
            {
                new Venue { FullName = "Venue 1", City = "City 1" },
                new Venue { FullName = "Venue 2", City = "City 2" },
                new Venue { FullName = "Venue 3", City = "City 3" },
                new Venue { FullName = "Venue 4", City = "City 4" },

            };
        }

        [RelayCommand]

        async Task EditVendor(Venue venue)
        {
            

        }

        [RelayCommand]
        async Task ChangePassword(Venue venue)
        {
           
        }
    }
}
