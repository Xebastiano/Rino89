using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 15;
    public Vector2 limits = new Vector2(5,3.5f);
    Vector2 shapeLimits { get { return limits - ((colliderSize * transform.localScale) / 2); } }
    Vector2 colliderSize;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start () {
        colliderSize = gameObject.GetComponent<BoxCollider2D>().size;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        //get current Horizontal Movement
        float horDirection = Input.GetAxisRaw("Horizontal");
        Vector2 horMove = horDirection * Vector3.right;
        //get current Vertical Movement
        float verDirection = Input.GetAxisRaw("Vertical");
        Vector2 verMove = verDirection * Vector3.up;

        rb2D.MovePosition(rb2D.position + ((horMove + verMove).normalized * moveSpeed * Time.deltaTime));

        Vector2 temp = transform.position;
        transform.Translate ((horMove + verMove).normalized * moveSpeed * Time.deltaTime);
        temp.x = Mathf.Clamp(transform.position.x,-shapeLimits.x,shapeLimits.x);
        temp.y = Mathf.Clamp(transform.position.y,-shapeLimits.y,shapeLimits.y);
        transform.position = temp;
        //posibilidad 1
        /*if(horDirection > 0){
        
        }else if(horDirection < 0){
        
        }*/

        //posibilidad2
        /*if (transform.position.x < -limits.x || transform.position.x > limits.x){
            horMove *= 0;
            int limit = (int) transform.position.x;
            Vector3 temp = transform.position;
            temp.x = limit;
            transform.position = temp;
        }*/

        //posibilidad3
        /*if((transform.position.x < -limits.x || transform.position.x > limits.x) ||
            (transform.position.y < -limits.y || transform.position.y > limits.y)){
            transform.position = temp;
        }*/
    }

    void OnTriggerEnter2D (Collider2D other){
        Debug.Log("Collision");
    }
    void OnDrawGizmos(){
        Gizmos.DrawSphere(transform.position,0.15f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero,limits * 2);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(Vector3.zero,shapeLimits * 2);
    }
}
