using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class Digit : MonoBehaviour
{
    public DigitCreator digitCreator;

    private List<GameObject> digitSprites = new List<GameObject>();
    private DigitRef[] digitRefs;

    private void Awake()
    {
        if (digitCreator == null)
        {
            throw new System.Exception("Il n'y a pas de DigitCreator attribu� au digit.");
        }

        digitRefs = digitCreator.digitRefs;

        foreach(Transform t in transform)
        {
            digitSprites.Add(t.gameObject);
        }
    }

    private void ClearDigit()
    {
        foreach(GameObject gameObject in digitSprites)
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateDigit(int chiffreDeReference)
    {
        if(chiffreDeReference < 0 || chiffreDeReference > 9)
        {
            throw new System.Exception($"{gameObject} n'a pas r�ussi � montrer {chiffreDeReference}.");
        }

        if(digitSprites.Count == 0)
        {
            throw new System.Exception($"Aucun enfant n'a �t� trouv� dans {gameObject}.");
        }

        if(digitRefs == null || digitRefs.Length == 0)
        {
            throw new System.Exception($"Il y a eu un probl�me sur l'importation des r�f�rences digit depuis le DigitCreator.");
        }

        ClearDigit();

        int i = 0;
        foreach (bool boolean in digitRefs[chiffreDeReference].booleans)
        {
            digitSprites[i].SetActive(boolean);
            i++;
        }
    }
}
