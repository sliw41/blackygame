using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlescreen : MonoBehaviour
    
{
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void start(){
       
        SceneManager.LoadScene("game");
        }
    public void start2(){
        SceneManager.LoadScene("level2");
        }
    
    
    public void quit(){
        Application.Quit();
    }
    public void back(){
        SceneManager.LoadScene("MainTitle");
}
}
