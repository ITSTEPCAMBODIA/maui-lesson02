namespace LoginApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            if (Username.Text == null)
            {
                await DisplayAlert("Validation Error", "Username is required.", "Ok");
                return;
            }
            if (Password.Text == null)
            {
                await DisplayAlert("Validation Error", "Password is required.", "Ok");
                return;
            }
            if(Username.Text == "student" &&
                Password.Text == "123")
            {
                await Shell.Current.GoToAsync("///DashboardPage");
            }
            else
            {
                await DisplayAlert("Validation Error", "Invalid username or password.", "Ok");
                return;
            }
        }
    }

}
