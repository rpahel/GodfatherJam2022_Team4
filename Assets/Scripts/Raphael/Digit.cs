using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using System.Linq;

public class Digit : MonoBehaviour
{
    public DigitCreator digitCreator;

    private int id;
    private List<GameObject> digitSprites = new List<GameObject>();
    private DigitRef[] digitRefs;
    public int ID { set { id = value; } }

    private void Start()
    {
        if (digitCreator == null)
        {
            throw new System.Exception("Il n'y a pas de DigitCreator attribu� au digit.");
        }
        
        foreach(Transform t in transform)
        {
            digitSprites.Add(t.gameObject);
        }

        digitRefs = digitCreator.digitRefs;
    }

    public void UpdateDigit(int score)
    {
        int digitRef = int.Parse(score.ToString("0000")[id].ToString());
        for (int i = 0; i < digitSprites.Count; i++)
        {
            digitSprites[i].SetActive(digitRefs[digitRef].booleans[i]);
            Debug.Log($"{gameObject} : {digitRefs[digitRef].booleans[i]}");
        }
    }
}
