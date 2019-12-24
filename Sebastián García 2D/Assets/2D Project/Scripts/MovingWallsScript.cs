using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallsScript : ButtonsScript{
    public List<Vector2> MovingPosition;
    public float MovingSpeed = 0.5f;
    public int Direction = 0;
    public int TargetPosition = 0;

    Vector2 position;
    public int Distance;

    public bool GivePositions;

    // Start is called before the first frame update
    void Start(){
        MovingPosition[0] = transform.position;
        position = transform.position;
        GivePositions = true;
    }

    // Update is called once per frame
    void Update(){
        if (GivePositions == true){
            Vector2 temp1 = MovingPosition[1];
            temp1.x = position.x - Distance;
            temp1.y = position.y;

            Vector2 temp2 = MovingPosition[2];
            temp2.x = position.x + Distance;
            temp2.y = position.y;

            Vector2 temp3 = MovingPosition[3];
            temp3.x = position.x;
            temp3.y = position.y - Distance;

            Vector2 temp4 = MovingPosition[4];
            temp4.x = position.x;
            temp4.y = position.y + Distance;

        }
    }
}
