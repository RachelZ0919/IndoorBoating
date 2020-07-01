using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll_test : MonoBehaviour {

    public GameObject player;
    public float MoveSpeed = 10.0f;
    public float RotateSpeed = 10.0f;
    //private Rigidbody playerRigidbody;  // 角色的刚体组件
    Boat boat;


	void Start () {
        boat = GetComponentInChildren<Boat>();
        //playerRigidbody = player.GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        float left, right;
        left = right = 0;
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow)) //前
        { 
           // player.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow)) //后
        { 
            //player.transform.Translate(Vector3.forward * -MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) //左
        {
            left = 1;
            //player.transform.Translate(Vector3.right * -MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) //右
        {
            right = 1;
            //player.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }
        boat.Row(new Vector2(left,left), new Vector2(right,right));
    }
    
}
