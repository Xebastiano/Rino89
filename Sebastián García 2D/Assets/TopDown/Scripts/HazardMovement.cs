using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMovement : MonoBehaviour {

    public float speed = 1;
    public Vector3 point;
    public Vector3 axis = Vector3.back;
    public int lives = 10;
    // Start is called before the first frame update
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        transform.RotateAround (point, axis, speed * Time.deltaTime);
        transform.rotation = Quaternion.identity;

        if (lives == 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "bullet"){
            lives = lives - 1;
        }
    }
    void OnDestroy(){
        FindObjectOfType<ObjectiveControl>().remainingEnemies--;
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere (point, (point - transform.position).magnitude);
        Gizmos.color = Color.red;
        Gizmos.DrawRay (transform.position, (point - transform.position));
        Gizmos.DrawSphere (point, 0.25f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay (transform.position, transform.up);
        Gizmos.DrawRay (transform.position, transform.right);
    }
}
