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
            if (GameManager.Instance.player.life > 0)
            {
                for (int j = 0; j < catMoves[i].catPaws.Length; j++)
                {
                    catMoves[i].catPaws[j].exclamation.SetActive(true);
                }

                AudioManager.Instance.CatCareful();
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

            if (GameManager.Instance.player.life > 0)
            {
                for (int k = 0; k < catMoves[i].catPaws.Length; k++)
                {
                    catMoves[i].catPaws[k].paw.SetActive(true);

                //if (catMoves[i].catPaws[k].playerOnPaw)
                    //    GameManager.Instance.player.TakeDamage();

                } 
                AudioManager.Instance.CatPaw();
            }

            yield return new WaitForSeconds(catController.stayDelay);

            if (GameManager.Instance.player.life > 0)
            {
                for (int l = 0; l < catMoves[i].catPaws.Length; l++)
                {
                    catMoves[i].catPaws[l].exclamation.SetActive(false);
                    catMoves[i].catPaws[l].paw.SetActive(false);
                }
            }

            yield return new WaitForSeconds(catController.stayDelay);

            if (GameManager.Instance.player.gameLaunched && GameManager.Instance.player.life > 0)
            {

                GameManager.Instance.player.scoreHour.UpdateScore(++GameManager.Instance.score);
                GameManager.Instance.scoreDifficulty++;

                int scoreCombo = GameManager.Instance.scoreDifficulty;

                bool easyMode = GameManager.Instance.gameDifficulty.easyModeSelected;

                switch (scoreCombo)
                {
                    case 0:
                        if (easyMode)
                        {
                            catController.attackDelay = catController.attackDelayNormal;
                            catController.difficultyType = DifficultyType.EASY;
                        }
                        else
                        {
                            GameManager.Instance.scoreDifficulty = 10;
                            goto case 10;
                        }
                        break;
                    case 5:
                        if (easyMode)
                        {
                            catController.attackDelay -= catController.changeSpeed;
                            catController.difficultyType = DifficultyType.EASY;
                        }
                        else
                        {
                            GameManager.Instance.scoreDifficulty = 15;
                            goto case 15;
                        }
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
                        if (!easyMode)
                        {
                            catController.attackDelay = catController.attackDelayNormal;
                            catController.difficultyType = DifficultyType.HARD;
                        }
                        break;
                    case 25:
                        if (!easyMode)
                        {
                            catController.attackDelay -= catController.changeSpeed;
                            catController.difficultyType = DifficultyType.HARD;
                        }
                        break;
                    default:
                        break;
                }

                if ((scoreCombo >= 30 && scoreCombo % 5 == 0 && !easyMode) || (scoreCombo >= 20 && scoreCombo % 5 == 0 && easyMode))
                {
                    catController.attackDelay -= catController.changeSpeedAlways;
                }
                catController.attackDelay = Mathf.Clamp(catController.attackDelay, catController.minAttackDelay, catController.maxAttackDelay);
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
