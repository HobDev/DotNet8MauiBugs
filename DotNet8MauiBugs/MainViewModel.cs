

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace DotNet8MauiBugs
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Booking> bookings;


        public MainViewModel()
        {
            Bookings = new ObservableCollection<Booking>
            {
                new Booking { StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Title = "Meeting 1" },
                new Booking { StartTime = DateTime.Now.AddHours(1), EndTime = DateTime.Now.AddHours(2), Title = "Meeting 2" },
            };

        }
    }
}
