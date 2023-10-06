

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace DotNet8MauiBugs
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Booking> bookings ;  
        public MainViewModel()
        {

            Bookings = new ObservableCollection<Booking>
            {
               new Booking { StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), PlayerName = "John Doe", GameName = "Chess" },
               new Booking { StartTime = DateTime.Now.AddHours(1), EndTime = DateTime.Now.AddHours(2), PlayerName = "Michel Doe", GameName = "Badminton" },
               new Booking { StartTime = DateTime.Now.AddHours(2), EndTime = DateTime.Now.AddHours(3), PlayerName = "Harry Doe", GameName = "Tennis" },
            };
        }
    }
}
