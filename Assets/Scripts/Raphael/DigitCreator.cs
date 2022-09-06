using UnityEngine;
using Data;

[CreateAssetMenu(fileName = "DigitCreator", menuName = "ScriptableObjects/DigitCreator", order = 1)]
public class DigitCreator : ScriptableObject
{
    public DigitRef[] digitRefs = new DigitRef[10];
}