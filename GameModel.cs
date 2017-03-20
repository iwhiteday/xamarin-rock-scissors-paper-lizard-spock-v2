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
        private int salt = 41;
        private int turn;
        public int userScore { get; private set; }
        public int aiScore { get; private set; }

        public GameModel()
        {
            turn = 1;
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
            return (int)choice * salt * turn;
        }
        //also got idea about generating random salt each turn
        //more random - less debug
        //idk

        public int winDetermination(Choice userChoice, Choice aiChoice)
        {
            turn++;
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


    }
}