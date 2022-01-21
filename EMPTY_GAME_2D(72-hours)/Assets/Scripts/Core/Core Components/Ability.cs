using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ability : CoreComponents
{


    private Vector2 _horizontalCollisionSize;

    private BoxCollider2D _boxCollider2D;
    public bool IsSpotted { get => isSpotted; set => isSpotted = value; }

    private bool isSpotted;

    private List<ISpotted> _detectedCreatures = new List<ISpotted>();

    protected override void Awake()
    {
        base.Awake();

        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    public void LogicUpdate()
    {
        CheckForDetectedCreatures();
    }

    public void UpdateBoxCollider(Vector2 p_size, Vector2 p_offset)
    {
        _boxCollider2D.size = p_size;
        _boxCollider2D.offset = p_offset;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFromDetected(collision);
    }
}
