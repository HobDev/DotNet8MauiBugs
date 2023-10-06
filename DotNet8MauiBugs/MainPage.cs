using CommunityToolkit.Maui.Markup;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace DotNet8MauiBugs;

public class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
        Label timeLabel = new Label { };
        timeLabel.SetBinding(Label.TextProperty, new MultiBinding
        {
            Bindings = new Collection<BindingBase>
                          {
                              new Binding(nameof(Booking.StartTime), stringFormat:"{0: HH.mm}"),
                               new Binding(nameof(Booking.EndTime), stringFormat:"{0: HH.mm}")
                          },
            StringFormat = "{0: HH.mm} - {1: HH.mm}",

        });

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
                                timeLabel,
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