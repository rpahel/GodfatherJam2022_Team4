using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int scoreDifficulty = 0;

    public DisplaySprites player;
    public CatController catController;
    public GameDifficulty gameDifficulty;
    public DecorAnimation animInGame;

    public bool inGameCatAnim;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Cursor.visible = false;
    }
}
