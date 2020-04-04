using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class cuttingWires : MonoBehaviour
{
    //speech recognitiojn
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    wires wire = new wires(); 
    
    [SerializeField]
    GameObject openCode, closeCode;
    public static bool isCodeAvailable = false;
    
    [SerializeField]
    Text number;

    [SerializeField]
    Text countdownText;

    float currentTime = 500f;
    float startingTime = 500f; 

    string randomNumber = "";

    // voice recognition variables
    public bool redCut = false;
    public bool blueCut = false;
    public bool whiteCut = false;
    public bool yellowCut = false;
    public bool greenCut = false;
    public bool blue = false;

    public ConfidenceLevel confidence = ConfidenceLevel.Low;

    void Start(){
         //voice recognition
        actions.Add("Red Wire", Red);
        actions.Add("White Wire", White);
        actions.Add("Blue Wire", Blue);
        actions.Add("yellow Wire", Yellow);
        actions.Add("green Wire", Green);
        
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), confidence);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

        closeCode.SetActive (true);
        openCode.SetActive (false);

        currentTime = startingTime;
    }

    void Update(){

        //debugging code
        if(randomNumber == ""){
            randomNumber = number.text;

            Debug.Log (randomNumber+ "this is the text");
        }

        cutWire();
        //timer code decreases by one
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("00:00");

        //if the timer gets to 0 you lose
        if(currentTime <=0 ){
            currentTime = 0;
            SceneManager.LoadScene("lose");
        }

        //changes colour to cred when its less than 10 seconds
        if (currentTime<=10){
           countdownText.color = Color.red;
        }
   
    }
   
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
			Debug.Log(speech.text);
			actions[speech.text].Invoke();

    }

    // voice recognition methods
    void Red(){
        this.redCut = true;
        Debug.Log ("red wire is cut");
    }
    void White(){
        this.whiteCut = true;
        Debug.Log ("white wire is cut");
    }
    void Blue(){
        this.blueCut = true;
        Debug.Log ("blue wire is cut");
    }
    void Yellow(){
        this.yellowCut = true;
        Debug.Log ("yellow wire is cut");
    }
    void Green(){
        this.greenCut = true;
        Debug.Log ("green wire is cut");
    }
    
    //cutting wire function 
    public void cutWire(){
        // Text txt = transform.Find("Text").GetComponent<Text>();
        // txt.text = text + number;   
        //case statment on which wires get loaded in
        switch (randomNumber) {
            case "1":
                // three wires 
                // blue wire (last wire) to unlock 

                //if the user says blue wire or presses the "b" button 
                //therefore fail
                if(Input.GetKeyDown(KeyCode.B) || (this.blueCut == true )){
                    //unlock the code
                    isCodeAvailable = true;
                    closeCode.SetActive (false);
                    openCode.SetActive (true); 
                    //Debug.Log ("working correctly");
                }  
                //if the user says any other wire or presses other button 
                //therefore fail
                else if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.G))
                {
                    // speed the timer
                    Debug.Log ("timer speed up");
                    this.currentTime -= 250;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);
                }else if ((this.whiteCut == true )||(this.yellowCut == true )||(this.redCut == true )||(this.greenCut == true )){
                    // speed the timer
                    Debug.Log ("timer speed up");
                    this.currentTime -= 250;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);  
                }
                this.redCut = false;
                this.blueCut = false;
                this.whiteCut = false;
                this.yellowCut = false;
                this.greenCut = false;
                
                break;
            case "2":
                //four wires 
                //cut the first wire (white wire)
                
                 //if the user says white wire or presses the "w" button 
                //therefore fail
                if(Input.GetKeyDown(KeyCode.W) || (this.whiteCut == true)){
                    //unlock the code
                    isCodeAvailable = true;
                    closeCode.SetActive (false);
                    openCode.SetActive (true); 
                    //Debug.Log ("working correctly");
                }  
                //if the user says any other wire or presses other button 
                //therefore fail
                else if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.G))
                {
                    // speed the timer
                    this.currentTime -= 250;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);

                }else if((this.blueCut == true) ||(this.yellowCut == true) ||(this.redCut == true) ||(this.greenCut == true) ){
                    // speed the timer
                    this.currentTime -= 250;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);                }

                this.redCut = false;
                this.blueCut = false;
                this.whiteCut = false;
                this.yellowCut = false;
                this.greenCut = false;
                break;
            case "3":
                //five wires 
                // cut the second wire (red wire)

                 //if the user says red wire or presses the "r" button 
                //therefore fail
                if(Input.GetKeyDown(KeyCode.R) || (this.redCut == true)){
                    //unlock the code
                    isCodeAvailable = true;
                    closeCode.SetActive (false);
                    openCode.SetActive (true); 
                    //Debug.Log ("working correctly");
                }  
                //if the user says any other wire or presses other button 
                //therefore fail
                else if(Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.G))
                {
                    // speed the timer
                    this.currentTime -= 250 ;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);
                }else if((this.blueCut == true) ||(this.yellowCut == true) ||(this.whiteCut == true) ||(this.greenCut == true) ){
                    // speed the timer
                    this.currentTime -= 250;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);
                }
                this.redCut = false;
                this.blueCut = false;
                this.whiteCut = false;
                this.yellowCut = false;
                this.greenCut = false;
                break;
            case "4":
                // six wires 
                // cut the fourth wire (blue wire)

                 //if the user says blue wire or presses the "b" button 
                //therefore fail
                if(Input.GetKeyDown(KeyCode.B) || (this.blueCut == true) ){
                    //unlock the code
                    isCodeAvailable = true;
                    closeCode.SetActive (false);
                    openCode.SetActive (true); 
                    //Debug.Log ("working correctly");
                }  
                //if the user says any other wire or presses other button 
                //therefore fail
                else if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.G))
                {
                    // speed the timer
                    this.currentTime -= 250;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);

                }else if ((this.whiteCut == true) ||(this.yellowCut == true) ||(this.redCut == true) ||(this.greenCut == true) ){
                    // speed the timer
                    Debug.Log ("timer speed up");
                    this.currentTime -= 250;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);  
                }

                this.redCut = false;
                this.blueCut = false;
                this.whiteCut = false;
                this.yellowCut = false;
                this.greenCut = false;
                break;
        }
    
    }

}
//voice recognition done