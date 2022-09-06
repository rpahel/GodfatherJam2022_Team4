using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
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
    }

    private void Update()
    {
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
        if (!checkPos)
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
}
