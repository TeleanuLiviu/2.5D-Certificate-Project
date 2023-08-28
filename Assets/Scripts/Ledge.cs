using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{

    public bool _climbFinished;

    public void Start()
    {
        _climbFinished = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LedgeChecker")
        {
            
            var Player = other.transform.parent.GetComponent<Player>();
           
                Player.GrabLedge();
                other.transform.parent.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 0.71f, this.gameObject.transform.position.y - 5.64f, this.gameObject.transform.position.z);
                Player.currentLedge = this;
               
            
           
            

        }

       
    }

}
