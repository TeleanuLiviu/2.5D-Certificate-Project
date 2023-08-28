using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    public PlayerCallElevator _call;
    [SerializeField]
    private GameObject PointA, PointB;
    public bool moveToA, moveToB;

    public void Start()
    {
        moveToA = false;
        moveToB = true;
    }

  
    public void FixedUpdate()
    {

        if (moveToB && _call._elevatorActive && !moveToA)
        {
            
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, PointB.transform.position, 5.0f * Time.deltaTime);
        }
        else if (moveToA && _call._elevatorActive && !moveToB)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, PointA.transform.position, 5.0f * Time.deltaTime);
        }


        if (this.gameObject.transform.position == PointB.transform.position)
        {
            moveToB = false;
            moveToA = true;
            _call._elevatorActive = false;
        }

        else if (this.gameObject.transform.position == PointA.transform.position)
        {
            moveToA = false;
            moveToB = true;
            _call._elevatorActive = false;
        }

    }
}
