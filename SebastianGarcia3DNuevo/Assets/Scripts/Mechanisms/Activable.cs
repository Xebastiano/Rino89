using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour{

    public bool currentlyActive { get; private set; }
    List<Activator> activators;
    Activator LastActivator;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public bool SetActive (bool state){
        return currentlyActive = state;
    }
}
