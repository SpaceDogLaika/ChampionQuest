using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Turns/Turn")]
public class Turn : ScriptableObject
{
    public string turnName;
    public PlayerHolder player;
    public Phase[] phases;
    [System.NonSerialized]
    public int currentPhaseIndex;
    public PhaseVariable currentPhase;

    public bool Execute()
    {
        bool result = false;
        Debug.Log(currentPhaseIndex);
        currentPhase.value = phases[currentPhaseIndex];
        phases[currentPhaseIndex].OnStartPhase();

        bool phaseIsComplete = phases[currentPhaseIndex].IsComplete();

        if (phaseIsComplete)
        {
            phases[currentPhaseIndex].OnEndPhase();
            currentPhaseIndex++;
            if (currentPhaseIndex > phases.Length - 1)
            {
                currentPhaseIndex = 0;
                result = true;
            }
        }

        return result;
    }

}
