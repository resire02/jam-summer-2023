using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ProcessChoiceEvent : UnityEvent<ChoiceEvent, int> 
{

}

[RequireComponent(typeof(RandomEventHandler))]
public class RandomEvent : MonoBehaviour
{
    public GameObject eventPanel;
    private ChoiceEvent currentEvent;
    private RandomEventHandler handler;
    public ProcessChoiceEvent choiceEvent;

    private void Start()
    {
        handler = GetComponent<RandomEventHandler>();
    }

    public void DetermineEvent(Age age)
    {
        ToggleEventPanel();
        currentEvent = RandomEventList.SelectRandomEvent(age);
        Debug.Log(currentEvent.GetTitle());
    }
    
    private void ToggleEventPanel()
    {
        eventPanel.transform.Translate(Vector3.up * 300);
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
    }
}
