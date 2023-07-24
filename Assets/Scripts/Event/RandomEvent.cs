using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ProcessChoiceEvent : UnityEvent<ChoiceEvent, int> 
{

}

/// Displays and calculates the result of the RandomEvent
[RequireComponent(typeof(RandomEventHandler))]
public class RandomEvent : MonoBehaviour
{
    public GameObject eventBar;
    public ProcessChoiceEvent choiceEvent;

    private ChoiceEvent currentEvent;
    private RandomEventHandler handler;
    private Animator animator;

    private void Start()
    {
        handler = GetComponent<RandomEventHandler>();
        animator = eventBar.GetComponent<Animator>();
    }

    //  draws a random event from the event pool
    public void DetermineEvent(Age age)
    {
        currentEvent = RandomEventList.SelectRandomEvent(age);
        animator.SetBool("EventBarVisible", true);

        Debug.Log($"Event Called: {currentEvent.GetTitle()}");
    }

    //  used for button functionality
    public void ProcessPlayerChoice(int choice)
    {
        if(!handler.IsEventHappening()) return;

        if(choice == 1)
            choiceEvent.Invoke(currentEvent, 1);
        else
            choiceEvent.Invoke(currentEvent, -1);

        currentEvent = null;
        animator.SetBool("EventBarVisible", false);
    }
}
