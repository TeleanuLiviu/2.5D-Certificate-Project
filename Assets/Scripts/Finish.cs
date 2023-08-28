using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UIManager _ui = FindObjectOfType<UIManager>();
            Player player = other.GetComponent<Player>();
            if(player.GetGold()>=15)
            {
                SkinnedMeshRenderer renderer =  other.GetComponentInChildren<SkinnedMeshRenderer>();
                CharacterController controller = other.GetComponent<CharacterController>();
                renderer.enabled = false;
                controller.enabled = false;
                _ui.FinishRestartOn();
                this.gameObject.transform.parent.GetComponent<Animator>().enabled = true;
            }
            else
            {
               
                _ui.FinishCoinsOn();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIManager _ui = FindObjectOfType<UIManager>();
            _ui.FinishCoinsOff();
        }

    }
}
