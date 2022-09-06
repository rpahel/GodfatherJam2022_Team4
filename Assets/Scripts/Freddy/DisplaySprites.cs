using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplaySprites : MonoBehaviour
{
    [Tooltip("Drop the sprites of the bird.")]
    public List<Image> birdsSprites;

    [Tooltip("Drop the sprites of the cat.")]
    public List<Image> catSprites;

    [Tooltip("Drop the sprites of the life.")]
    public List<Image> lifeSprites;

    private Image player;
    private Image[,] birdPosition = new Image[3, 3];

    private int _GetSetPositionSpriteC;
    public int GetSetPositionSpriteC { get { return _GetSetPositionSpriteC; } set { _GetSetPositionSpriteC = value; } }

    private int _GetSetPositionSpriteR;
    public int GetSetPositionSpriteR { get { return _GetSetPositionSpriteR; } set { _GetSetPositionSpriteR = value; } }

    public int life = 3;

    public bool gameLaunched;
    private bool canMove;

    public float delay;
    private float timer = 0f;
    private void Start()
    {
        // Player doesn't play
        gameLaunched = false;
        canMove = true;
        if (!gameLaunched)
        {
            RandomMove();
        }

        // Init sprites
        int k = 0;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                birdPosition[i, j] = birdsSprites[k];
                birdsSprites[k].gameObject.SetActive(false);
                k++;
            }
        }
        player = birdsSprites[4];
        player.gameObject.SetActive(true);

        // Init life
        for(int i = 0; i < lifeSprites.Count; i++)
        {
            lifeSprites[i].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (!gameLaunched) timer += Time.deltaTime;

        if(timer >= delay)
        {
            RandomMove();
        }

        if (Input.anyKeyDown) gameLaunched = true;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Move("up", player);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move("down", player);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Move("left", player);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move("right", player);
        }

        // Debug
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage();
        }

        if(life <= 0)
        {
            // Game Over
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public bool CheckPosition(string direction, Image spriteActive)
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (birdPosition[i, j] == spriteActive)
                {
                    GetSetPositionSpriteR = j;
                    GetSetPositionSpriteC = i;
                    switch (i) {
                        case 0:
                            if (direction == "left")
                            {
                                return false;
                            }
                            switch (j) {
                                case 0:
                                    if(direction == "up")
                                    {
                                        return false;
                                    }
                                    break;
                                case 2:
                                    if (direction == "down")
                                    {
                                        return false;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 1:
                            switch (j)
                            {
                                case 0:
                                    if (direction == "up")
                                    {
                                        return false;
                                    }
                                    break;
                                case 2:
                                    if (direction == "down")
                                    {
                                        return false;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            if (direction == "right")
                            {
                                return false;
                            }
                            switch (j)
                            {
                                case 0:
                                    if (direction == "up")
                                    {
                                        return false;
                                    }
                                    break;
                                case 2:
                                    if (direction == "down")
                                    {
                                        return false;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        return true;
    }

    public void Move(string direction, Image previousSprite)
    {
        bool checkPos = CheckPosition(direction, previousSprite);
        if (!checkPos && gameLaunched)
        {
            Debug.Log("Can't Move!");
            return;
        }

        switch (direction)
        {
            case "up":
                previousSprite.gameObject.SetActive(false);
                player = birdPosition[GetSetPositionSpriteC, GetSetPositionSpriteR - 1];
                player.gameObject.SetActive(true);
                return;
            case "down":
                previousSprite.gameObject.SetActive(false);
                player = birdPosition[GetSetPositionSpriteC, GetSetPositionSpriteR + 1];
                player.gameObject.SetActive(true);
                return;
            case "left":
                previousSprite.gameObject.SetActive(false);
                player = birdPosition[GetSetPositionSpriteC - 1, GetSetPositionSpriteR];
                player.gameObject.SetActive(true);
                return;
            case "right":
                previousSprite.gameObject.SetActive(false);
                player = birdPosition[GetSetPositionSpriteC + 1, GetSetPositionSpriteR];
                player.gameObject.SetActive(true);
                return;
            default:
                Debug.LogError("Direction not set!");
                return;
        }
    }

    private void RandomMove()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                bool checkUp = CheckPosition("up", player);
                if (!checkUp)
                {
                    canMove = false;
                    timer = 10f;
                }
                else
                {
                    Move("up", player);
                    timer = 0f;
                }
                return;
            case 1:
                bool checkDown = CheckPosition("down", player);
                if (!checkDown)
                {
                    canMove = false;
                    timer = 10f;
                }
                else
                {
                    Move("down", player);
                    timer = 0f;
                }
                return;
            case 2:
                bool checkLeft = CheckPosition("left", player);
                if (!checkLeft)
                {
                    canMove = false;
                    timer = 10f;
                }
                else
                {
                    Move("left", player);
                    timer = 0f;
                }
                return;
            case 3:
                bool checkRight = CheckPosition("right", player);
                if (!checkRight)
                {
                    canMove = false;
                    timer = 10f;
                }
                else
                {
                    Move("right", player);
                    timer = 0f;
                }
                return;
            default:
                Debug.LogError("The player does not move !");
                break;
        }
        //StartCoroutine(PlayerDelay());
    }

    public void TakeDamage()
    {
        life--;
        lifeSprites[life].gameObject.SetActive(false);
    }

    /* private IEnumerator PlayerDelay()
     {
         yield return new WaitForSeconds(delay);
         if(!gameLaunched) RandomMove();
     }*/
}