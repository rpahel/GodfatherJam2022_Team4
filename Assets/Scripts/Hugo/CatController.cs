using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    //GameObject[,] catPaws = new GameObject[3, 3];

    //public CatBoard catBoard;
    //public GameObject[] columns;
    public CatImage[] paws;
    public Patern[] catPaterns;
    public float attackDelay = 1f;
    public float stayDelay = 0.5f;


    void Start()
    {
        PlayPatern();
    }

    public void PlayPatern()
    {
        DisablePaws();

        int i = Random.Range(0, catPaterns.Length);
        catPaterns[i].Play();
    }

    public void DisablePaws()
    {
        for (int i = 0; i < paws.Length; i++)
        {
            paws[i].paw.SetActive(false);
            paws[i].exclamation.SetActive(false);
        }
    }
}
