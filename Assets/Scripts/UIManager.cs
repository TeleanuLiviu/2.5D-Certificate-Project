using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public Text Score;
    public GameObject Hint;
   
    void Start()
    {
        Score = GameObject.Find("Canvas/Score").GetComponent<Text>();
        Hint = GameObject.Find("Canvas/Hint");
        

    }

    public void UpdateText(long score)
    {
        Score.text = score.ToString();
    }

    public void GrabLedgeUIOn()
    {
        Hint.SetActive(true);
        Hint.GetComponent<Text>().text = "Press 'E' to grab yourself UP";
    }

    public void GrabLedgeUIOff()
    {
        Hint.SetActive(false);
       
    }

    public void UseLiftUIOn()
    {
        Hint.SetActive(true);
        Hint.GetComponent<Text>().text = "Press 'R' and stand still to use elevator";
    }

    public void UseLiftUIOff()
    {
        Hint.SetActive(false);

    }

    public void LadderOn()
    {
        Hint.SetActive(true);
        Hint.GetComponent<Text>().text = "Press 'F' to grab the Ladder";
    }

    public void LadderOff()
    {
        Hint.SetActive(false);
    }

    public void MoveLadderOn()
    {
        Hint.SetActive(true);
        Hint.GetComponent<Text>().text = "Press The Arrows Up/Down to move on the Ladder";
    }

    public void MoveLadderOff()
    {
        Hint.SetActive(false);
      
    }

    public void FinishCoinsOn()
    {
        Hint.SetActive(true);
        Hint.GetComponent<Text>().text = "You need at least 15 coins to proceed";
    }

    public void FinishCoinsOff()
    {
        Hint.SetActive(false);
    }

    public void FinishRestartOn()
    {
        Hint.SetActive(true);
        Hint.GetComponent<Text>().text = "Press 'T' to start again";
    }

    public void FinishRestartOff()
    {
        Hint.SetActive(false);
    }


}
