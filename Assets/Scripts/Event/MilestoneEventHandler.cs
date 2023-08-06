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
    [SerializeField] private UnityEvent eventHandlerCallback;
    [SerializeField] private UnityEvent<float> onGameEnd;

    // private Dictionary<Age, (string, string)> milestoneSceneData;
    private ProgressionTracker progression;
    private ImageLoader imgLd;
    private MilestoneEvent milestoneEvent;
    
    private void Start()
    {
        Reset();
        imgLd = GetComponent<ImageLoader>();
        progression = GetComponent<ProgressionTracker>();   
        MilestoneEventList.Init();
        // PopulateMilestoneSceneData();
    }

    public void Reset()
    {
        milestonePanel.SetActive(false);
    }

    // private void PopulateMilestoneSceneData()
    // {
    //     milestoneSceneData = new Dictionary<Age, (string, string)>();
    //     milestoneSceneData.Add(Age.Prehistoric, ("MilestonePlaceholder", "none"));
    // }

    //  used to retrieve milestone scene data
    // private (string, string) GetMilestoneSceneData(Age age)
    // {
    //     if(!milestoneSceneData.ContainsKey(age)) return ("MilestonePlaceholder", "none");

    //     return milestoneSceneData[age];
    // }

    //  used to setup the milestone scene
    public void TriggerMilestoneEvent(Age age)
    {
        //  set background and foreground scene
        imgLd.SetMilestoneScene(age);

        //  toggle milestone panel
        milestonePanel.SetActive(true);
        milestoneEvent = MilestoneEventList.GetMilestoneEvent(age);
        UpdateText();
    }

    //  handles milestone event flow
    public void HandleMilestone()
    {
        Debug.Log("Pressed Button");

        //  check if civilization survives
        if(progression.SurvivesMilestone(milestoneEvent.GetPointChange()) && progression.GetTechnologicalStage() != Age.Singularity)
        {
            progression.AdjustProgression(milestoneEvent.GetPointChange());
            
            //  progress milestone
            progression.AscendToNextMilestone();

            //  handle event end
            eventHandlerCallback.Invoke();

            //  hide milestone panel after clicking
            milestonePanel.SetActive(false);
        }
        else
        {
            //  display end panel
            onGameEnd.Invoke(progression.CalculateScore());
        }

    }

    //  updates milestone panel text
    private void UpdateText()
    {
        title.text = milestoneEvent.GetTitle();
        description.text = milestoneEvent.GetDescription();
    }
}
