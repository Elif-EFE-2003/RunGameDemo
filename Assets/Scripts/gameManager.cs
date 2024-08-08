using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int currentScene;
    public string userName;
    public float hpMain,hpScene;
    public int scoreMain,scoreScene;
    public float timeMain,timeScene;
    void Start()
    {
        currentScene=0;
        hpMain=100;
        scoreMain=0;
        timeMain=600;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
