using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatePlayer : MonoBehaviour
{
    private DisplaySprites player;

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
                    playerImg.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                }
                break;
            case 1:
                foreach (Image playerImg in player.birdsSprites)
                {
                    playerImg.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
            default: break;
        }
    }
}
