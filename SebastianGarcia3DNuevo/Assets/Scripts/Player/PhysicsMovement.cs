﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour{

    public float speed = 5;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Vector3 horizontal = Vector3.right * Input.GetAxis ("Horizontal");
        transform.Translate (horizontal * speed * Time.deltaTime);
    }
}
