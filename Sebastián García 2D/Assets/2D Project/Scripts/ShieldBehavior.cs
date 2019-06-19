using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour{

    public int LaunchSpeed = 3;
    public MainScript Walls;
    public Vector3 direction = Vector3.zero;
    Vector2 collidersize;
    Vector2 limits {get { return Walls.Limits - (collidersize * transform.localScale) / 2; } }

    // Start is called before the first frame update
    void Start(){
        collidersize = gameObject.GetComponent<BoxCollider2D>().size;
    }

    // Update is called once per frame
    void Update(){

        Vector2 Moving = direction * LaunchSpeed * Time.deltaTime;

        Vector2 position = transform.position;
        position += Moving;

        position.x = Mathf.Clamp (position.x, -limits.x, limits.x);
        position.y = Mathf.Clamp (position.y, -limits.y, limits.y);

        transform.position = position;
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("EnemyBullet")){
            Destroy(other.gameObject);
        }
    }
    void OnDrawGizmos (){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube (Vector3.zero, limits * 2);
    }
}
