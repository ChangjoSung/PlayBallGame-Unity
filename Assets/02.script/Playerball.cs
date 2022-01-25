using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Playerball : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    bool isJump; //점프 true or false
    public GameManagerLogic Manager; //Manager 에다 스크립트 추가
    Rigidbody rigid;
    AudioSource audio;
    void Awake() 
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>(); 

        Screen.SetResolution(1280,720,false);
    }
    
    void Update() 
    {
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
        }    
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(h,0,v);

        rigid.AddForce(vec,ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag =="Cube")
        {
            isJump = false;
        }    
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Item")
        {
            itemCount++;
            audio.Play(); // 오디오 재생
            other.gameObject.SetActive(false);
            
            Manager.Getitem(itemCount);
        }    
        else if (other.tag =="Point")
        {
            if(itemCount == Manager.finalitemCount)
            {
                //게임 클리어
                if(Manager.stage == 2)
                {
                    SceneManager.LoadScene(Manager.stage + 1);
                }
                else
                {
                    SceneManager.LoadScene(Manager.stage + 1);
                }    
            }
            else {
                //restart
                SceneManager.LoadScene(Manager.stage);
            }
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        
    }
}
