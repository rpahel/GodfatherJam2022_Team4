using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private List<Digit> digits = new List<Digit>();

    private void Awake()
    {
        foreach (Transform t in transform)
        {
            digits.Add(t.GetComponent<Digit>());
        }

        if (digits == null || digits.Count == 0)
        {
            throw new System.Exception($"Aucun enfant n'a été trouvé dans {gameObject}.");
        }
    }

    public void UpdateScore(int scoreDeReference)
    {
        //
    }
}
