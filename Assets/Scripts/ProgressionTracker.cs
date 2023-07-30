using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class TextUpdateEvent : UnityEvent<float> {}

//  Handles Core Game Logic
public class ProgressionTracker : MonoBehaviour
{
    /// Main Parameters
    private float levelTechnology       = 0f;
    private float levelStability        = 0f;
    private float levelExploration      = 0f;
    private float levelEnlightenment    = 0f;
    private float levelAbundance        = 0f;
    private Age currentStage            = Age.Prehistoric;
    private float timeElapsed           = 0f;
    private float milestoneScalar       = 1f;

    [SerializeField] private ResourceProgressBar barTech;
    [SerializeField] private ResourceProgressBar barStab;
    [SerializeField] private ResourceProgressBar barExplore;
    [SerializeField] private ResourceProgressBar barEnlight;
    [SerializeField] private ResourceProgressBar barAbundance;

    /// Getter Functions
    public float GetTechnologyLevel()       {   return levelTechnology;     }
    public float GetStabilityLevel()        {   return levelStability;      }
    public float GetExplorationLevel()      {   return levelExploration;    }
    public float GetEnglightenmentLevel()   {   return levelEnlightenment;  }
    public float GetAbundanceLevel()        {   return levelAbundance;      }
    public Age GetTechnologicalStage()      {   return currentStage;        }
    public float GetTimeElapsed()           {   return timeElapsed;         }
    
    /*
    TODO LIST:
        X   add chance for random event to occur (pause year counter & wait for player input)
        X   add interaction between random events and timer (wait for player input before resuming timer)
        X   calculate effects of interaction event and update resource values accordingly
        -   check if player's resources are below minimum survivable threshold (and exit game if so)
        -   trigger milestone events every n events
        -   update technology enum when threshold & milestone requirements are met
        -   call "the great filter" event when minimum requirements for singularity are met
        -   game ends when singularity is achieved
        -   track time scalar
    */

    private void Start()
    {
        UpdateStats();
    }

    public void AdjustProgression(ChoiceEvent change, int choice)
    {
        (int t, int s, int ex, int en, int a) points;

        if(choice == 1)
        {
            points = change.GetAcceptPointChange();
        }
        else
        {
            points = change.GetDeclinePointChange();
        }
        
        levelTechnology += points.t * milestoneScalar;
        levelStability += points.s * milestoneScalar;
        levelExploration += points.ex * milestoneScalar;
        levelEnlightenment += points.en * milestoneScalar;
        levelAbundance += points.a * milestoneScalar;

        levelTechnology = Mathf.Max(levelTechnology, 0f);
        levelStability = Mathf.Max(levelStability, 0f);
        levelExploration = Mathf.Max(levelExploration, 0f);
        levelEnlightenment = Mathf.Max(levelEnlightenment, 0f);
        levelAbundance = Mathf.Max(levelAbundance, 0f);

        Debug.Log($"New Values: {levelTechnology} {levelStability} {levelExploration} {levelEnlightenment} {levelAbundance}");

        //  TODO: check if any values are negative (then lose)


        UpdateStats();
    }

    private void NextMilestone()
    {
        //  set to next stage
        int next = (int) currentStage;
        next = Mathf.Clamp(next + 1, 0, 10);
        currentStage = (Age) next;

        //  increase scalar
        milestoneScalar *= 5f;
    }

    private void UpdateStats()
    {
        barTech.SetBarValue(levelTechnology);
        barStab.SetBarValue(levelStability);
        barExplore.SetBarValue(levelExploration);
        barEnlight.SetBarValue(levelEnlightenment);
        barAbundance.SetBarValue(levelAbundance);
    }

}
