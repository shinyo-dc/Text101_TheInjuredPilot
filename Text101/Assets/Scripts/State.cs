using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adding State as a scriptable object to be created as an asset
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    // TextArea: changing the size of the textbox in the inspector, (minLines, maxLines)
    [TextArea(10, 12)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    // Public method
    public string GetStateStory()
    {
        return storyText;
    }
    public State[] GetNextStates()
    {
        return nextStates;        
    }
}
