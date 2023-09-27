using CommunityToolkit.Maui.Markup;

namespace DotNet8MauiBugs;

public class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
        try
        {

            DataTemplate venueTemplate = new DataTemplate(() =>
            {

                return new VerticalStackLayout
                {
                    WidthRequest = 350,
                    Padding = 20,
                    
                    BackgroundColor = Color.FromArgb("#e6e6e6"),
                    Children =
                    {


                          new Label{ TextColor=Colors.Black }.Bind(Label.TextProperty, nameof(Venue.FullName)),
                          new Label{TextColor=Colors.Black }.Bind(Label.TextProperty, nameof(Venue.City)),
                          new HorizontalStackLayout
                          {
                               new Button{ Text= "EDIT",  FontSize=14,  Padding = new Thickness(4), WidthRequest=100, VerticalOptions= LayoutOptions.Center }.BindCommand(nameof(viewModel.EditVendorCommand), source:viewModel, parameterPath: "."),
                           new Button{ Text= "CHANGE PASSWORD",  FontSize=14,  Padding = new Thickness(4), WidthRequest=200, VerticalOptions= LayoutOptions.Center}.BindCommand(nameof(viewModel.ChangePasswordCommand), source:viewModel, parameterPath: "."),
                          },


                    }
                };


            });

            Padding = new Thickness(20);
            Content = new VerticalStackLayout
            {
                Children =
            {
                

           new CollectionView
            {
                ItemSizingStrategy= ItemSizingStrategy.MeasureFirstItem,
               // ItemsSource= viewModel.FilteredVendors,
                ItemTemplate = venueTemplate,
                ItemsLayout = new GridItemsLayout(3,ItemsLayoutOrientation.Vertical)
                {
                    HorizontalItemSpacing = 0,
                    VerticalItemSpacing=20
                },

            }.Bind(ItemsView.ItemsSourceProperty, nameof(viewModel.FilteredVendors)),
            }
            };

            BindingContext = viewModel;
        }
        catch (Exception ex)
        {

            Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}