using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(RandomEventHandler))]
public class MilestoneEventHandler : MonoBehaviour
{
    [SerializeField] private GameObject milestonePanel;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private GameObject gameEndPanel;
    [SerializeField] private UnityEvent eventHandlerCallback;

    private Dictionary<Age, (string, string)> milestoneSceneData;
    private ProgressionTracker progression;
    private ImageLoader imgLd;
    private MilestoneEvent milestoneEvent;
    
    private void Start()
    {
        Reset();
        imgLd = GetComponent<ImageLoader>();
        progression = GetComponent<ProgressionTracker>();   
        MilestoneEventList.Init();
        PopulateMilestoneSceneData();
    }

    public void Reset()
    {
        gameEndPanel.SetActive(false);
        milestonePanel.SetActive(false);
    }

    private void PopulateMilestoneSceneData()
    {
        milestoneSceneData = new Dictionary<Age, (string, string)>();
        milestoneSceneData.Add(Age.Prehistoric, ("MilestonePlaceholder", "none"));
    }

    private (string, string) GetMilestoneSceneData(Age age)
    {
        if(!milestoneSceneData.ContainsKey(age)) return ("MilestonePlaceholder", "none");

        return milestoneSceneData[age];
    }

    public void TriggerMilestoneEvent(Age age)
    {
        // Debug.Log("Triggered Milestone Event");

        //  set background and foreground scene
        (string bg, string fg) scene = GetMilestoneSceneData(age);
        imgLd.SetScene(scene.bg, scene.fg);

        //  toggle milestone panel
        milestonePanel.SetActive(true);
        milestoneEvent = MilestoneEventList.GetMilestoneEvent(age);
        UpdateText();
    }

    public void HandleMilestone()
    {
        // Debug.Log("Pressed Button");

        //  TODO: write custom function to handle milestone events
        progression.AdjustProgression(milestoneEvent.GetPointChange());

        if(progression.CheckIsAlive())
        {
            progression.AscendToNextMilestone();

            //  TODO: play sound or animation or something?
            eventHandlerCallback.Invoke();

            //  hide milestone panel after clicking
            milestonePanel.SetActive(false);
        }
        else
        {
            gameEndPanel.SetActive(true);
        }

    }

    private void UpdateText()
    {
        title.text = milestoneEvent.GetTitle();
        description.text = milestoneEvent.GetDescription();
    }
}
