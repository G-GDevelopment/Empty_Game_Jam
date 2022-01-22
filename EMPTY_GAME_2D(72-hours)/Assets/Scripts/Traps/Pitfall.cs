using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pitfall : MonoBehaviour
{
    private int _activatePitfall = 0;

    private List<ISpotted> _detectedCreatures = new List<ISpotted>();

    public void Update()
    {
        CheckForDetectedCreatures();

    }

    public void AddToDetected(Collider2D p_collision)
    {
        ISpotted detectables = p_collision.GetComponent<ISpotted>();

        if (detectables != null)
        {
            _detectedCreatures.Add(detectables);
        }
    }

    public void RemoveFromDetected(Collider2D p_collision)
    {
        ISpotted detectables = p_collision.GetComponent<ISpotted>();
        if (detectables != null)
        {
            _detectedCreatures.Remove(detectables);
        }

    }
    public void CheckForDetectedCreatures()
    {
        foreach (ISpotted item in _detectedCreatures.ToList())
        {
            if(_activatePitfall > 1)
            {
                item.Damage(420);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_activatePitfall > 1)
        {
            AddToDetected(collision);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_activatePitfall <= 1)
        {
            _activatePitfall++;
        }

        if (_activatePitfall > 1)
        {
            RemoveFromDetected(collision);

        }

    }
}
