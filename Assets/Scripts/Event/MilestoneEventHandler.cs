using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(GameLogic))]
public class MilestoneEventHandler : GameComponent
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] GameObject milestonePanel;
    [SerializeField] VisualChange visuals;
    [SerializeField] UnityEvent<Era,bool> loadSceneBackground;

    GameLogic _gameLogic;
    ProgressionTracker _progression;
    MilestoneEvent _currentEvent;
    Coroutine _event;
    bool _acceptButtonPressed;

    private void Start()
    {
        milestonePanel.SetActive(false);
        _gameLogic = GetComponent<GameLogic>();
        _progression = GetComponent<ProgressionTracker>();

        MilestoneEventList.Init();
    }

    public override void Reset()
    {
        milestonePanel.SetActive(false);
        _currentEvent = null;
    }

    public void OnPlayerAccept()
    {
        _acceptButtonPressed = true;
    }

    //  used to setup the milestone scene
    public void StartMilestoneEvent(Era era)
    {
        //  draw milestone event
        _currentEvent = MilestoneEventList.GetMilestoneEventFromEra(_progression.era);

        loadSceneBackground.Invoke(_progression.era, true);

        //  update text
        title.text = _currentEvent.title;
        description.text = _currentEvent.description;

        //  display milestone panel
        milestonePanel.SetActive(true);

        //  handle milestone event
        _event = StartCoroutine(TriggerMilestoneEvent());
    }

    private IEnumerator TriggerMilestoneEvent()
    {
        //  wait for button press
        _acceptButtonPressed = false;
        yield return new WaitUntil(() => _acceptButtonPressed);

        if(!_progression.SurvivesEvent(_currentEvent.points))
        {
            //  do game end
            _gameLogic.OnGameEnd();
            
            yield break;
        }

        visuals.TriggerAnimation(_currentEvent.points);

        //  increment to next milestone
        _progression.ToNextMilestone();

        //  hide milestone panel
        milestonePanel.SetActive(false);

        //  end event
        _gameLogic.OnEventEnd(true);
    }

}
