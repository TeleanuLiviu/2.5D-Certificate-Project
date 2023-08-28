using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Death : MonoBehaviour
{
    public GameObject YouDied;
    public void Start()
    {
        YouDied = GameObject.Find("Canvas/Death");
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UIManager _ui = FindObjectOfType<UIManager>();
            _ui.FinishRestartOn();
            SkinnedMeshRenderer renderer = other.GetComponentInChildren<SkinnedMeshRenderer>();
            CharacterController controller = other.GetComponent<CharacterController>();
            renderer.enabled = false;
            controller.enabled = false;
            YouDied.GetComponent<Text>().text = "You Died";
        }
    }
}
