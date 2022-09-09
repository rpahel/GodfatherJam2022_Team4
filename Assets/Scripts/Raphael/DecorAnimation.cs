using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DecorAnimation : MonoBehaviour
{
    [System.Serializable]
    public struct HeadAndPaws
    {
        public GameObject head;
        public List<GameObject> paws;
    }

    public float startAnimSecondsBetweenSprites;
    public float minCooldownInGameSpritesChange, maxCooldownInGameSpritesChange;
    public GameObject[] startAnimationSprites;
    public List<HeadAndPaws> headAndPaws;

    [Tooltip("Drop the Head and Paws of the cats appearing at the end of the animation.")]
    public HeadAndPaws firstHeadAndPaws;

    private Coroutine startAnim;

    private void Start()
    {
        PlayStartAnimation();
    }

    public void PlayStartAnimation()
    {
        foreach(var sprite in startAnimationSprites)
        {
            sprite.SetActive(false);
        }
    
        startAnim = StartCoroutine(StartAnimation());
    }
    
    IEnumerator StartAnimation()
    {
        startAnimationSprites[5].SetActive(true); //DoorKnob
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites*2f);
        startAnimationSprites[5].SetActive(false); //DoorKnob
        startAnimationSprites[0].SetActive(true); //GrandMother
        startAnimationSprites[3].SetActive(true); //ShadowDoor
        AudioManager.Instance.DoorStart();
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[1].SetActive(true); //Bye1
        AudioManager.Instance.GrandMotherByeByeStart();
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[2].SetActive(true); //Bye2
        AudioManager.Instance.GrandMotherByeByeStart();
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        for(int i = 0; i < 2; i++)
        {
            startAnimationSprites[i+1].SetActive(false); //Bye1; Bye2
        }
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[0].SetActive(false); //GrandMother
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[3].SetActive(false); //ShadowDoor
        startAnimationSprites[4].SetActive(true); //ClacDoor
        startAnimationSprites[5].SetActive(true); //DoorKnob
        AudioManager.Instance.DoorStart();
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites/2f);
        startAnimationSprites[4].SetActive(false); //ClacDoor
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites*2f);
        startAnimationSprites[6].SetActive(true); //CatWindow1
        AudioManager.Instance.CatStart();
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites*2f);
        startAnimationSprites[6].SetActive(false); //CatWindow1
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites*2f);
        startAnimationSprites[7].SetActive(true); //CatWindow2
        AudioManager.Instance.CatStart();
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[7].SetActive(false); //CatWindow2
        startAnimationSprites[8].SetActive(true); //CatWindow3
        AudioManager.Instance.CatStart();
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[8].SetActive(false); //CatWindow3
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[9].SetActive(true); //PawLeft4
        AudioManager.Instance.CatStart(true, true);
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[10].SetActive(true); //PawRight5
        AudioManager.Instance.CatStart(true, false);
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[9].SetActive(false); //PawLeft4
        startAnimationSprites[11].SetActive(true); //PawLeft3
        AudioManager.Instance.CatStart(true, true);
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[10].SetActive(false); //PawRight5
        startAnimationSprites[12].SetActive(true); //PawRight4
        AudioManager.Instance.CatStart(true, false);
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[11].SetActive(false); //PawLeft3
        startAnimationSprites[13].SetActive(true); //PawLeft2
        AudioManager.Instance.CatStart(true, true);
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[12].SetActive(false); //PawRight4
        startAnimationSprites[14].SetActive(true); //PawRight3
        AudioManager.Instance.CatStart(true, false);
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[13].SetActive(false); //PawLeft2
        startAnimationSprites[15].SetActive(true); //PawRight2
        AudioManager.Instance.CatStart(true, true);
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        startAnimationSprites[16].SetActive(true); //CatLookingRight
        AudioManager.Instance.CatStart();
        StopCoroutine(startAnim);
    }

    public void StartCatAnimation(HeadAndPaws previousHeadAndPaws = new HeadAndPaws(), bool gameIsStarting = true)
    {
        if (startAnim != null)
        {
            StopCoroutine(startAnim);
            AudioManager.Instance.gameAudio.clip = null;
        }

        for(int i = 0; i < startAnimationSprites.Length; i++)
        {
            if(i == 5)
            {
                startAnimationSprites[i].SetActive(true);
                continue;
            }

            startAnimationSprites[i].SetActive(false);
        }

        StartCoroutine(CatAnimation(previousHeadAndPaws, gameIsStarting));
    }

    IEnumerator CatAnimation(HeadAndPaws previousHeadAndPaws = new HeadAndPaws(), bool gameIsStarting = false)
    {
        if (gameIsStarting)
            previousHeadAndPaws = firstHeadAndPaws;

        // Display paws only
        startAnimSecondsBetweenSprites = 1f;

        int randHeadPaws = Random.Range(0, headAndPaws.Count);

        while (previousHeadAndPaws.head == headAndPaws[randHeadPaws].head)
        {
            randHeadPaws = Random.Range(0, headAndPaws.Count);
        }

        previousHeadAndPaws = headAndPaws[randHeadPaws];

        foreach (GameObject paws in headAndPaws[randHeadPaws].paws)
        {
            paws.SetActive(true);
        }

        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);

        // Display Head and Paws
        headAndPaws[randHeadPaws].head.SetActive(true);
        startAnimSecondsBetweenSprites =
            Random.Range(minCooldownInGameSpritesChange, maxCooldownInGameSpritesChange);
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        // Disable Head
        headAndPaws[randHeadPaws].head.SetActive(false);
        startAnimSecondsBetweenSprites = 1f;
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        // Disable Paws
        foreach (GameObject paws in headAndPaws[randHeadPaws].paws)
        {
            paws.SetActive(false);
        }
        startAnimSecondsBetweenSprites =
            Random.Range(minCooldownInGameSpritesChange, maxCooldownInGameSpritesChange);
        yield return new WaitForSeconds(startAnimSecondsBetweenSprites);
        StartCoroutine(CatAnimation(previousHeadAndPaws));
    }
}
