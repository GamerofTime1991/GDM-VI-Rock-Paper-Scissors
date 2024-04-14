using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator playerchoiceHandlerAnimation, choiceAnimation, monkeyEntranceAnimator;

    public void Start()
    {
        monkeyEntranceAnimator.Play("Appear");
    }

    public void ResetAnimations()
    {
        playerchoiceHandlerAnimation.Play("ShowHandler");
        choiceAnimation.Play("RemoveChoices");
        
    }

    public void PlayerMadeChoice()
    {
        playerchoiceHandlerAnimation.Play("RemoveHandler");
        choiceAnimation.Play("ShowChoices");
    }
}
