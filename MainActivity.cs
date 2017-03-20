using Android.App;
using Android.Widget;
using Android.OS;

namespace task2
{
    [Activity(Label = "Scissors win 100%", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        GameModel model = new GameModel();
        Choice userChoice;
        Choice aiChoice;
        string score = "0 - 0";
        TextView userChoiceView;
        TextView aiChoiceView;
        TextView turnResultView;
        TextView scoreView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
                        
            SetContentView(Resource.Layout.Main);

            //the kostyl or not the kostyl, that's the question
            Rules.setup();

            Button rockBtn = FindViewById<Button>(Resource.Id.btnRock);
            rockBtn.Click += RockBtn_Click;

            Button scissorsBtn = FindViewById<Button>(Resource.Id.btnScissors);
            scissorsBtn.Click += ScissorsBtn_Click;

            Button paperBtn = FindViewById<Button>(Resource.Id.btnPaper);
            paperBtn.Click += PaperBtn_Click;

            Button lizardBtn = FindViewById<Button>(Resource.Id.btnLizard);
            lizardBtn.Click += LizardBtn_Click;

            Button spockBtn = FindViewById<Button>(Resource.Id.btnSpock);
            spockBtn.Click += SpockBtn_Click;

            Button lockBtn = FindViewById<Button>(Resource.Id.btnLock);
            lockBtn.Click += LockBtn_Click;

            userChoiceView = FindViewById<TextView>(Resource.Id.Yourchoice);
            aiChoiceView = FindViewById<TextView>(Resource.Id.AIchoice);
            turnResultView = FindViewById<TextView>(Resource.Id.Result);
            scoreView = FindViewById<TextView>(Resource.Id.Score);

            startTurn();
        }

        private void LockBtn_Click(object sender, System.EventArgs e)
        {
            if (userChoice == Choice.Emtpy) return; //might add notifier about empty choice
            userChoiceView.Text += "\nYour choice hash: " + model.choiceHash(userChoice);
            aiChoiceView.Text = "AI prev turn choice: " + aiChoice.ToString();
            aiChoiceView.Text += "\nAI prev turn choice hash: " + model.choiceHash(aiChoice);

            int turn_result = model.winDetermination(userChoice, aiChoice);
            string result = "";
            switch(turn_result)
            {
                case 1:
                    result = "You won!";
                    break;
                case -1:
                    result = "AI won";
                    break;
                case 0:
                    result = "Tie";
                    break;
            }
            score = "You " + model.userScore + " - " + model.aiScore + " AI";
            scoreView.Text = score;
            turnResultView.Text = result;

            startTurn();
        }

        private void SpockBtn_Click(object sender, System.EventArgs e)
        {
            userChoiceView.Text = "Your choice this turn : Spock";
            userChoice = Choice.Spock;
        }

        private void LizardBtn_Click(object sender, System.EventArgs e)
        {
            userChoiceView.Text = "Your choice this turn : Lizard";
            userChoice = Choice.Lizard;
        }

        private void PaperBtn_Click(object sender, System.EventArgs e)
        {
            userChoiceView.Text = "Your choice this turn : Paper";
            userChoice = Choice.Paper;
        }

        private void ScissorsBtn_Click(object sender, System.EventArgs e)
        {
            userChoiceView.Text = "Your choice this turn : Scissors";
            userChoice = Choice.Scissors;
        }

        private void RockBtn_Click(object sender, System.EventArgs e)
        {
            userChoiceView.Text = "Your choice this turn : Rock";
            userChoice = Choice.Rock;
        }

        private void startTurn()
        {
            userChoice = Choice.Emtpy;
            aiChoice = model.aiChoice();
            aiChoiceView.Text += "\nAI this turn choice hash: " + model.choiceHash(aiChoice);
        }
    }
}

