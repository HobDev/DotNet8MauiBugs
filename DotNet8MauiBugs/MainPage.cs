using CommunityToolkit.Maui.Markup;
using System.Collections.ObjectModel;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace DotNet8MauiBugs;

public class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
        Label timeLabel = new Label {FontSize=22 };
        timeLabel.SetBinding(Label.TextProperty, new MultiBinding
        {
            Bindings = new Collection<BindingBase>
                          {
                              new Binding(nameof(Booking.StartTime), stringFormat:"{0: HH.mm}"),
                               new Binding(nameof(Booking.EndTime), stringFormat:"{0: HH.mm}")
                          },
            StringFormat = "{0: HH.mm} - {1: HH.mm}",

        });
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

                          timeLabel,
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