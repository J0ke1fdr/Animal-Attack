using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public JoyStick leftJoyStick;           //左手柄的控制脚本
    public JoyStick rightJoyStick;        //右手柄的控制脚本

    public float speed = 0.07f;                   

    private CharacterController controller;
    private Animator anim;
    private AnimatorStateInfo stateInfo;
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
        anim = GetComponentInChildren<Animator>();
    }
		
	void Update ()
    {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (moving)
        {
            controller.Move(moveDirection * speed);
        }
        if(stateInfo.IsName("Base Layer.player_idle") && moving)
        {
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
        }
        if(stateInfo.IsName("Base Layer.player_walk") && !moving)
        {
            anim.SetBool("idle", true);
            anim.SetBool("walk", false);
        }
#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(Vector3.forward * 0.2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            controller.Move(Vector3.back * 0.2f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            controller.Move(Vector3.left * 0.2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            controller.Move(Vector3.right * 0.2f);
        }

#endif
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
