﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public void Row(Vector2 left,Vector2 right)
    {
        //TODO:划船，根据输入的值给船施加力，暂时定了Vector2，如果最后只用Float，只用x的值
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO:碰撞反馈
    }

    private void Update()
    {
        BoatRotationAdjust();
    }

    private void BoatRotationAdjust()
    {
        //TODO:可能需要写的函数，修正船的方向防止船翻了
    }
}
