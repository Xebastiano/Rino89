using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledMovement : MovScript {

    public float gravity;
    public CharacterController characterController;
    Animator playerAnimator;
    float verticalSpeed;
    public float jumpForce = 10;
    bool
    //bool lastGrounded;

    // Start is called before the first frame update
    void Start () {
        playerAnimator = transform.GetChild (0).GetComponent<Animator> ();
        characterController.detectCollisions = false;
    }

    // Update is called once per frame
    void Update () {
        //bool grounded = Physics.Raycast(transform.GetChild (0).position, Vector3.down, 0.15f);
        if (!grounded) {
            verticalSpeed -= gravity * Time.deltaTime;
        } else {
            verticalSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log (verticalSpeed);
                verticalSpeed = jumpForce;
                playerAnimator.SetTrigger ("Jump");
                Debug.Log (verticalSpeed);
            }
        }
        Vector3 forwardAxis = transform.forward * speed * Input.GetAxis ("Vertical");
        Vector3 verticalAxis = Vector3.up * verticalSpeed;
        Vector3 horizontal = Vector3.up * Input.GetAxis ("Horizontal");

        playerAnimator.SetBool ("Grounded", grounded);

        characterController.Move ((forwardAxis + verticalAxis) * Time.deltaTime);
        transform.Rotate (horizontal * angularSpeed * Time.deltaTime);
    }

    void OnCollisionStay (Collision collision){
        Debug.Log ("Collision" + collision.collider.name);
        Debug.DrawRay (collision.contacts[0].point, collision.contacts[0].normal, Color.red);
        for (int i = 0 < collision.contactCount[0]. )
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.black;
        Gizmos.DrawRay (transform.GetChild (0).position, Vector3.down * 0.15f);
    }
}
