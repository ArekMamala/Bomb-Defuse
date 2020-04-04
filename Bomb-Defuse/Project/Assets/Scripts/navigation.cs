using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class navigation : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenuUI;

     //speech recognitiojn
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public static bool paused = false;
    public  bool escape = false;

    public  string scene="";

    void Start () {

        //voice recognition
        actions.Add("play", play);
        actions.Add("quit", QuitGame);
        actions.Add("menu", instructions);
        actions.Add("stop", manual);        
        actions.Add("home", home);
        
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        Debug.Log(actions);


    }

    void Update(){
        //pauseGame();
    }
    
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
			Debug.Log(speech.text);
			actions[speech.text].Invoke();

    }

    void play(){
        this.scene = "Bomb";
        SceneManager.LoadScene("Bomb");
    }
    
    void home(){
        this.scene = "HomeMenu";
        SceneManager.LoadScene("HomeMenu");
    }

    void instructions(){
        this.scene = "Instructions";
        SceneManager.LoadScene("Instructions");
    }
    void manual(){
        this.escape = true;
        pauseGame();
    }
   


    public void sceneChange(string level){
        SceneManager.LoadScene(level);
        
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void pauseGame(){
        if(Input.GetKeyDown(KeyCode.Escape) || (this.escape = true))
        {
            if(paused)
            {
                Resume();
            }else{
                Pause();
            }
            this.escape=false;
        }
    }

    void Resume(){
        pauseMenuUI.SetActive(false);
        paused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        paused = true;
    }
    
}
