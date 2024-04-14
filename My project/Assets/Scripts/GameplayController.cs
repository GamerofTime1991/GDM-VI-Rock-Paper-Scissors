using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite;

    [SerializeField]
    private Image playerChoice_img, opponentChoice_img;

    [SerializeField]
    private Text infoText;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;

    private AnimationController animationController;

    public int currentSceneIndex;
    public int nextLevelIndex;


    void Awake()
    {
        animationController = GetComponent<AnimationController>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextLevelIndex = currentSceneIndex + 1;

    }

    public void SetChoices(GameChoices choices)
    {
        switch(choices)
        {
            case GameChoices.ROCK:
                playerChoice_img.sprite = rock_Sprite;
                player_Choice= GameChoices.ROCK;

                break;

            case GameChoices.PAPER:
                playerChoice_img.sprite = paper_Sprite;
                player_Choice = GameChoices.PAPER;
                break; 

            case GameChoices.SCISSORS:
                playerChoice_img.sprite = scissors_Sprite;
                player_Choice = GameChoices.SCISSORS;
                break;
        }
        //switch / case

        SetOpponentChoice();

        DetermineWinner();
    }

    void SetOpponentChoice()
    {
        int rnd = Random.Range(0, 3);

        switch (rnd)
        {
            case 0:
                opponent_Choice = GameChoices.ROCK;

                opponentChoice_img.sprite = rock_Sprite;

                break;
            case 1:
                opponent_Choice = GameChoices.PAPER;

                opponentChoice_img.sprite = paper_Sprite;

                break;
            case 2:
                opponent_Choice = GameChoices.SCISSORS;

                opponentChoice_img.sprite = scissors_Sprite;

                break;
        }
    }

    void DetermineWinner()
    {
        if(player_Choice == opponent_Choice)
        {
            infoText.text = "It's a Draw!";
            StartCoroutine(DisplayDrawAndTryAgain());

            return;

        }

        if(player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK)
        {
            //player won
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnerAndContinue());
            
            
            
        }

        if (opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK)
        {
            //opponent won
            infoText.text = "You got outsmarted by a Monkey! Try Again!";
            StartCoroutine(DisplayLoserAndRestart());

            return;
        }

        if (player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS)
        {
            //player won
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnerAndContinue());
            return;
        }

        if (opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS)
        {
            //opponent won
            infoText.text = "You got outsmarted by a Monkey! Try Again!";
            StartCoroutine(DisplayLoserAndRestart());

            return;
        }

        if (player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER)
        {
            //player won
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnerAndContinue());
            
            return;
        }

        if (opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.PAPER)
        {
            //opponent won
            infoText.text = "You got outsmarted by a Monkey! Try Again!";
            StartCoroutine(DisplayLoserAndRestart());

            return;
        }

    }

    IEnumerator DisplayWinnerAndContinue()
    {
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        SceneManager.LoadScene(nextLevelIndex);
    }

    IEnumerator DisplayLoserAndRestart()
    {
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        SceneManager.LoadScene(0);
    }

    IEnumerator DisplayDrawAndTryAgain()
    {
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations();
    }



}
