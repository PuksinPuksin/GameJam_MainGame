using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utill;
public class PPAnimation : MonoBehaviour
{
    public Sequence mySequence;
    public Sequence mySequence2;
    public void Animation(GameObject gameObject)
    {
        mySequence ??= Dotween.PopUpAnimation(gameObject);
        mySequence.Restart();
    }
    public void Animation2(GameObject gameObject)
    {
        mySequence2 ??= Dotween.PopUpAnimation(gameObject);
        mySequence2.Restart();
    }
    public void Back(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
