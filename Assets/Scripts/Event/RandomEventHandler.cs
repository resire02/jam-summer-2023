using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UpdateTextEvent : UnityEvent<float> 
{

}

//  Handles when events occur
public class RandomEventHandler : MonoBehaviour
{
    //  probability is calculated as 1 in eventProb
    [SerializeField] private int eventProbability = 7;
    [SerializeField] private float eventTriggerInterval = 10f;
    [SerializeField] private float gameSpeed = 2f;
    [SerializeField] private float startingYear = 0;
    
    public UpdateTextEvent updateTimeText;
    private float eventTimer = 0f;
    private bool eventIsOccurring = false;
    private RandomEvent randomEvent;
    
    private void Start()
    {
        updateTimeText.Invoke(startingYear);
        randomEvent = GetComponent<RandomEvent>();
        RandomEventList.Init();
    }

    private void FixedUpdate()
    {
        if(eventIsOccurring) return;

        eventTimer += Time.deltaTime * gameSpeed;
        eventTimer = Mathf.Clamp(eventTimer, 0, eventTriggerInterval);

        if(eventTimer == eventTriggerInterval)
        {
            eventTimer = 0f;
            startingYear += eventTriggerInterval;
            updateTimeText.Invoke(startingYear);
            GambleEvent();
        }
    }

    //  gambles on event chance
    public void GambleEvent()
    {
        if(Random.Range(1, eventProbability) == 1)
        {
            eventIsOccurring = true;

            //  TODO: make this accept Age argument
            randomEvent.DetermineEvent(Age.Prehistoric);
        }
    }

    //  handles end of event (connected by button callback)
    public void OnEventEnd()
    {
        eventIsOccurring = false;
    }

    public bool IsEventHappening() { return eventIsOccurring; }
}
