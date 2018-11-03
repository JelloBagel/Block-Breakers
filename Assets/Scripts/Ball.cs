using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle _paddle;

    private Vector3 _paddleToBallVector;
    private bool _hasStarted;
    private AudioSource collisionAudio;

	// Use this for initialization
	void Start () {
        //_paddle = gameObject.GetComponent<Paddle>();
        _paddle = GameObject.FindObjectOfType<Paddle>();
        _paddleToBallVector = this.transform.position - _paddle.transform.position;
        collisionAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!_hasStarted)
        {
            //Lock ball relative to paddle
            this.transform.position = _paddle.transform.position + _paddleToBallVector;

            //Wait for mouse press to launch
            if (Input.GetMouseButtonDown(0))
            {
                print("mouse clicked, launch ball");

                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
         
                _hasStarted = true;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (_hasStarted && !collision.gameObject.CompareTag("Breakable"))
        {
            collisionAudio.Play();
        }
        GetComponent<Rigidbody2D>().velocity += tweak;
    }
}
