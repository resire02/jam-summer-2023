using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class PointChangeEvent : UnityEvent<PointChange> 
{

}

/// Displays and calculates the result of the RandomEvent
[RequireComponent(typeof(RandomEventHandler))]
public class RandomEvent : MonoBehaviour
{
    [SerializeField] private GameObject eventBar;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private GameObject declineButton;
    [SerializeField] private PointChangeEvent handleEvent;
    [SerializeField] private AudioRequest request;

    private ChoiceEvent currentEvent;
    private RandomEventHandler handler;
    private Animator animator;
    private bool outcomeOccurred;
    
    private void Start()
    {
        //  retrieve animator and handler
        handler = GetComponent<RandomEventHandler>();
        animator = eventBar.GetComponent<Animator>();
    }

    //  draws a random event from the event pool
    public void DetermineEvent(Age age)
    {
        //  select random event
        currentEvent = RandomEventList.SelectRandomEvent(age);

        //  play slider animation
        animator.SetBool("EventBarVisible", true);

        //  update event text
        titleText.text = currentEvent.eventContext.title;
        description.text = currentEvent.eventContext.description;

        //  make decline button visible
        declineButton.SetActive(true);

        //  reset ok flag
        outcomeOccurred = false;

        Debug.Log($"Event Called: {currentEvent.eventContext.title}");
    }

    //  for accept button functionality
    public void OnPlayerAccept()
    {
        if(!handler.IsEventHappening()) return;

        if(outcomeOccurred)
        {
            currentEvent = null;
            request.Invoke("Accept", false);
            animator.SetBool("EventBarVisible", false);
            handler.OnEventEnd();
            return;
        }

        declineButton.SetActive(false);

        if(currentEvent.GambleSuccess())
        {
            Debug.Log("Sucessful Event Triggered");
            request.Invoke("Accept", false);
            titleText.text = "Success";
            description.text = currentEvent.contextGood;
            handleEvent.Invoke(currentEvent.resultGood);
            GetComponent<SpriteGenerator>().AddToScene(new CustomSprite("PrehistoricBaseWithLogWithFire", 1000f, 500f, 0.5f));
        }
        else
        {
            Debug.Log("Failure Event Triggered");
            request.Invoke("Decline", false);
            titleText.text = "Failure";
            description.text = currentEvent.contextBad;
            handleEvent.Invoke(currentEvent.resultBad);
        }

        outcomeOccurred = true;
    }

    //  for decline button functionality
    public void OnPlayerDecline()
    {
        if(!handler.IsEventHappening()) return;

        request.Invoke("Decline", false);

        currentEvent = null;

        animator.SetBool("EventBarVisible", false);

        handler.OnEventEnd();
    }

}
