using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {
    public float followSpeed;
    public float minSpeed = 3.2f;
    //Vector2 camUnitDimentions = new Vector2(8.9f,5.0f);
    Vector2 camUnitDimentions;
    public PlayerPhysicsMove playerMovement;
    public float maxTargetDistance = 3.5f;
    Vector2 cam2DPos { get { return transform.position; } }
    Vector2 limits { get { return playerMovement.limits - camUnitDimentions; } }
    Vector2 camFollowPoint{ get {
            return playerMovement.current2DPos + playerMovement.mousePlayerDelta.normalized *
                Mathf.Clamp(playerMovement.mousePlayerDelta.magnitude, 0, maxTargetDistance);
        }
    }

    // Start is called before the first frame update
    void Start () {
        camUnitDimentions = new Vector2(Camera.main.orthographicSize * 16 / 9,Camera.main.orthographicSize);
        //limits = new Vector2(20.0f,14.0f) - camUnitDimentions;
        //GameObject foundObject = GameObject.Find("Square");
        //Debug.Log(foundObject.name);
    }
    
    // Update is called once per frame
    void LateUpdate () {
        if (playerMovement) {

            /*Vector3 temp = Vector3.MoveTowards (transform.position, followTarget.position, followSpeed * Time.deltaTime);
            temp.z = transform.position.z;
            transform.position = temp;*/

            /*Vector3 direction = (followTarget.position - transform.position).normalized;

            Vector3 temp = transform.position;*/

            Vector3 temp = Vector3.MoveTowards(transform.position, camFollowPoint, minSpeed + (camFollowPoint - cam2DPos).magnitude * followSpeed * Time.deltaTime);
            temp.x = Mathf.Clamp(temp.x,-limits.x,limits.x);
            temp.y = Mathf.Clamp(temp.y,-limits.y,limits.y);
            temp.z = transform.position.z;
            transform.position = temp;
        }
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawLine(cam2DPos, camFollowPoint);
        Gizmos.DrawWireSphere(cam2DPos, 0.35f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(camFollowPoint, 0.35f);
    }
}
