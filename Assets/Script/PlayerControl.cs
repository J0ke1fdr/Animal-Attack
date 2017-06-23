using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public JoyStick leftJoyStick;           //左手柄的控制脚本
    //public JoyStick rightJoyStick;        //右手柄的控制脚本

    public float moveStep = 7f;                   

    private CharacterController controller;
    private Vector3 moveDirection;


	void Start ()
    {
        leftJoyStick.OnJoyStickTouchBegin += OnJoyStickBegin;
        leftJoyStick.OnJoyStickTouchMove += OnJoyStickMove;
        leftJoyStick.OnJoyStickTouchEnd += OnJoyStickEnd;

        controller = GetComponent<CharacterController>();
    }
		
	void Update ()
    {        

    }

    void OnJoyStickBegin(Vector2 move)
    {
        Debug.Log("touch begin.");
    }

    void OnJoyStickMove(Vector2 move)
    {
        Vector3 dir = new Vector3(move.x * moveStep * Time.deltaTime, 0, move.y * moveStep * Time.deltaTime);
        controller.Move(dir);
    }

    void OnJoyStickEnd()
    {
        Debug.Log("touch end.");
    }
}
