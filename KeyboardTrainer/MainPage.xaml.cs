namespace KeyboardTrainer
{
    public partial class MainPage : ContentPage
    {
        string[] Levels = [
            "",
            "Passion is momentary; love is enduring.",
            "Art will never be able to exist without nature.",
            "Truth is strong, and sometime or other will prevail.",
            "The man who is swimming against the stream knows the strength of it.",
            "Bachelors know more about women than married men; if they didn't they'd be married too."
            ];
        public MainPage()
        {
            InitializeComponent();
        }

        private void Difficulty_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            LblDifficulty.Text = ((int)e.NewValue).ToString();
        }

        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            BtnStop.IsEnabled = true;
            BtnStart.IsEnabled = false;
            LblSample.Text = Levels[Convert.ToInt32(LblDifficulty.Text)];
        }

        private void BtnStop_Clicked(object sender, EventArgs e)
        {
            BtnStop.IsEnabled = false;
            BtnStart.IsEnabled = true;
        }
        string sample="", userTyped="";
        private void LblUserTyped_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LblUserTyped != null)
            {
                sample += LblSample.Text.Substring(0, LblUserTyped.Text.Length);
                userTyped += LblUserTyped.Text;
                FlexSample.Children.Clear();
                FlexUserTyped.Children.Clear();
                for (int i=0; i< userTyped.Length; i++)
                {
                    if (userTyped[i] == sample[i])
                    {
                        FlexSample.Children.Add(new Label { Text=""+sample[i], 
                            Background=Colors.LightGreen, FontFamily="Consolas" });
                        FlexUserTyped.Children.Add(new Label
                        {
                            Text = "" + sample[i],
                            Background = Colors.LightGreen,
                            FontFamily = "Consolas"
                        });
                    }
                    else
                    {
                        FlexSample.Children.Add(new Label
                        {
                            Text = "" + sample[i],
                            Background = Colors.Red,
                            FontFamily = "Consolas"
                        });
                        FlexUserTyped.Children.Add(new Label
                        {
                            Text = "" + userTyped[i],
                            Background = Colors.Red,
                            FontFamily = "Consolas"
                        });
                    }
                }
                
                LblSample.Text = LblSample.Text.Substring(LblUserTyped.Text.Length);
                LblUserTyped.Text = "";
            }
            
        }
    }

}
