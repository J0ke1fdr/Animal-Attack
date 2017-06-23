using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public JoyStick leftJoyStick;           //左手柄的控制脚本
    //public JoyStick rightJoyStick;        //右手柄的控制脚本

    public float speed = 0.07f;                   

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool moving = false;

	void Start ()
    {
        leftJoyStick.OnJoyStickTouchBegin += OnJoyStickBegin;
        leftJoyStick.OnJoyStickTouchMove += OnJoyStickMove;
        leftJoyStick.OnJoyStickTouchEnd += OnJoyStickEnd;

        controller = GetComponent<CharacterController>();
    }
		
	void Update ()
    {        
        if(moving)
        {
            controller.Move(moveDirection * speed);
        }
    }

    void OnJoyStickBegin(Vector2 move)
    {
        Debug.Log("touch begin.");
        moving = true;
    }

    void OnJoyStickMove(Vector2 move)
    {
        Debug.Log("move: " + move.x + "," + move.y);
        //Vector3 dir = new Vector3(move.x * speed, 0, move.y * speed);
        //controller.Move(dir);
        moveDirection = new Vector3(move.x, 0, move.y);
    }

    void OnJoyStickEnd()
    {
        Debug.Log("touch end.");
        moving = false;
    }
}
