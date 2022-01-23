using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onTriggerLightTile;
    public void TriggerLightTile()
    {
        if(onTriggerLightTile != null)
        {
            onTriggerLightTile();
        }

    }

    public event Action onExitLightTile;
    public void ExitLightTile()
    {
        if (onExitLightTile != null)
        {
            onExitLightTile();
        }

    }

    public event Action onLookingAway;
    public void LookingAway()
    {
        if(onLookingAway != null)
        {
            onLookingAway();
        }
    }
}
