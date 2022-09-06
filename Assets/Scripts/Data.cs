using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class DigitRef
    {
        [Tooltip("Chaque sprite en partant du plus en haut à gauche.")]
        public bool[] booleans = new bool[7]; 
    }
}
