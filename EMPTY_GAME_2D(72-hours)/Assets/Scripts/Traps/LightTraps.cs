using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LightTraps : MonoBehaviour
{

    private List<ISpotted> _detectedCreatures = new List<ISpotted>();

    private bool _triggerOn;
    private bool _monsterInTheZone;
    [SerializeField] private int _monsterLayer;

    private void Start()
    {
        GameEvents.current.onTriggerLightTile += onLightTile;
        GameEvents.current.onExitLightTile += onExitLightTile;
    }
    public void Update()
    {
        CheckForDetectedCreatures();

        Debug.Log("Is Trigger on LightTrap: " + _triggerOn);
        Debug.Log("Is monster in the zone: " + _monsterInTheZone);
    }

    private void onLightTile()
    {
        _triggerOn = true;
    }

    private void onExitLightTile()
    {
        _triggerOn = false;
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
            item.LetThereBeLight(_triggerOn);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        AddToDetected(collision);

        if(collision.gameObject.layer == _monsterLayer)
        {
            _monsterInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

            RemoveFromDetected(collision);
    }
}
