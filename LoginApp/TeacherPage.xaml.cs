namespace LoginApp;

public partial class TeacherPage : ContentPage
{
	public TeacherPage()
	{
		InitializeComponent();
		BindingContext = QuestionBank.LoadFromFile();
	}

    private void AddSection_Clicked(object sender, EventArgs e)
    {
		if (BindingContext is QuestionBank bank)
		{
			bank.Sections.Add(new Section { Name = SectionName.Text });
			bank.SaveToFile();
		}
    }

    private void EventTrigger_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
		DisplayAlert("", "Clicked on Grid","Cancel");
    }

    private void Section_Tabbed(object sender, TappedEventArgs e)
    {
		var param = new Dictionary<string, object?>()
		{
			{"Section",  (sender as Grid)?.BindingContext as Section},
			{"QuestionBank",  BindingContext as QuestionBank}
		};
		Shell.Current.GoToAsync("///SectionPage", param);
    }
}