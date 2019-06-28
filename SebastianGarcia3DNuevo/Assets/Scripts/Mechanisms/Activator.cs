using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour{

    public List<Activable> activables;
    bool InRange;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Activate (){
        forach (Activable activable in activables){
            activables.SetActive (!activables.currentlyActive);
        }
    }
}
