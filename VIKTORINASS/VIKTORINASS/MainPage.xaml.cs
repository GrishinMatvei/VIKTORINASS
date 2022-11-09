using System;
using Xamarin.Forms;
using VIKTORINASS.DataBase;
using VIKTORINASS.Domain; 
using System.Linq; 
using System.Threading;

namespace VIKTORINASS
{
    public partial class MainPage : ContentPage
    {
        int QuestionCount = 0;
        int RightQuestions = 0;
        public MainPage()
        {
            InitializeComponent();
            QuestionGenerator();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (Convert.ToInt32(btn.AutomationId) != Questions.questions[QuestionCount].RightAnswerId)
            {   
                DisplayAlert("Не красава", $"Абоба", "Блинб((");
                QuestionCount++;
                QuestionGenerator();
                return;
            }

            RightQuestions++;
            QuestionCount++;
            QuestionGenerator();
        }
         
        private void QuestionGenerator()
        {
            if (QuestionCount == Questions.questions.Length)
            {
                DisplayAlert("Поздравляю!", $"Вы победили! Ваш счёт: {RightQuestions}", "Ура!");
                QuestionCount = 0;
                RightQuestions = 0;
                QuestionGenerator();
                return;
            }

            Question question = Questions.questions[QuestionCount];
            voproslbl.Text = $"Вопросик {QuestionCount + 1} из 10";
            voprosImage.Source = question.PhotoUrl;
            questionView.Text = question.Title;
            ButtonSpawn(question);
        }

        private void ButtonSpawn(Question question)
        {
            buttons.Children.Clear();

            Random random = new Random();

            int left = random.Next(0, 2);
            int top = random.Next(0, 2);

            Button trueButton = new Button
            {
                Text = Answers.answers[question.RightAnswerId].Title,
                AutomationId = question.RightAnswerId.ToString()
            };
            trueButton.Clicked += Button_Clicked;

            buttons.Children.Add(trueButton, left, top);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (i == left && j == top) continue;

                    int index = random.Next(0, Answers.answers.Length);

                    #region Не открывать! Опасный котТ! Угрожает психике!
                    bool isHaveDoubles = buttons.Children.FirstOrDefault(c => Convert.ToInt32(c.AutomationId) == index) == null ? false : true;
                    #endregion

                    if (index == question.RightAnswerId || isHaveDoubles)
                        index = random.Next(0, Answers.answers.Length);

                    Button button = new Button
                    {
                        Text = Answers.answers[index].Title,
                        AutomationId = index.ToString()
                    };
                    button.Clicked += Button_Clicked;

                    buttons.Children.Add(button, i, j);
                }
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());


        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}
