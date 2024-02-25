using System;
using System.Collections.Generic;
using UnityEngine;

public class scoreTracker : MonoBehaviour
{
    public static int player1_score = 0;
    public static int player2_score = 0;
    public static int player3_score = 0;

    // public static int level = 0;
    public static List<string> player1Keys = new List<string>(){"Q", "W", "E", "R", "T", "A", "S", "D", "F", "G", "Z", "X", "C"};
    public static List<string> player2Keys = new List<string>(){"Y", "U", "I", "O", "P", "H", "J", "K", "L", "V", "B", "N", "M"};

    void Start()
    {
        // if (level == 0)
        // {
        //     player1Keys = new List<string>{"Q", "W", "E", "R", "T", "A", "S", "D", "F", "G", "Z", "X", "C"};
        //     player2Keys = new List<string>{"Y", "U", "I", "O", "P", "H", "J", "K", "L", "V", "B", "N", "M"};
        // }

        // if (level == 1)
        // {
        //     GenerateLists();
        // }
    }

    void givePlayerPoint(int playerID)
    {
        switch (playerID)
        {
            case 1: 
                player1_score += 1;
                break;
            case 2:
                player2_score += 1;
                break;
            case 3:
                player3_score += 1;
                break;
        }
    }

    void resetPlayerPoint(int playerID)
    {
        switch (playerID)
        {
            case 1: 
                player1_score = 0;
                break;
            case 2:
                player2_score = 0;
                break;
            case 3:
                player3_score = 0;
                break;
        }
    }

    public static void GenerateLists()
    {
        char[] alphabet = { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };
        List<char> shuffledAlphabet = new List<char>(alphabet);
        Shuffle(shuffledAlphabet);

        List<char> list1 = shuffledAlphabet.GetRange(0, 13);
        List<char> list2 = shuffledAlphabet.GetRange(13, 13);

        player1Keys = list1.ConvertAll(letter => letter.ToString());
        player2Keys = list2.ConvertAll(letter => letter.ToString());
    }

    public static void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void Update()
    {
        // Update logic here
    }
}
