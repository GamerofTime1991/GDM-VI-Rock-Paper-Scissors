using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class manager : MonoBehaviour
{
    public TMP_Text result;
    public Image aichoice;

    public string[] Choices;
    public Sprite Rock, Paper, Scissors;

    public void Play(string myChoice)
    {
        string randomChoice = Choices[Random.Range(0, Choices.Length)];

        switch(randomChoice) 
        {
            case "Rock":
                switch(myChoice)
                {
                    case "Rock":
                        result.text = "Tie";
                        break;
                    case "Paper":
                        result.text = "You Win";
                        break;
                    case "Scissors":
                        result.text = "You Lose";
                        break;
                }
                aichoice.sprite = Rock;
                break;
            case "Paper":
                switch (myChoice)
                {
                    case "Rock":
                        result.text = "You Lose";
                        break;
                    case "Paper":
                        result.text = "Tie";
                        break;
                    case "Scissors":
                        result.text = "You Win";
                        break;
                }
                aichoice.sprite = Paper;
                break;
            case "Scissors":
                switch (myChoice)
                {
                    case "Rock":
                        result.text = "You Win";
                        break;
                    case "Paper":
                        result.text = "You Lose";
                        break;
                    case "Scissors":
                        result.text = "Tie";
                        break;
                }
                aichoice.sprite = Scissors;
                break;
        }
    }
}
