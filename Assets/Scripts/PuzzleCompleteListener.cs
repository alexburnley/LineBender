using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleCompleteListener : MonoBehaviour
{
    abstract void onPuzzleEvent(bool isComplete);
}
