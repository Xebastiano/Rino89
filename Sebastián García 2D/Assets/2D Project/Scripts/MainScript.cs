using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

    public Vector2 Limits = new Vector2(10,7);

    public GameObject TargetWall;
    public int remainingEnemies;

    // Start is called before the first frame update
    void Start() {
        remainingEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Update is called once per frame
    void Update() {
        if(remainingEnemies <= 0 && TargetWall){
            Destroy(TargetWall);
        }

    }
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero,Limits * 2);
    }
}
