using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            
            UIManager _ui = FindObjectOfType<UIManager>();
            if (!player._nearLadder)
                _ui.LadderOn();
            if (Input.GetKeyDown(KeyCode.F))
            {

                player._nearLadder = true;
                _ui.LadderOff();
                _ui.MoveLadderOn();

            }



        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            UIManager _ui = FindObjectOfType<UIManager>();
            if (player._nearLadder)
            {
                
                player._nearLadder = false;
                player.UpPosition = true;
                player.ladder = this;
                _ui.MoveLadderOff();
            }
            

        }
    }

}
