using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class Pitfall : MonoBehaviour
{
    private int _activatePitfall = 0;

    private List<ISpotted> _detectedCreatures = new List<ISpotted>();

    private Tilemap _tile;
    [SerializeField] private TileBase _pitfall;
    [SerializeField] private Vector3Int position;

    [SerializeField] int _playerLayer;
    [SerializeField] int _monsterLayer;

    

    private void Start()
    {
        _tile = GetComponent<Tilemap>();


    }

    public void Update()
    {
        CheckForDetectedCreatures();

        if(_activatePitfall == 2)
        {
            _activatePitfall++;
            _tile.SetTile(position, _pitfall);

            FindObjectOfType<AudioManager>().PlaySound("Pitfall");

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
            if(_activatePitfall > 1)
            {
                item.Damage(420);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayer || collision.gameObject.layer == _monsterLayer)
        {
            if (_activatePitfall > 1)
            {
                _activatePitfall++;
                AddToDetected(collision);

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _playerLayer || collision.gameObject.layer == _monsterLayer)
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(position, new Vector3(1, 1, 0));

    }
}
