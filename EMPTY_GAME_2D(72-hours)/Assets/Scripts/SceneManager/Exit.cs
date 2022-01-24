using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private int _playerLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _playerLayer)
        {
            Debug.Log("Player Finished Level");
        }
    }
}
