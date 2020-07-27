using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Turns/Turn")]
public class Turn : ScriptableObject
{
    public PlayerHolder player;
    public Phase[] phases;
    [System.NonSerialized]
    public int currentPhaseIndex = 0;
    public PhaseVariable currentPhase;

    public PlayerAction[] turnStartActions;

    public void OnTurnStart()
    {
        if (turnStartActions == null)
            return;

        for (int i = 0; i < turnStartActions.Length; i++)
        {
            turnStartActions[i].Execute(player);
        }
    }

    public bool Execute()
    {
        bool result = false;

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

    public void EndCurrentPhase()
    {
        phases[currentPhaseIndex].forceExit = true;
    }

}
