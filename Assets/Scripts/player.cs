using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody rb;
    gameManager gameManager_sc;
    UIManager UIManager_sc;
    public float moveSpeed,jumpForce;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        gameManager_sc=FindObjectOfType<gameManager>();
        UIManager_sc=FindObjectOfType<UIManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir=new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        transform.Translate(moveDir*moveSpeed*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space)){
           rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Finish"){
            UIManager_sc.PanelEndScene();
        }
        if(other.gameObject.tag=="coin"){
            Destroy(other.gameObject);
           gameManager_sc.scoreScene+=5;
        }

    }
    private void OnTriggerStay(Collider other){
        if(other.gameObject.tag=="Lava"){
         gameManager_sc.hpScene-=.05f;
        }


    }
}