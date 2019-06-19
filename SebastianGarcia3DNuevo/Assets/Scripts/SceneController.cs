using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour{

    TransitionPanel panel;

    // Start is called before the first frame update
    void Start(){
        panel = TransitionPanel.instance;
        panel.Initialize ();
    }

    // Update is called once per frame
    void Update(){
        
    }
    public void LoadScene (int Index) {
        if(Index < SceneManager.sceneCount && Index >= 0) {
            SceneManager.LoadScene (Index);
        }
    }
    void OnTriggerExit (Collider other){
        if (other.CompareTag ("Player")) {
            StartCoroutine (RespawnRoutine ());
        }
    }

    IEnumerator RespawnRoutine (){
        yield return panel.FadeAlpha (1);
        LoadScene (SceneManager.GetActiveScene ().buildIndex);
        yield return new
        yield return panel.FadeAlpha (0);
    }
}
