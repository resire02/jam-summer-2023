using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UpdateTextEvent : UnityEvent<float> 
{

}

public class RandomEventHandler : MonoBehaviour
{
    //  probability is calculated as 1 in eventProb
    [SerializeField] private int eventProbability = 7;
    [SerializeField] private float eventInterval = 10f;
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
        eventTimer = Mathf.Clamp(eventTimer, 0, eventInterval);

        if(eventTimer == eventInterval)
        {
            eventTimer = 0f;
            startingYear += eventInterval;
            updateTimeText.Invoke(startingYear);
            GambleEvent();
        }
    }

    public void GambleEvent()
    {
        //  TODO: add a random chance for event to occur
        if(Random.Range(1, eventProbability) == 1)
        {
            eventIsOccurring = true;
            randomEvent.DetermineEvent(Age.Prehistoric);
        }
    }

    public void OnEventEnd()
    {
        eventIsOccurring = false;
        randomEvent = null;
    }

    public bool IsEventHappening() { return eventIsOccurring; }
}
