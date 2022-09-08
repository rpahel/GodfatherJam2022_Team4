using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audio;

    public enum AudioType
    {
        P_Hit,
        P_Move,
        P_Death,
        C_Careful,
        C_Paw,
        C_Move
    }

    [Serializable]
    public struct PlayerMoves
    {
        public List<AudioClip> playerMoves;
        public AudioType audioType;
    }

    public List<PlayerMoves> playerMoves;

    [Serializable]
    public struct PlayerHitsDeath
    {
        public List<AudioClip> playerHitsDeath;
        public AudioType audioType;
    }

    public List<PlayerHitsDeath> playerHitsDeath;

    [Serializable]
    public struct CatMoves
    {
        public List<AudioClip> catMoves;
        public AudioType audioType;
    }

    public List<CatMoves> catMoves;

    [Serializable]
    public struct CatPatterns
    {
        public List<AudioClip> catPatterns;
        public AudioType audioType;
    }

    public List<CatPatterns> catPatterns;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayerMove()
    {
        int clipCount = 0;

        // If there is only one sound Type and multiple Clips
        if (playerMoves.Count < 2)
        {
            clipCount = playerMoves[0].playerMoves.Count;
            if (clipCount > 1)
            {
                int randClip = UnityEngine.Random.Range(0, clipCount);
                audio.PlayOneShot(playerMoves[0].playerMoves[randClip]);
            }
        }
        // If there is multiple sound Types and multiple Clips
        else
        {
            for (int i = 0; i < playerMoves.Count; i++)
            {
                if (playerMoves[i].audioType == AudioType.P_Move)
                {
                    clipCount = playerMoves[i].playerMoves.Count;
                    if (clipCount > 1)
                    {
                        int randClip = UnityEngine.Random.Range(0, clipCount);
                        audio.PlayOneShot(playerMoves[i].playerMoves[randClip]);
                    }
                }
            }
        }
    }

    public void PlayerHit()
    {
        int clipCount = 0;

        // If there is only one sound Type and multiple Clips
        if (playerHitsDeath.Count < 2)
        {
            clipCount = playerHitsDeath[0].playerHitsDeath.Count;
            if (clipCount > 1)
            {
                int randClip = UnityEngine.Random.Range(0, clipCount);
                audio.PlayOneShot(playerHitsDeath[0].playerHitsDeath[randClip]);
            }
        }
        // If there is multiple sound Types and multiple Clips
        else
        {
            for (int i = 0; i < playerHitsDeath.Count; i++)
            {
                if (playerHitsDeath[i].audioType == AudioType.P_Hit)
                {
                    clipCount = playerHitsDeath[i].playerHitsDeath.Count;
                    if (clipCount > 1)
                    {
                        int randClip = UnityEngine.Random.Range(0, clipCount);
                        audio.PlayOneShot(playerHitsDeath[i].playerHitsDeath[randClip]);
                    }
                }
            }
        }
    }

    public void PlayerDeath()
    {
        int clipCount = 0;

        // If there is only one sound Type and multiple Clips
        if (playerHitsDeath.Count < 2)
        {
            clipCount = playerHitsDeath[0].playerHitsDeath.Count; 
            if (clipCount > 1)
            {
                int randClip = UnityEngine.Random.Range(0, clipCount);
                audio.PlayOneShot(playerHitsDeath[0].playerHitsDeath[randClip]);
            }
        }
        // If there is multiple sound Types and multiple Clips
        else
        {
            for (int i = 0; i < playerHitsDeath.Count; i++)
            {
                if (playerHitsDeath[i].audioType == AudioType.P_Death)
                {
                    clipCount = playerHitsDeath[i].playerHitsDeath.Count;
                    if (clipCount > 1)
                    {
                        int randClip = UnityEngine.Random.Range(0, clipCount);
                        audio.PlayOneShot(playerHitsDeath[i].playerHitsDeath[randClip]);
                    }
                }
            }
        }
    }

    public void CatCareful()
    {
        int clipCount = 0;

        // If there is only one sound Type and multiple Clips
        if (catPatterns.Count < 2)
        {
            clipCount = catPatterns[0].catPatterns.Count;
            if (clipCount > 1)
            {
                int randClip = UnityEngine.Random.Range(0, clipCount);
                audio.PlayOneShot(catPatterns[0].catPatterns[randClip]);
            }
        }
        // If there is multiple sound Types and multiple Clips
        else
        {
            for (int i = 0; i < catPatterns.Count; i++)
            {
                if (catPatterns[i].audioType == AudioType.C_Careful)
                {
                    clipCount = catPatterns[i].catPatterns.Count;
                    if (clipCount > 1)
                    {
                        int randClip = UnityEngine.Random.Range(0, clipCount);
                        audio.PlayOneShot(catPatterns[i].catPatterns[randClip]);
                    }
                }
            }
        }
    }

    public void CatPaw()
    {
        int clipCount = 0;

        // If there is only one sound Type and multiple Clips
        if (catPatterns.Count < 2)
        {
            clipCount = catPatterns[0].catPatterns.Count;
            if (clipCount > 1)
            {
                int randClip = UnityEngine.Random.Range(0, clipCount);
                audio.PlayOneShot(catPatterns[0].catPatterns[randClip]);
            }
        }
        // If there is multiple sound Types and multiple Clips
        else
        {
            for (int i = 0; i < catPatterns.Count; i++)
            {
                if (catPatterns[i].audioType == AudioType.C_Paw)
                {
                    clipCount = catPatterns[i].catPatterns.Count;
                    if (clipCount > 1)
                    {
                        int randClip = UnityEngine.Random.Range(0, clipCount);
                        audio.PlayOneShot(catPatterns[i].catPatterns[randClip]);
                    }
                }
            }
        }
    }

    public void CatMove()
    {
        int clipCount = 0;

        // If there is only one sound Type and multiple Clips
        if (catMoves.Count < 2)
        {
            clipCount = catMoves[0].catMoves.Count;
            if (clipCount > 1)
            {
                int randClip = UnityEngine.Random.Range(0, clipCount);
                audio.PlayOneShot(catMoves[0].catMoves[randClip]);
            }
        }
        // If there is multiple sound Types and multiple Clips
        else
        {
            for (int i = 0; i < catMoves.Count; i++)
            {
                if (catMoves[i].audioType == AudioType.C_Move)
                {
                    clipCount = catMoves[i].catMoves.Count;
                    if (clipCount > 1)
                    {
                        int randClip = UnityEngine.Random.Range(0, clipCount);
                        audio.PlayOneShot(catMoves[i].catMoves[randClip]);
                    }
                }
            }
        }
    }
}

