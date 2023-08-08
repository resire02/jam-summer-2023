using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ProgressionTracker))]
public class GameLogic : GameComponent
{
    [System.Serializable]
    public class EventTrigger : UnityEvent<Era> {}

    [Header("Game")]
    [SerializeField] float eventProbability     = 0.5f;    //  chance of event to occur every interval
    [SerializeField] float eventTriggerInterval = 10f;      //  interval length between every event chance
    [SerializeField] float gameSpeed            = 20f;       //  time multiplier
    [SerializeField] float startingYear         = 0;        //  starting year
    [SerializeField] int eventQuota             = 3;        //  number of events to occur before milestone
    [SerializeField] float minimumYearThreshold = 30f;      //  minimum years to pass before events occur
    [SerializeField] int passiveRange           = 1;        //  range of values to reward passively
    [SerializeField] float passiveInterval      = 40f;      //  gain points every interval

    [Header("Events")]
    [SerializeField] EventTrigger randomEvent;
    [SerializeField] EventTrigger milestoneEvent;

    [Header("Visual")]
    [SerializeField] UnityEvent<Era,bool> loadSceneBackground;
    [SerializeField] UnityEvent<float> updateTimeText;
    [SerializeField] UnityEvent<Era> updateEraText;
    [SerializeField] ResourceUpdater barUpdater;

    [Header("Ending")]
    [SerializeField] UnityEvent<float,float> gameEnd;

    public bool eventHappening { get; private set; } = false;
    float _timer = 0f;
    int _eventCount = 0;
    ProgressionTracker _progression;

    private void Start()
    {
        eventProbability = Mathf.Clamp(eventProbability, 0f, 1f);
        _progression = GetComponent<ProgressionTracker>();
    }

    //  resets class to default state
    public override void Reset()
    {
        _timer = 0f;
        eventHappening = false;
        _eventCount = 0;
        startingYear = 0f;
    }

    private void FixedUpdate()
    {
        //  freeze timer during event
        if(eventHappening) return;

        //  add time to timer
        _timer += Time.deltaTime * gameSpeed;
        _timer = Mathf.Min(eventTriggerInterval, _timer);

        //  trigger event chance every n interval
        if(_timer == eventTriggerInterval)
        {
            _timer = 0f;
            startingYear += eventTriggerInterval;
            updateTimeText.Invoke(startingYear);

            //  avoid triggering events before threshold
            if(startingYear >= minimumYearThreshold)
                GambleEvent();
        }
    }

    //  gambles on event chance
    public void GambleEvent()
    {
        //  if event chance fails
        if(Random.Range(0f, 1f) > eventProbability)
        {
            if(startingYear % passiveInterval == 0)
                DoPassiveGain();
            barUpdater.UpdateValues(_progression.ValuesAsPoints());
            return;
        }
        
        if(_eventCount == eventQuota)
        {
            _eventCount = 0;
            milestoneEvent.Invoke(_progression.era);
        }
        else
        {
            _eventCount++;
            randomEvent.Invoke(_progression.era);
        }

        //  update resource bar values
        barUpdater.UpdateValues(_progression.ValuesAsPoints());

        eventHappening = true;
    }

    //  toggles event flag
    public void OnEventEnd(bool isMilestone)
    {
        eventHappening = false;

        if(isMilestone) 
        {
            loadSceneBackground.Invoke(_progression.era, false);
            updateEraText.Invoke(_progression.era);
        }
    }

    //  ends the game
    public void OnGameEnd()
    {
        gameEnd.Invoke(_progression.CalculateScore(), startingYear);
    }

    //  passively add points to progression
    private void DoPassiveGain()
    {
        Points gain = new Points(
            Random.Range(0, passiveRange + 1),
            Random.Range(0, passiveRange + 1),
            Random.Range(0, passiveRange + 1),
            Random.Range(0, passiveRange + 1),
            Random.Range(0, passiveRange + 1)
        );
            
        _progression.AdjustProgression(gain);
    }

}
