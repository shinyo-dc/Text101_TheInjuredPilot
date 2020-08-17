using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour 
{
    // SerializeField make the variable available within the inspector to be edited and viewed
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;
    bool isQuit = false;

	// Use this for initialization
	void Start () 
	{
        state = startingState;
        textComponent.text = state.GetStateStory();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ManageStates();	
	}

    private void ManageStates()
    {
        var nextStates = state.GetNextStates();
        if ( !isQuit )
        {
            // Using loop to process to the states available in the array
            for ( int index = 0; index < nextStates.Length; ++index )
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + index))
                {
                    state = nextStates[index];
                }
            }
            if ( Input.GetKeyDown(KeyCode.Q) )
            {
                isQuit = true;
            }
            textComponent.text = state.GetStateStory();
        }
        else if ( isQuit )
        {
            var currentState = state;
            textComponent.text = "Are you sure you want to quit? \n \n" +
                                 "1. Yes \n" +
                                 "2. No";
            if ( Input.GetKeyDown(KeyCode.Alpha1) )
            {
                isQuit = false;
                state = startingState;
            }
            else if ( Input.GetKeyDown(KeyCode.Alpha2) )
            {
                isQuit = false;
                state = currentState; 
            }
        }
    }
}
