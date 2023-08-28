using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCallElevator : MonoBehaviour
{
    public bool _elevatorActive;
    private UIManager _ui;
    public void Start()
    {
        _elevatorActive = false;
        _ui = FindObjectOfType<UIManager>();

    }
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                _elevatorActive = true;
            }
         
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _ui.UseLiftUIOn();
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _ui.UseLiftUIOff();
            other.transform.parent = null;
        }
    }
}
