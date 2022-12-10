using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPuzzle : PuzzleCompleteListener
{

    public PuzzleCompleteListener listener;

    public int numPuzzlesToComplete = 3;

    int currentCompletedPuzzles = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void onPuzzleEvent(bool complete) {
        currentCompletedPuzzles += complete?1:-1;

        listener.onPuzzleEvent(currentCompletedPuzzles == numPuzzlesToComplete);
    }
}
