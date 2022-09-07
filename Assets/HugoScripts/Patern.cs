using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern : MonoBehaviour
{
    public CatController catController;
    public CatMoves[] catMoves;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CatPatern()
    {
        for (int i = 0; i < catMoves.Length; i++)
        {
            
            for (int j = 0; j < catMoves[i].catPaws.Length; j++)
            {
                catMoves[i].catPaws[j].exclamation.SetActive(true);
            }

            yield return new WaitForSeconds(catController.attackDelay);

            if (i != 0)
            {
                for(int l = 0; l < catMoves[i-1].catPaws.Length; l++)
                {
                    catMoves[i-1].catPaws[l].exclamation.SetActive(false);
                    catMoves[i-1].catPaws[l].paw.SetActive(false);

                }
            }

            for (int k = 0; k < catMoves[i].catPaws.Length; k++)
            {
                catMoves[i].catPaws[k].paw.SetActive(true);
            }


        }

        yield return new WaitForSeconds(catController.attackDelay);

        catController.DisablePaws();
    }

    public void Play()
    {
        catController.DisablePaws();

        StartCoroutine(CatPatern());
    }
}
