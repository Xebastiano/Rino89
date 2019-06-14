using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour{

    public float LaunchSpeed = 3.0f;
    public Vector2 ProtectedArea = Vector2.right;
    KidoMovement Walls;
    Vector2 collidersize;
    Vector2 limits {get { return Walls.KidoLimits - (collidersize * transform.localScale) / 2; } }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Vector2 Moving = ProtectedArea * LaunchSpeed * Time.deltaTime;
        transform.Translate (Moving);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("EnemyBullet")){
            Destroy(other.gameObject);
        }
    }
}
