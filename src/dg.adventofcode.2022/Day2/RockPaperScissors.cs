using System;
using System.Collections.Generic;
using System.Linq;

namespace dg.adventofcode._2022.Day2;

public static class RockPaperScissors
{
    private static readonly List<RpsValue> RpsValues = new()
    {
        new RpsValue
        {
            Key = "Rock",
            Values = new List<string>
            {
                "A",
                "X"
            },
            Score = 1
        },
        new RpsValue
        {
            Key = "Paper",
            Values = new List<string>
            {
                "B",
                "Y"
            },
            Score = 2
        },
        new RpsValue
        {
            Key = "Scissors",
            Values = new List<string>
            {
                "C",
                "Z"
            },
            Score = 3
        },
    };

    private static Dictionary<string, string> letterToPlayMapping = new Dictionary<string, string>
    {
        { "X", "Lose" },
        { "Y", "Draw" },
        { "Z", "Win" }
    };

    private const int LosePoints = 0;
    private const int DrawPoints = 3;
    private const int WinPoints = 6;

    public static int CalcStratScore(List<string> input)
    {
        var combinedScore = 0;
        foreach (var play in input)
        {
            var players = play.Split(' ');
            var opponentPlayed = RpsValues.First(rp => rp.Values.Contains(players[0]));
            var playerPlayed = RpsValues.First(rp => rp.Values.Contains(players[1]));
            
            var result = GameResult(opponentPlayed.Key, playerPlayed.Key);
            combinedScore += CalcScore(result, playerPlayed);
        }
        return combinedScore;
    }

    public static int CalcStratScorePart2(List<string> input)
    {
        var combinedScore = 0;
        foreach (var play in input)
        {
            var players = play.Split(' ');
            var opponentPlayed = RpsValues.First(rp => rp.Values.Contains(players[0]));

            var stratSelection = GetAppropriatePlay(opponentPlayed.Key, letterToPlayMapping[players[1]]);
            var playerPlayed = RpsValues.First(rp => rp.Key == stratSelection);
            
            var result = GameResult(opponentPlayed.Key, playerPlayed.Key);
            combinedScore += CalcScore(result, playerPlayed);
        }
        return combinedScore;
    }

    private static string GameResult(string opponent, string player)
    {
        if (opponent == player)
            return "Draw";

        return opponent switch
        {
            "Rock" when player == "Paper" => "Win",
            "Rock" => "Lose",
            "Paper" when player == "Scissors" => "Win",
            "Paper" => "Lose",
            _ => player == "Rock" ? "Win" : "Lose"
        };
    }

    private static string GetAppropriatePlay(string opponent, string strat)
    {
        if (strat == "Draw")
            return opponent;

        return opponent switch
        {
            "Rock" when strat == "Win" => "Paper",
            "Rock" => "Scissors",
            "Paper" when strat == "Win" => "Scissors",
            "Paper" => "Rock",
            _ => strat == "Win" ? "Rock" : "Paper"
        };
    }

    private static int CalcScore(string result, RpsValue playerInput)
    {
        return result switch
        {
            "Win" => WinPoints + playerInput.Score,
            "Draw" => DrawPoints + playerInput.Score,
            "Lose" => LosePoints + playerInput.Score,
            _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
        };
    }
}

public class RpsValue
{
    public string Key { get; set; }
    public List<string> Values { get; set; }
    public int Score { get; set; }
}