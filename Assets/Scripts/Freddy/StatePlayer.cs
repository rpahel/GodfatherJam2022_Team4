using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatePlayer : MonoBehaviour
{
    private DisplaySprites player;

    [Tooltip("Drop the different states of the player when he's gonna be hit.")]
    public List<Sprite> stateSprites;

    private void Start()
    {
        player = GetComponent<DisplaySprites>();
    }
    public void UpdateState(int life)
    {
        switch (life)
        {
            case 2:
                foreach (Image playerImg in player.birdsSprites)
                {
                    playerImg.sprite = stateSprites[0];
                }
                break;
            case 1:
                foreach (Image playerImg in player.birdsSprites)
                {
                    playerImg.sprite = stateSprites[1];
                }
                break;
            default: break;
        }
    }
}
