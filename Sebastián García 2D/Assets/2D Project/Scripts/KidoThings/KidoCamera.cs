using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidoCamera : MonoBehaviour{
    Vector2 CamSpace;
    public float CamSpeed;
    public MainScript Limits;
    public KidoMovement Movement;
    Vector2 CamLimits { get { return Limits.Limits - CamSpace;} }

    Vector2 tempCamSpace { get{ return tempTarget.position; } }
    
    Transform tempTarget;
    float tempSpeed;

    float targetOrtographicSize = 5;

    // Start is called before the first frame update
    void Start(){
        CamSpace = new Vector2(Camera.main.orthographicSize * 16 / 9,Camera.main.orthographicSize);

    }

    // Update is called once per frame
    void Update() {
        if (Movement) {
            Vector3 temp = tempTarget ? Vector3.MoveTowards(transform.position, tempCamSpace, tempSpeed * Time.deltaTime) :
                Vector3.MoveTowards(transform.position, Movement.GetComponent<Transform>().position, CamSpeed * Time.deltaTime);
            temp.x = Mathf.Clamp(temp.x, -CamLimits.x, CamLimits.x);
            temp.y = Mathf.Clamp(temp.y, -CamLimits.y, CamLimits.y);
            temp.z = transform.position.z;
            transform.position = temp;
        }

        if (Camera.main.orthographicSize != targetOrtographicSize){
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtographicSize, 5 * Time.deltaTime);
        }
    }

    public void SetTempTarget (Transform target = null, float speed = 0, float size = 4) {
        
        tempTarget = target;
        tempSpeed = speed;
        targetOrtographicSize = size;
    }
}
