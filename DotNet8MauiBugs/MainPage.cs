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
                Label fullNameLabel = new Label { TextColor = Colors.Black };
                fullNameLabel.SetBinding(Label.TextProperty, nameof(Venue.FullName));
                Label cityLabel = new Label { TextColor = Colors.Black };
                cityLabel.SetBinding(Label.TextProperty, nameof(Venue.City));
                HorizontalStackLayout horizontalStackLayout = new HorizontalStackLayout { };

                Button editButton = new Button { Text = "EDIT", FontSize = 14, Padding = new Thickness(4), WidthRequest = 100, VerticalOptions = LayoutOptions.Center };
                editButton.SetBinding(Button.CommandProperty, new Binding(nameof(viewModel.EditVendorCommand), BindingMode.TwoWay, source: viewModel));
                editButton.SetBinding(Button.CommandParameterProperty, new Binding(".", BindingMode.TwoWay));
                Button changePasswordButton = new Button { Text = "CHANGE PASSWORD", FontSize = 14, Padding = new Thickness(4), WidthRequest = 200, VerticalOptions = LayoutOptions.Center };
                changePasswordButton.SetBinding(Button.CommandProperty, new Binding(nameof(viewModel.ChangePasswordCommand), BindingMode.TwoWay, source: viewModel));
                changePasswordButton.SetBinding(Button.CommandParameterProperty, new Binding(".", BindingMode.TwoWay));
                horizontalStackLayout.Children.Add(editButton);
                horizontalStackLayout.Children.Add(changePasswordButton);

                VerticalStackLayout verticalStackLayout = new VerticalStackLayout { WidthRequest = 350, Padding = 20, BackgroundColor = Color.FromArgb("#e6e6e6") };

                verticalStackLayout.Children.Add(fullNameLabel);
                verticalStackLayout.Children.Add(cityLabel);
                verticalStackLayout.Children.Add(horizontalStackLayout);
                return verticalStackLayout;


            });

            Padding = new Thickness(20);

            CollectionView collectionView = new CollectionView { };
          
            collectionView.ItemTemplate = venueTemplate;

            collectionView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {

                ItemSpacing = 20
            };

            collectionView.SetBinding(ItemsView.ItemsSourceProperty, nameof(viewModel.FilteredVendors));

            Content = new VerticalStackLayout
            {
                Children =
                {
                     collectionView
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