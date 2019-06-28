using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSwitch : Activator{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
    void OnTriggerEnter (Collider other){
        if (other.CompareTag ("Player")) {
            other.GetComponent<PlayerAtributes> ().targetActivator = this;
        }
    }
    void OnTriggerExit (Collider other){
        PlayerAtributes player = other.GetComponent<PlayerAtributes> ();
        if (other.GetComponent<PlayerAtributes> ().targetActivator = null) ;
    }
}
