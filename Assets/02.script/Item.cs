using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float rotatespeed;
    

    void Update() //업데이트에서 움직이면 타임델타타임 넣어주기
    {
        transform.Rotate(Vector3.up*rotatespeed*Time.deltaTime, Space.World);
    }

}

