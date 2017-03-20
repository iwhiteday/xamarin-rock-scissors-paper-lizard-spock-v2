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
    class Combination
    {
        public int winner { get; set; }
        public int loser { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    if (GetType() != obj.GetType()) return false;

        //    Combination o = (Combination)obj;

        //    if (winner != o.winner) return false;
        //    if (loser != o.loser) return false;

        //    return true;
        //}

        //public override int GetHashCode()
        //{
        //    return winner * 7 + loser * 41;
        //}

        //public int CompareTo(Combination obj)
        //{
        //    if (this.GetHashCode() > obj.GetHashCode())
        //        return 1;
        //    else if (this.GetHashCode() < obj.GetHashCode())
        //        return -1;
        //    return 0;
        //}
    }

    enum Choice
    {
        Emtpy = 0,
        Rock = 1,
        Scissors = 2,
        Paper = 3,
        Lizard = 4,
        Spock = 5
    }

    static class Rules
    {
        private static List<Combination> winCombs = new List<Combination>();

        public static void setup()
        {
            if (winCombs.Count > 0) return; //prevent from duplicating list (might think about set instead of list)
            winCombs.Add(new Combination() { winner = (int)Choice.Rock, loser = (int)Choice.Scissors });
            winCombs.Add(new Combination() { winner = (int)Choice.Rock, loser = (int)Choice.Lizard });
            winCombs.Add(new Combination() { winner = (int)Choice.Scissors, loser = (int)Choice.Paper });
            winCombs.Add(new Combination() { winner = (int)Choice.Scissors, loser = (int)Choice.Lizard });
            winCombs.Add(new Combination() { winner = (int)Choice.Paper, loser = (int)Choice.Rock });
            winCombs.Add(new Combination() { winner = (int)Choice.Paper, loser = (int)Choice.Spock });
            winCombs.Add(new Combination() { winner = (int)Choice.Lizard, loser = (int)Choice.Paper });
            winCombs.Add(new Combination() { winner = (int)Choice.Lizard, loser = (int)Choice.Spock });
            winCombs.Add(new Combination() { winner = (int)Choice.Spock, loser = (int)Choice.Scissors });
            winCombs.Add(new Combination() { winner = (int)Choice.Spock, loser = (int)Choice.Rock });
        }

        public static bool winCheck(Combination comb)
        {
            int index = winCombs.FindIndex(g => g.winner == comb.winner && g.loser == comb.loser);
            return index >= 0;
        }
    }
}