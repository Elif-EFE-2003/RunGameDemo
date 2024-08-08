using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialinfo : MonoBehaviour
{
    // Start is called before the first frame update
    public Text infoText;
    public string[] infoData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
            string objectName= gameObject.name;
            int index;
            int.TryParse(objectName,out index);
            infoText.text=infoData[index];
            print(index);
        }
    }
}
