using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Com.Hitomi.Cmlibrary;
using Android.Graphics;
using System;
using Com.Tapadoo.Alerter;

namespace task2
{
    [Activity(Label = "Scissors win 100%", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity, IOnMenuSelectedListener
    {
        GameModel model = new GameModel();
        Choice userChoice;
        Choice aiChoice;
        string score = "0 - 0";
        TextView userChoiceView;
        TextView aiChoiceView;
        TextView scoreView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
                        
            SetContentView(Resource.Layout.Main);

            //the kostyl or not the kostyl, that's the question
            Rules.setup();

            var circle_menu = FindViewById<CircleMenu>(Resource.Id.circleMenu);
            circle_menu.SetMainMenu(Color.ParseColor("#CDCDCD"), Resource.Drawable.play, Resource.Drawable.close)
                .AddSubMenu(Color.ParseColor("#258CFF"), Resource.Drawable.rock)
                .AddSubMenu(Color.ParseColor("#258CFF"), Resource.Drawable.scissors)
                .AddSubMenu(Color.ParseColor("#258CFF"), Resource.Drawable.paper)
                .AddSubMenu(Color.ParseColor("#258CFF"), Resource.Drawable.lizard)
                .AddSubMenu(Color.ParseColor("#258CFF"), Resource.Drawable.spock)
                .SetOnMenuSelectedListener(this);

            userChoiceView = FindViewById<TextView>(Resource.Id.Yourchoice);
            aiChoiceView = FindViewById<TextView>(Resource.Id.AIchoice);
            scoreView = FindViewById<TextView>(Resource.Id.Score);

            startTurn();
        }

        private int getResourceIdByChoice(Choice choice)
        {
            switch(choice)
            {
                case (Choice.Rock):
                    return Resource.Drawable.rock;
                case (Choice.Scissors):
                    return Resource.Drawable.scissors;
                case (Choice.Paper):
                    return Resource.Drawable.paper;
                case (Choice.Lizard):
                    return Resource.Drawable.lizard;
                case (Choice.Spock):
                    return Resource.Drawable.spock;
                default:
                    return Resource.Drawable.lose;

            }
        }

        private void Lock()
        {
            if (userChoice == Choice.Emtpy) return; //might add notifier about empty choice

            ImageView yourimg = FindViewById<ImageView>(Resource.Id.YourImage);
            ImageView aiimg = FindViewById<ImageView>(Resource.Id.AIImage);

            yourimg.SetImageResource(getResourceIdByChoice(userChoice));
            aiimg.SetImageResource(getResourceIdByChoice(aiChoice));

            aiChoiceView.Text = "String salt was: " + model.salt + " | Hash(" + model.salt + aiChoice.ToString() + ") = " + model.choiceHash(aiChoice);

            int turn_result = model.winDetermination(userChoice, aiChoice);
            string result = "";
            int color = 0;
            int icon = 0;
            switch(turn_result)
            {
                case 1:
                    result = "You won!";
                    color = Resource.Color.win;
                    icon = Resource.Drawable.win;
                    break;
                case -1:
                    result = "You lose :<";
                    color = Resource.Color.lose;
                    icon = Resource.Drawable.lose;
                    break;
                case 0:
                    result = "Tie";
                    color = Resource.Color.material_deep_teal_500;
                    icon = Resource.Drawable.tie;
                    break;
            }
            Alerter.Create(this)
                .SetTitle(result)
                .SetBackgroundColor(color)
                .SetDuration(500)
                .SetIcon(icon)
                .Show();
            score = "You " + model.userScore + " - " + model.aiScore + " AI";
            scoreView.Text = score;

            startTurn();
        }

        public void OnMenuSelected(int index)
        {
            userChoice = (Choice)(index + 1);
            Lock();
        }

        private void startTurn()
        {
            userChoice = Choice.Emtpy;
            aiChoice = model.aiChoice();
            aiChoiceView.Text += "\nAI this turn choice hash: " + model.choiceHash(aiChoice);
        }
    }
}

