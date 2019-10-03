using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShoot : MonoBehaviour {

    public float speed = 1;
    public KidoMovement position;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Vector3 temp = Vector3.MoveTowards(transform.position, position.GetComponent<Transform>().position, speed * Time.deltaTime);
        transform.position = temp;
        speed = speed + 0.0001f;
    }
}
