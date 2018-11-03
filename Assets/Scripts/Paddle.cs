using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;

    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        } else
        {
            AutoPlay(); 
        }

    }

    private void MoveWithMouse ()
    {
        Vector3 paddlePos = new Vector3(0f, this.transform.position.y, 0f);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16 - 8;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, -7.5f, 7.5f);
        this.transform.position = paddlePos;
    }

    private void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(ball.transform.position.x, -7.5f, 7.5f);
        this.transform.position = paddlePos;
    }
}
