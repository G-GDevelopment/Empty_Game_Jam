using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ability : CoreComponents
{
    public bool IsSpotted { get => isSpotted; set => isSpotted = value; }

    private bool isSpotted;

    private List<ISpotted> _detectedCreatures = new List<ISpotted>();


    public void LogicUpdate()
    {
        CheckForDetectedCreatures();
    }

    public void AddToDetected(Collider2D p_collision)
    {
        ISpotted detectables = p_collision.GetComponent<ISpotted>();

        if(detectables != null){
            _detectedCreatures.Add(detectables);
        }
    }

    public void RemoveFromDetected(Collider2D p_collision)
    {
        ISpotted detectables = p_collision.GetComponent<ISpotted>();
        if(detectables != null)
        {
            _detectedCreatures.Remove(detectables);
        }

    }

    public void CheckForDetectedCreatures()
    {
        foreach (ISpotted item in _detectedCreatures.ToList())
        {
            item.IsSpottedByPlayer(true);
        }
    }
}
