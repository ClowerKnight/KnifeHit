using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField]
    public float[] hizlar;
    [SerializeField]
    public float[] times;
    public int index;

    WheelJoint2D targetwhell;
    JointMotor2D motor;

    void Start()
    {
        targetwhell = GetComponent<WheelJoint2D>();
        motor = new JointMotor2D();
        StartCoroutine("donusislemi");
    }

    void Update()
    {
        
    }

    IEnumerator donusislemi()
    {
        index = 0;
        while (true)
        {
            targetwhell.motor = motor;
            motor.maxMotorTorque = 10000;
            motor.motorSpeed = hizlar[index];
            yield return new WaitForSecondsRealtime(times[index]);
            index++;
            if (index==hizlar.Length)
            {
                index = 0;
            }
        }
    }




}
