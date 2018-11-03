using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private Level_Manager _levelManager;

    private void Start()
    {
        _levelManager = GameObject.FindObjectOfType<Level_Manager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _levelManager.LoadLevel("Lose Screen");
    }
}
