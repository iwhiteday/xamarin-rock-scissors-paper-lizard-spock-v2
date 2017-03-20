using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace task2
{

    class GameModel
    {
        public string salt { get; private set; }
        public int userScore { get; private set; }
        public int aiScore { get; private set; }

        public GameModel()
        {
            salt = randomString(5);
            userScore = 0;
            aiScore = 0;
        }

        public Choice aiChoice()
        {
            Random random = new Random();
            Choice result = (Choice)random.Next(1, 5);
            return result;
        }

        public int choiceHash(Choice choice)
        {
            return (salt + choice.ToString()).GetHashCode();
        }
        //also got idea about generating random salt each turn
        //more random - less debug
        //idk

        public int winDetermination(Choice userChoice, Choice aiChoice)
        {
            salt = randomString(5);
            //if user got win combination - win to user
            if (Rules.winCheck(new Combination() { winner = (int)userChoice, loser = (int)aiChoice }))
            {
                userScore++;
                return 1;
            }
            //if ai did - win to ai
            if (Rules.winCheck(new Combination() { winner = (int)aiChoice, loser = (int)userChoice }))
            {
                aiScore++;
                return -1;
            }
            //else tie
            return 0;
        }

        private string randomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}