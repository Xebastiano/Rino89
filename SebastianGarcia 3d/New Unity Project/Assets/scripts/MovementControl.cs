using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {

    public float speed = 1;
    public float horizontalJumpDistance = 1;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        //Vector3 tempVector = Vector3.zero;
        //tempVector.z = speed;
        //transform.position += tempVector * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 tempVector = Vector3.zero;
            tempVector.z = speed;
            transform.position += tempVector * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Vector3 tempVector = Vector3.zero;
            tempVector.x = -horizontalJumpDistance;
            transform.position += tempVector;
        } else if (Input.GetKeyDown (KeyCode.RightArrow)) {
            Vector3 tempVector = Vector3.zero;
            tempVector.x = horizontalJumpDistance;
            transform.position += tempVector;
        }
    }
}
