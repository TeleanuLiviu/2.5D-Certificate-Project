using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 posLeft, posRight , posUp, posDown;
    bool moveright, moveleft, moveup, movedown;

    public void Start()
    {
        posLeft = this.gameObject.transform.position;
        posRight = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 30f);

        posUp = this.gameObject.transform.position;
        posDown = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 30f, this.gameObject.transform.position.z);
    }
    void FixedUpdate()
    {



        if(this.gameObject.tag == "PlatformLeftRight")
         {

         if (this.gameObject.transform.position == posRight)
        {
            moveright = false;
            moveleft = true;
           
        }


        if (this.gameObject.transform.position == posLeft)
        {
            moveright = true;
            moveleft = false;

        }

        if (moveleft)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, posLeft, 10.0f * Time.deltaTime);
        }

        if (moveright)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, posRight, 10.0f * Time.deltaTime);
        }


         }
        
        if (this.gameObject.tag == "PlatformUpDown")
        {
            if (this.gameObject.transform.position == posUp)
            {
                moveup = false;
                movedown = true;

            }

            if (this.gameObject.transform.position == posDown)
            {
                moveup = true;
                movedown = false;

            }

            if (movedown)
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, posDown, 10.0f * Time.deltaTime);
            }

            if (moveup)
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, posUp, 10.0f * Time.deltaTime);
            }


        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.gameObject.transform;
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent =null;
        }
    }
}
