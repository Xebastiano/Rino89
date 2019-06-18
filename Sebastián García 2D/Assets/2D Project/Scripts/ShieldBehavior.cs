using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour{

    public int LaunchSpeed = 3;
    public MainScript Walls;
    public Vector3 direction = Vector3.right;
    Vector2 collidersize;
    Vector2 position { get { return transform.position; } }
    Vector2 limits {get { return Walls.Limits - (collidersize * transform.localScale) / 2; } }

    // Start is called before the first frame update
    void Start(){
        collidersize = gameObject.GetComponent<BoxCollider2D>().size;
    }

    // Update is called once per frame
    void Update(){
        Vector2 Moving = position * LaunchSpeed * Time.deltaTime;
        Moving.x = Mathf.Clamp(Moving.x, -limits.x, limits.x);
        Moving.y = Mathf.Clamp(Moving.y, -limits.y, limits.y);
        transform.Translate(Moving);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("EnemyBullet")){
            Destroy(other.gameObject);
        }
    }
}
