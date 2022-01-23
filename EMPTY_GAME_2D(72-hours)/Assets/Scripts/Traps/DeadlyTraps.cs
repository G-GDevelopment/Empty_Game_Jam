using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class DeadlyTraps : MonoBehaviour
{
    private Tilemap _tile;
    [SerializeField] private TileBase _spikes;
    private bool _trapIsActive;
    [SerializeField] private Vector3Int position;
    private List<ISpotted> _detectedCreatures = new List<ISpotted>();

    public void Update()
    {
        CheckForDetectedCreatures();

        if (_trapIsActive)
        {
            FindObjectOfType<AudioManager>().PlaySound("Spikes", true);
            _trapIsActive = false;
        }
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
            item.Damage(420);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddToDetected(collision);

        _tile.SetTile(position, _spikes);

        _trapIsActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFromDetected(collision);
    }
}
