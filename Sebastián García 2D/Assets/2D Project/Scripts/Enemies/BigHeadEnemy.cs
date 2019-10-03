using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHeadEnemy : MonoBehaviour{

    public Vector3[] ChangeDirection;
    public float ChargeSpeed = 1;
    int ChargeDirection = 1;
    int Direction = 0;

    public MainEnemyScript getActive;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (getActive.TouchingPLayer == true){
            transform.position = Vector3.MoveTowards(transform.position, ChangeDirection[Direction], ChargeSpeed * Time.deltaTime);
            if (transform.position == ChangeDirection[Direction]){
                Direction += ChargeDirection;
                if (Direction >= ChangeDirection.Length || Direction < 0){
                    Destroy(gameObject);
                }
            }
        }
    }

    void Reset(){
        ChangeDirection = new Vector3[1];
        ChangeDirection[0] = transform.position;
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.green;
        for (int i = 0; i < ChangeDirection.Length; i++)
        {
            if ((i + 1) < ChangeDirection.Length)
            {
                Gizmos.DrawLine(ChangeDirection[i], ChangeDirection[i + 1]);
            }
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < ChangeDirection.Length; i++)
        {
            Gizmos.DrawSphere(ChangeDirection[i], 0.15f);
        }
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.up);
        Gizmos.DrawRay(transform.position, transform.right);
    }
}
