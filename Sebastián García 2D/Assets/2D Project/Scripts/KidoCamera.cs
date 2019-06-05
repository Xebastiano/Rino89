using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidoCamera : MonoBehaviour{
    Vector2 CamSpace;
    public MainScript Limits;
    Vector2 CamLimits { get { return Limits.Limits - CamSpace;} }

    // Start is called before the first frame update
    void Start(){
        CamSpace = new Vector2(Camera.main.orthographicSize * 16 / 9,Camera.main.orthographicSize);

    }

    // Update is called once per frame
    /*void Update(){
        Vector3 temp = tempTarget ? Vector3.MoveTowards(transform.position,tempSpeed * Time.deltaTime);
        temp.x = Mathf.Clamp(temp.x,-Limits.x,Limits.x);
        temp.y = Mathf.Clamp(temp.y,-Limits.y,Limits.y);
        temp.z = transform.position.z;
        transform.position = temp;
    }*/
}
