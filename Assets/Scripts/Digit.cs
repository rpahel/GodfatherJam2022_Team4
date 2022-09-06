using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using System.Linq;

public class Digit : MonoBehaviour
{
    public DigitCreator digitCreator;

    [HideInInspector]
    public int id;
    private List<GameObject> digitSprites = new List<GameObject>();
    private DigitRef[] digitRefs;

    private void Start()
    {
        if (digitCreator == null)
        {
            throw new System.Exception("Il n'y a pas de DigitCreator attribué au digit.");
        }

        int digitRef = int.Parse(ScoreDisplay.Instance?.scoreDeTest.ToString("0000")[id].ToString());
        digitRefs = digitCreator.digitRefs;

        foreach(Transform t in transform)
        {
            digitSprites.Add(t.gameObject);
        }

        for (int i = 0; i < digitSprites.Count; i++)
        {
            digitSprites[i].SetActive(digitRefs[digitRef].booleans[i]);
        }
    }
}
