﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public float gravity = 9;
    public float horizontalSpeed = 15;
    public Collider2D playerCollider;
    public float JumpForce = 9;

    public float width { get { return playerCollider.bounds.size.x ; } }
    public float height { get { return playerCollider.bounds.size.y ; } }
    Vector3 leftCorner { get { return transform.position + (Vector3.left * width / 2 ); } }
    Vector3 rightCorner { get { return transform.position + (Vector3.right * width / 2); } }

    float verticalSpeed;
    bool grounded;
    float detectionDistance = 0.2f;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        RaycastHit2D leftHit = Physics2D.Raycast(leftCorner,Vector3.down, detectionDistance);
        RaycastHit2D righttHit = Physics2D.Raycast(rightCorner,Vector3.down, detectionDistance);

        if (leftHit || righttHit){
            grounded = true;
        }else{
            grounded = false;
        }

        Vector3 horizontalMovement = Vector3.right * Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        if(!grounded) {
            verticalSpeed -= gravity * Time.deltaTime;
        } else {
            if(verticalSpeed < 0) {
                verticalSpeed = 0;
                float distance = leftHit.distance;
                if(distance == 0) { distance = righttHit.distance; }
                transform.Translate(Vector3.down * distance);
            }

            if(Input.GetKeyDown(KeyCode.Space)){
                verticalSpeed = JumpForce;
            }
        }
        Vector3 verticalMovement = Vector3.up * verticalSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement + verticalMovement);

    }

    /*void OnTriggerEnter2D (Collider2D other){
        if(other.CompareTag("Platform")){
            Debug.Log("Collided with " + other.tag);
            verticalSpeed = 0;
            grounded = true;
            float halfHeight = other.bounds.size.y * other.transform.localScale.y / 2;
            float positionDistance = Mathf.Abs(transform.position.y - other.transform.position.y);
            float pushDelta = halfHeight - positionDistance;

            transform.Translate(Vector3.up * pushDelta);
        }*/
    
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(leftCorner,Vector3.down * detectionDistance);
        Gizmos.DrawRay(rightCorner,Vector3.down* detectionDistance);

        Gizmos.DrawSphere(leftCorner,0.05f);
        Gizmos.DrawSphere(rightCorner,0.05f);
    }
}
