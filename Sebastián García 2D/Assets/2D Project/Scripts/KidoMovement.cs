using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidoMovement : MonoBehaviour{

    public int WalkingSpeed = 3;
    public MainScript Limits;
    Vector2 ColliderSize;
    Vector2 KidoLimits { get { return Limits.Limits - ((ColliderSize * transform.localScale) / 2); } }

    // Start is called before the first frame update
    void Start(){
        ColliderSize = gameObject.GetComponent<BoxCollider2D>().size;
    }

    // Update is called once per frame
    void FixedUpdate(){
        Vector2 verMove = Input.GetAxisRaw("Vertical") * Vector3.up;
        Vector2 horMove = Input.GetAxisRaw("Horizontal") * Vector3.right;
    }
}
