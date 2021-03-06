﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayer : MonoBehaviour
{
    public HingeJoint[] rightwheels;
    public HingeJoint[] leftwheels;
    float power;
    float turn;
    public PhotonView pview;
    // Start is called before the first frame update
    void Start()
    {
        if(pview.IsMine)
        {
            Camera.main.GetComponent<NetCamera>().SetPlayer(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pview.IsMine)
        {
            power = Input.GetAxis("Vertical");
            turn = Input.GetAxis("Horizontal");

            foreach (HingeJoint wheel in rightwheels)
            {
                JointMotor motor = new JointMotor();
                motor.targetVelocity = power * 500 + turn * -300;
                motor.force = 1000;
                wheel.motor = motor;

            }
            foreach (HingeJoint wheel in leftwheels)
            {
                JointMotor motor = new JointMotor();
                motor.targetVelocity = power * 500 + turn * 300;
                motor.force = 1000;
                wheel.motor = motor;

            }
        }
    }
}
