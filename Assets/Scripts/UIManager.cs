using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //public GameObject mainMenu,gamePanel,gameMenu,settingsMenu,volumeMenu,sceneSelect;
    gameManager gameManager_sc;
    //public static GameObject manager;
    public GameObject videoPlayer;
    public Text hpText,scoreText,timeText;
    public Slider volumeSlider;
    public GameObject[] paneller;
    public Button previous;

    void Start()
    {
      //mainMenu.SetActive(true);gamePanel.SetActive(false);gameMenu.SetActive(false);settingsMenu.SetActive(false);volumeMenu.SetActive(false);sceneSelect.SetActive(false);
      gameManager_sc=FindObjectOfType<gameManager>();
      openPanel("MainMenu");
      volumeSlider.value=.01f;
      if(manager.Manager==null){
       
          manager.Manager=gameObject;
      }
      else{
        // managers=GameObject.FindGameObjectsWithTag("manager");
        Destroy(gameObject);
      }
      
      DontDestroyOnLoad(gameObject);
      //DontDestroyOnLoad(Canvas);
      InvokeRepeating("textUpdate",1,0.1f);
      
      
    }
    public  void textUpdate(){
        
        hpText.text=((int)(gameManager_sc.hpScene)).ToString();
        scoreText.text=gameManager_sc.scoreScene.ToString();
        timeText.text=((int)(gameManager_sc.timeScene-Time.time)).ToString();


    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseGame();
        }
      
    }
    public void ButtonNewGame(){
        openPanel("GamePanel");
        videoPlayer.SetActive(false);
        SceneManager.LoadScene("Tutorial");
        gameManager_sc.currentScene++;
        gameManager_sc.hpScene=gameManager_sc.hpMain;
        gameManager_sc.scoreScene=gameManager_sc.scoreMain;
        gameManager_sc.timeScene=gameManager_sc.timeMain;
    }
    public void pauseGame(){
      Time.timeScale=0;//oyun akışı durur
      openPanel("GameMenu ");
    }
    public void ButtonContinue(){
        Time.timeScale=1;
        openPanel("GamePanel");
    }
    public void ButtonExit(){
        Application.Quit();
    }
    public void ButtonRestart(){
        SceneManager.LoadScene(gameManager_sc.currentScene); //SceneManager.LoadScene("Tutorial");
        }
    public void ButtonSetings(){
        openPanel("SettingMenu");
    }
    public void ButtonMainMenu(){
        //oyun akışı dursun ve sıfırla
        SceneManager.LoadScene(0);
        openPanel("MainMenu");
        Time.timeScale=1;


    }
    public void PanelEndScene(){
        openPanel("EndPanel");
        if(gameManager_sc.currentScene==1){
            previous.interactable=false;

        }else{
            previous.interactable=true;
        }
        
        Time.timeScale=0;

    }
    public void ButtonSceneChange(int changeSceneTo){
        openPanel("GamePanel");
       SceneManager.LoadScene(gameManager_sc.currentScene+changeSceneTo);
       gameManager_sc.currentScene+=changeSceneTo;
       Time.timeScale=1;
       //gameManager_sc.scoreMain=gameManager_sc.scoreScene;
    }
    public void openPanel(string panelName){
        for(int i=0;i<paneller.Length;i++){
            if(paneller[i].name==panelName){
                paneller[i].SetActive(true);
            }else{
                paneller[i].SetActive(false);
            }
        }
    }
    public void volumeChange(){
        videoPlayer.GetComponent<AudioSource>().volume=volumeSlider.GetComponent<Slider>().value;
    }


}

public static class manager{
    public static GameObject Manager;
}