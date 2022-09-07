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

    void Start()
    {
        PlayPatern();
    }

    void PlayPatern()
    {
        DisablePaws();


        //int i = Random.Range(0, catPaterns.Length);
        catPaterns[Random.Range(0, catPaterns.Length)].Play();
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
