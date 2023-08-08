using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(GameLogic))]
public class RandomEventHandler : GameComponent
{   
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] GameObject decline;
    [SerializeField] Animator animator;
    [SerializeField] VisualChange visuals;

    GameLogic _gameLogic;
    ProgressionTracker _progression;
    RandomEvent _currentEvent;
    Coroutine _accept;
    bool _acceptButtonPressed;

    private void Start()
    {
        _gameLogic = GetComponent<GameLogic>();
        _progression = GetComponent<ProgressionTracker>();

        RandomEventList.Init();
    }

    public override void Reset()
    {
        animator.SetBool("EventBarVisible", false);
        _currentEvent = null;

        RandomEventList.RepopulateList();
    }

    public void OnPlayerAccept()
    {
        _acceptButtonPressed = true;
        AudioHandler.Player.PlaySFX("Accept");
    }

    public void OnPlayerDecline()
    {
        HandleEventEnd();
        AudioHandler.Player.PlaySFX("Decline");
    }

    //  draws a random event from the event pool
    public void StartRandomEvent(Era era)
    {
        //  draw random event
        _currentEvent = RandomEventList.DrawRandomEventFromEra(_progression.era);

        //  display event bar
        animator.SetBool("EventBarVisible", true);

        //  update event bar text
        title.text = _currentEvent.title;
        description.text = _currentEvent.description;

        //  set no button active
        if(!decline.activeInHierarchy) decline.SetActive(true);

        //  do random event
        _accept = StartCoroutine(TriggerRandomEvent());
    }

    //  handles random event flow
    private IEnumerator TriggerRandomEvent()
    {
        //  wait for player press
        _acceptButtonPressed = false;
        yield return new WaitUntil(() => _acceptButtonPressed);

        decline.SetActive(false);

        //  calculate random event outcome
        if(_currentEvent.IsSuccessful())
        {
            title.text = _currentEvent.goodOutcome.title;
            description.text = _currentEvent.goodOutcome.description;
            _progression.AdjustProgression(_currentEvent.goodOutcome.points);
            visuals.TriggerAnimation(_currentEvent.goodOutcome.points);
        }
        else
        {
            title.text = _currentEvent.badOutcome.title;
            description.text = _currentEvent.badOutcome.description;
            _progression.AdjustProgression(_currentEvent.badOutcome.points);
            visuals.TriggerAnimation(_currentEvent.badOutcome.points);
        }

        //  wait for player press
        _acceptButtonPressed = false;
        yield return new WaitUntil(() => _acceptButtonPressed);

        HandleEventEnd();
    }

    private void HandleEventEnd()
    {
        //  end event status
        _gameLogic.OnEventEnd(false);

        //  hide event bar
        animator.SetBool("EventBarVisible", false);

        //  stop accept coroutine is ended early
        StopCoroutine(_accept);

        //  clear event
        _currentEvent = null;
    }

}
