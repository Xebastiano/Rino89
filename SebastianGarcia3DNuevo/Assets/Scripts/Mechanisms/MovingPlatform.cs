using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Activable{
    // Start is called before the first frame update
    void Start(){
        SetActive (true);
    }

    // Update is called once per frame
    void Update(){
        if (currentlyActive) {
            //TO DO: Move the platform
            transform.Translate (Vector3.up * 2 * Time.deltaTime);
        }
    }
}
