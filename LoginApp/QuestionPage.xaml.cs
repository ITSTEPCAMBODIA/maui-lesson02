namespace LoginApp;

public partial class QuestionPage : ContentPage
{
	public QuestionPage()
	{
		InitializeComponent();
	}

    private void AddAnswer_Clicked(object sender, EventArgs e)
    {
		if(BindingContext is Question question)
		{
			question.Answers.Add("New Answer");
		}
    }
}