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
}