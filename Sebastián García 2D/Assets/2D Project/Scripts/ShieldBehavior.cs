﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour{

    public Vector3 ProtectedArea = Vector3.zero;
    public bool ShieldLaunch;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(ProtectedArea);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("EnemyBullet")){
            Destroy(other.gameObject);
        }
    }
}
