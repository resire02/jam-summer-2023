using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomEventHandler))]
public class RandomEvent : MonoBehaviour
{
    public GameObject eventPanel;
    private ChoiceEvent currentEvent;

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
}
