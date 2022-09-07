using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DigitsDisplay : MonoBehaviour
{
    private List<Digit> digits = new List<Digit>();
    private GameObject am, pm, colonObj;
    private DateTime localDate;
    private CultureInfo culture;

    public Transform amPm, colon;

    private void Start()
    {
        culture = new CultureInfo("en-US");
        CultureInfo.CurrentCulture = culture;

        int i = 0;
        foreach(Transform child in transform)
        {
            Digit digit;
            if (child.TryGetComponent<Digit>(out digit))
            {
                digit.ID = i;
                digits.Add(digit);
                i++;
            }
        }

        if(amPm.childCount != 2)
        {
            throw new System.Exception($"L'objet AmPm de {gameObject} doit seulement avoir deux enfants.");
        }
        else
        {
            am = amPm.GetChild(0).gameObject;
            pm = amPm.GetChild(1).gameObject;
        }

        colonObj = colon.gameObject;

        UpdateTime();
    }

    public void UpdateScore(int score)
    {
        if(am.activeSelf || pm.activeSelf || colonObj.activeSelf)
        {
            am.SetActive(false);
            pm.SetActive(false);
            colonObj.SetActive(false);
        }

        score = Mathf.Clamp(score, 0, 9999);
        foreach(Digit digit in digits)
        {
            digit.UpdateDigit(score);
        }
    }

    public void UpdateTime()
    {
        localDate = DateTime.Now;
        string localDateString = localDate.ToString("hhmmt");
        print(localDateString);

        if(localDateString[4] == 'A')
        {
            am.SetActive(true);
            pm.SetActive(false);
        }
        else
        {
            am.SetActive(false);
            pm.SetActive(true);
        }

        if (!colonObj.activeSelf)
        {
            colonObj.SetActive(true);
        }

        int localTime = int.Parse(localDateString.Substring(0, 4));
        foreach (Digit digit in digits)
        {
            digit.UpdateDigit(localTime);
        }
    }
}
