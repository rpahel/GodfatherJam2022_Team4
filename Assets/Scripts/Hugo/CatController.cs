using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Difficulty;

public class CatController : MonoBehaviour
{

    //GameObject[,] catPaws = new GameObject[3, 3];

    //public CatBoard catBoard;
    //public GameObject[] columns;
    public CatImage[] paws;
    public Patern[] catPaternsEasy;
    public Patern[] catPaternsNormal;
    public Patern[] catPaternsHard;
    [HideInInspector] public DifficultyType difficultyType;
    public float attackDelay = 1f;
    public float minAttackDelay = 0.1f;
    public float maxAttackDelay = 1f;
    [Tooltip("The more you add, the fastest it will be when the difficulty is changing.")]
    public float changeSpeed = 0.5f;
    public float changeSpeedAlways = 0.05f;
    [HideInInspector] public float attackDelayNormal;

    public float stayDelay = 0.5f;


    void Start()
    {
        attackDelayNormal = attackDelay;
        difficultyType = DifficultyType.EASY;
        DisablePaws();
    }

    public void PlayPatern()
    {
        DisablePaws();

        int i = 0;

        int lifePlayer = GameManager.Instance.player.life;

        if (lifePlayer <= 0)
        {
            difficultyType = DifficultyType.NONE;
        }

        bool easyMode = GameManager.Instance.gameDifficulty.easyModeSelected;
        switch (difficultyType)
        { 
            // we take the easy pattern and we take a rand int to know what pattern to use + speedUp
            case DifficultyType.EASY:
                if (easyMode)
                {
                    i = Random.Range(0, catPaternsEasy.Length);
                    catPaternsEasy[i].Play();
                }
                else
                {
                    goto case DifficultyType.NORMAL;
                }
                break;
            case DifficultyType.NORMAL:
                i = Random.Range(0, catPaternsNormal.Length);
                catPaternsNormal[i].Play();
                break;
            case DifficultyType.HARD:
                if (!easyMode)
                {
                    i = Random.Range(0, catPaternsHard.Length);
                    catPaternsHard[i].Play();
                }
                else
                {
                    difficultyType = DifficultyType.NORMAL;
                }
                break;
            case DifficultyType.NONE:
                Debug.Log("GameOver");
                goto default;
            default:
                break;
        }
    }

    public void DisablePaws()
    {
        for (int i = 0; i < paws.Length; i++)
        {
            paws[i].paw.SetActive(false);
            paws[i].exclamation.SetActive(false);
            //paws[i].eyes.SetActive(false);
        }
    }
}
