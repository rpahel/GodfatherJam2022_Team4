using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern : MonoBehaviour
{
    private CatController catController;
    public CatMoves[] catMoves;

    [HideInInspector] public bool isOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        catController = GameManager.Instance.catController;
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

            //if (i != 0)
            //{
            //    for(int l = 0; l < catMoves[i-1].catPaws.Length; l++)
            //    {
            //        catMoves[i-1].catPaws[l].exclamation.SetActive(false);
            //        catMoves[i-1].catPaws[l].paw.SetActive(false);

            //    }
            //}

            for (int k = 0; k < catMoves[i].catPaws.Length; k++)
            {
                catMoves[i].catPaws[k].paw.SetActive(true);

                //if (catMoves[i].catPaws[k].playerOnPaw)
                //    GameManager.Instance.player.TakeDamage();

            }

            yield return new WaitForSeconds(catController.stayDelay);

            for (int l = 0; l < catMoves[i].catPaws.Length; l++)
            {
                catMoves[i].catPaws[l].exclamation.SetActive(false);
                catMoves[i].catPaws[l].paw.SetActive(false);

            }

            yield return new WaitForSeconds(catController.stayDelay);

            if(GameManager.Instance.player.gameLaunched)
                GameManager.Instance.player.scoreHour.UpdateScore(++GameManager.Instance.score);

        }

        GameManager.Instance.catController.PlayPatern();
        //catController.DisablePaws();
    }

    public void Play()
    {
        catController = GameManager.Instance.catController;
        catController.DisablePaws();
        isOver = false;

        StartCoroutine(CatPatern());
    }
}
