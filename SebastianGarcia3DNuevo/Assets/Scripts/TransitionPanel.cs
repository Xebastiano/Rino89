using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionPanel : MonoBehaviour{

    Image Image;
    public float transitionSpeed = 3.0f;

    static public TransitionPanel instance;

    void Awake (){
        if(instance = null) {
            DontDestroyOnLoad (transform.parent.gameObject);
            instance = this;
        } else {
            DestroyImmediate (transform.parent.gameObject);
        }
    }

    // Start is called before the first frame update
    public void Initialize(){
        Image = GetComponent<Image> ();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public IEnumerator FadeAlpha(float targetValue){
        Color temp;
        while(Image.color.a != targetValue) {
            temp = Image.color;
            temp.a = Mathf.MoveTowards (temp.a, targetValue, transitionSpeed * Time.deltaTime);
            Image.color = temp;
            yield return null;
        }
    }
}
