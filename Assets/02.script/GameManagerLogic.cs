using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{

    public int finalitemCount;
    public int stage;
    public Text stageCountText; 
    public Text playerCountText;

    void Awake() 
    {
        stageCountText.text = "/ " + finalitemCount;    
    }

    public void Getitem(int count) 
    {
        playerCountText.text = count.ToString();
    }
     
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }  
}
