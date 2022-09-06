using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreDisplay : MonoBehaviour
{
    private List<Digit> digits = new List<Digit>();

    private void Start()
    {
        int i = 0;
        foreach(Transform child in transform)
        {
            Digit digit = child.GetComponent<Digit>();
            digit.ID = i;
            digits.Add(digit);
            i++;
        }
    }

    public void UpdateScore(int score)
    {
        score = Mathf.Clamp(score, 0, 9999);
        foreach(Digit digit in digits)
        {
            digit.UpdateDigitForScore(score);
        }
    }
}
