using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidoMovement : MonoBehaviour{

    public int WalkingSpeed = 3;
    public MainScript Limits;
    Vector2 ColliderSize;
    Vector2 KidoLimits { get { return Limits.Limits - ((ColliderSize * transform.localScale) / 2); } }
    Rigidbody2D KidoBody;
    
    
    // Start is called before the first frame update
    void Start(){
        ColliderSize = gameObject.GetComponent<BoxCollider2D>().size;
        KidoBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        Vector2 verMove = Input.GetAxisRaw("Vertical") * Vector3.up;
        Vector2 horMove = Input.GetAxisRaw("Horizontal") * Vector3.right;
        if (KidoBody){
            Vector2 WalkingDirection = KidoBody.position + ((horMove + verMove).normalized * WalkingSpeed * Time.fixedDeltaTime);
            WalkingDirection.x = Mathf.Clamp(WalkingDirection.x, -KidoLimits.x, KidoLimits.x);
            WalkingDirection.y = Mathf.Clamp(WalkingDirection.y, -KidoLimits.y, KidoLimits.y);
            KidoBody.MovePosition(WalkingDirection);
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(Vector3.zero,KidoLimits * 2);
    }
}
