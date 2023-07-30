using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UpdateTextEvent : UnityEvent<float> 
{

}

[System.Serializable]
public class ImportantEvent : UnityEvent<Age>
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
    [SerializeField] private int eventQuota = 3;
    
    public UpdateTextEvent updateTimeText;
    public ImportantEvent milestoneEvent;
    private float eventTimer = 0f;
    private bool eventIsOccurring = false;
    private RandomEvent randomEvent;
    private int eventCount = 0;
    private ProgressionTracker progression;
    
    private void Start()
    {
        updateTimeText.Invoke(startingYear);
        randomEvent = GetComponent<RandomEvent>();
        progression = GetComponent<ProgressionTracker>();
        RandomEventList.Init();
    }

    private void FixedUpdate()
    {
        if(eventIsOccurring) return;

        eventTimer += Time.deltaTime * gameSpeed;
        eventTimer = Mathf.Clamp(eventTimer, 0, eventTriggerInterval);

        //  trigger event chance every n interval
        if(eventTimer == eventTriggerInterval)
        {
            eventTimer = 0f;
            startingYear += eventTriggerInterval;
            updateTimeText.Invoke(startingYear);
            GambleEvent(progression.GetTechnologicalStage());
        }
    }

    //  gambles on event chance
    public void GambleEvent(Age age)
    {
        if(Random.Range(1, eventProbability) != 1) return;
        
        if(eventCount == eventQuota)
        {
            eventCount = 0;
            milestoneEvent.Invoke(age);            
        }
        else
        {
            eventCount++;
            randomEvent.DetermineEvent(age);
        }

        eventIsOccurring = true;
    }

    //  handles end of event (connected by button callback)
    public void OnEventEnd()
    {
        eventIsOccurring = false;
    }

    public bool IsEventHappening() { return eventIsOccurring; }

}
