using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public void AdjustProgression(ChoiceEvent change, int choice)
    {
        (int t, int s, int ex, int en, int a) points = change.GetPointChange();

        levelTechnology += points.t * milestoneScalar * choice;
        levelStability += points.s * milestoneScalar * choice;
        levelExploration += points.ex * milestoneScalar * choice;
        levelEnlightenment += points.en * milestoneScalar * choice;
        levelAbundance += points.a * milestoneScalar * choice;

        Debug.Log($"{levelTechnology} {levelStability} {levelExploration} {levelEnlightenment} {levelAbundance}");

        //  TODO: check if any values are negative (then lose)
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
    
}
