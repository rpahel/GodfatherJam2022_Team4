using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatePlayer : MonoBehaviour
{
    private DisplaySprites player;
    private List<Coroutine> eyesCooldowns = new List<Coroutine>();

    private void Start()
    {
        player = GetComponent<DisplaySprites>();
        foreach (Image playerImg in player.birdsSprites)
        {
            foreach(Transform child in playerImg.gameObject.transform)
            {
                if(child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }

    public void UpdateState(int life)
    {
        eyesCooldowns.Add(StartCoroutine(EyesCooldown()));

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
            default:
                break;
        }
    }

    IEnumerator EyesCooldown()
    {
        foreach (Image playerImg in player.birdsSprites)
        {
            playerImg.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        foreach (Image playerImg in player.birdsSprites)
        {
            playerImg.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }

        StopCoroutine(eyesCooldowns[0]);
        eyesCooldowns.Remove(eyesCooldowns[0]);
    }
}
