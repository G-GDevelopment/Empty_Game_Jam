using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private int _playerLayer;
    [SerializeField] private LoadManager _loadManager;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            _loadManager.LoadNextLevelGame();
            Debug.Log("Player Finished Level");
        }
    }
}
