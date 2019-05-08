using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

    public Transform followTarget;
    public float followSpeed;
    //Vector2 camUnitDimentions = new Vector2(8.9f,5.0f);
    Vector2 camUnitDimentions;
    Vector2 limits;

    // Start is called before the first frame update
    void Start () {

        limits = new Vector2(10.0f,7.0f) - camUnitDimentions;
    }

    // Update is called once per frame
    void Update () {
        if (followTarget) {
            /*Vector3 temp = Vector3.MoveTowards (transform.position, followTarget.position, followSpeed * Time.deltaTime);
            temp.z = transform.position.z;
            transform.position = temp;*/
            Vector3 direction = (followTarget.position - transform.position).normalized;

        }
    }
}
