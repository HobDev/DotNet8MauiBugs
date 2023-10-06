using CommunityToolkit.Maui.Markup;
using System.Collections.ObjectModel;

namespace DotNet8MauiBugs;

public class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
       

        Content = new VerticalStackLayout
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                 new CollectionView
                 {
                     ItemsSource=viewModel.Bookings,
                     ItemTemplate= new DataTemplate(()=>
                     {
                         return new VerticalStackLayout
                         {
                             BackgroundColor=Colors.LightBlue,
                             Children =
                             {
                                 new Label {}.Bind(Label.TextProperty, nameof(Booking.Title)),
                                 new Label {FontSize=22 }.Bind(Label.TextProperty,
                   binding1: new Binding(nameof(Booking.StartTime), stringFormat:"{0: HH.mm}"),
                   binding2: new Binding(nameof(Booking.EndTime), stringFormat:"{0: HH.mm}"),
                   convert: ((string start, string end)values)=> $"{values.start}-{values.end}"),
                             }
                         };
                     }),
                     ItemSizingStrategy=ItemSizingStrategy.MeasureFirstItem,

                     ItemsLayout= new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
                     {
                        
                     }
                 }
            }
		};

		BindingContext = viewModel;
	}
}