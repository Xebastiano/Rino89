using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    private bool canJump;

    public float speed = 1f;
    public float jumpForce = 10f;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }

    // Update is called once per frame
    void Update(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h,0,v) * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && canJump){
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }
    void OnCollisionEnter (Collision collision){
        if(collision.gameObject.tag == "Chonque")
            canJump = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        other.GetComponent<ChangeMaterial>().ChangeMaterialToNew();
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        other.GetComponent<ChangeMaterial>().ChangeMaterialToOld();
    }
}