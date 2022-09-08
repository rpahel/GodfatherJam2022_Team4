using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameDifficulty", menuName = "ScriptableObjects/GameDifficulty", order = 2)]
public class GameDifficulty : ScriptableObject
{
    public bool easyModeSelected;
}
