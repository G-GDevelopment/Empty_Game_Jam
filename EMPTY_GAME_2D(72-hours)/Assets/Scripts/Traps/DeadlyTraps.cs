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


    [SerializeField] int _playerLayer;
    [SerializeField] int _monsterLayer;

    private List<ISpotted> _detectedCreatures = new List<ISpotted>();
    private void Start()
    {
        _tile = GetComponent<Tilemap>();
    }
    public void Update()
    {
        CheckForDetectedCreatures();

        if (_trapIsActive)
        {
            _tile.SetTile(position, _spikes);
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
        if (collision.gameObject.layer == _playerLayer || collision.gameObject.layer == _monsterLayer)
        {
            AddToDetected(collision);
            FindObjectOfType<AudioManager>().PlaySound("Spikes");


            _trapIsActive = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _playerLayer || collision.gameObject.layer == _monsterLayer)
        {
            RemoveFromDetected(collision);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(position, new Vector3(1, 1, 0));

    }
}
