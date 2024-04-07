
namespace LoginApp;

public partial class SectionPage : ContentPage, IQueryAttributable
{
	private Section section;

	public Section Section
	{
		get { return section; }
		set { section = value;OnPropertyChanged(); }
	}
	private QuestionBank questionBank;

	public QuestionBank QuestionBank
	{
		get { return questionBank; }
		set { questionBank = value; OnPropertyChanged(); }
	}


	public SectionPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
		Section = (query["Section"] as Section)??new Section();
		QuestionBank = (query["QuestionBank"] as QuestionBank)??new QuestionBank();
		//QuestionBank.SaveToFile();
    }

    private void AddQuestion_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("///QuestionPage");
    }
}