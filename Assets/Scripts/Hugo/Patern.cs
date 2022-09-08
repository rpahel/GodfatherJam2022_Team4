using System.Collections;
using System.Collections.Generic;
using Difficulty;
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

            AudioManager.Instance.CatCareful();

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
                AudioManager.Instance.CatPaw();

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

            if (GameManager.Instance.player.gameLaunched)
            {
                GameManager.Instance.player.scoreHour.UpdateScore(++GameManager.Instance.score);
                GameManager.Instance.scoreDifficulty++;
                Debug.Log(GameManager.Instance.scoreDifficulty);

                switch (GameManager.Instance.scoreDifficulty)
                {
                    case 5:
                        catController.attackDelay -= catController.changeSpeed;
                        catController.difficultyType = DifficultyType.EASY;
                        break;
                    case 10:
                        catController.attackDelay = catController.attackDelayNormal;
                        catController.difficultyType = DifficultyType.NORMAL;
                        break;
                    case 15:
                        catController.attackDelay -= catController.changeSpeed;
                        catController.difficultyType = DifficultyType.NORMAL;
                        break;
                    case 20:
                        catController.attackDelay = catController.attackDelayNormal;
                        catController.difficultyType = DifficultyType.HARD;
                        break;
                    case 25:
                        catController.attackDelay -= catController.changeSpeed;
                        catController.difficultyType = DifficultyType.HARD;
                        break;
                    default:
                        break;
                }

                if (GameManager.Instance.scoreDifficulty >= 30 && GameManager.Instance.scoreDifficulty % 5 == 0)
                {
                    catController.attackDelay -= catController.changeSpeedAlways;
                    catController.attackDelay = Mathf.Clamp(catController.attackDelay, 0.1f, 1f);
                }
            }

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
