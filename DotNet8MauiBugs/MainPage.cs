using CommunityToolkit.Maui.Markup;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace DotNet8MauiBugs;

public class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
       
        Content = Content = new CollectionView
        {
            HorizontalOptions = LayoutOptions.Center,    
           

            ItemTemplate = new DataTemplate(() =>
            {
                return new VerticalStackLayout
                {

                    Padding = new Thickness(5),
                    BackgroundColor = Colors.LightGray,


                    Children =
                            {

                   new Label {FontSize=22 }.Bind(Label.TextProperty,
                   binding1: new Binding(nameof(Booking.StartTime), stringFormat:"{0: HH.mm}"),
                   binding2: new Binding(nameof(Booking.EndTime), stringFormat:"{0: HH.mm}"),
                   convert: ((string start, string end)values)=> $"{values.start}-{values.end}"),
                new Label { FontSize=22}.Bind(Label.TextProperty, nameof(Booking.PlayerName)),


                    new Label {FontSize = 22}.Bind(Label.TextProperty, nameof(Booking.GameName)),



                            }
                };
               
            }),
            ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing= 10 
            },
            ItemSizingStrategy = ItemSizingStrategy.MeasureFirstItem,
            ItemsSource = viewModel.Bookings,

        };

		BindingContext = viewModel;
	}
}