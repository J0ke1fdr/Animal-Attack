using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public JoyStick leftJoyStick;           //左手柄的控制脚本
    public JoyStick rightJoyStick;        //右手柄的控制脚本

    public float speed = 0.07f;                   

    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 flipDirection;
    private bool moving = false;
    private bool attack = false;

	void Start ()
    {
        leftJoyStick.OnJoyStickTouchBegin += OnLeftJoyStickBegin;
        leftJoyStick.OnJoyStickTouchMove += OnLeftJoyStickMove;
        leftJoyStick.OnJoyStickTouchEnd += OnLeftJoyStickEnd;

        rightJoyStick.OnJoyStickTouchBegin += OnRightJoyStickBegin;
        rightJoyStick.OnJoyStickTouchMove += OnRightJoyStickMove;
        rightJoyStick.OnJoyStickTouchEnd += OnRightJoyStickEnd;

        controller = GetComponent<CharacterController>();
    }
		
	void Update ()
    {        
        if(moving)
        {
            controller.Move(moveDirection * speed);
        }
    }
    //左手摇杆接触开始
    void OnLeftJoyStickBegin(Vector2 move)
    {
        //Debug.Log("touch begin.");
        moving = true;
    }
    //左手摇杆移动
    void OnLeftJoyStickMove(Vector2 move)
    {
        //Debug.Log("move: " + move.x + "," + move.y);
        moveDirection = new Vector3(move.x, 0, move.y);
    }
    //左手摇杆接触结束
    void OnLeftJoyStickEnd()
    {
        //Debug.Log("touch end.");
        moving = false;
    }

    //右手摇杆接触开始
    void OnRightJoyStickBegin(Vector2 move)
    {
        //开火
        attack = true;
    }
    //右手摇杆移动
    void OnRightJoyStickMove(Vector2 move)
    {
        flipDirection = new Vector3(move.x, 0, move.y);

        transform.rotation = Quaternion.LookRotation(flipDirection );
    }
    //右手摇杆接触结束
    void OnRightJoyStickEnd()
    {
        attack = false;
    }
    public bool CheckAttack()
    {
        return attack;
    }
}
