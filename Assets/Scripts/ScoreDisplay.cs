using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay Instance { get; private set; }
    public int scoreDeTest;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int a = 0;
        foreach(Transform child in transform)
        {
            child.GetComponent<Digit>().id = a;
            a++;
        }
    }
}
