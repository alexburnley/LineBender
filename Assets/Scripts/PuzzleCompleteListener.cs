using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleCompleteListener : MonoBehaviour
{
    public abstract void onPuzzleEvent(bool isComplete);
}
