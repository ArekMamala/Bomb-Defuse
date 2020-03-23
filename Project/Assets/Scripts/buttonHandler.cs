using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonHandler : MonoBehaviour
{
    wires wire = new wires(); 
    
    [SerializeField]
    GameObject openCode, closeCode;
    public static bool isCodeAvailable = false;
    
    [SerializeField]
    Text number;

    [SerializeField]
    Text countdownText;

    float currentTime = 0f;
    float startingTime = 200f; 

    string randomNumber = "";

    void Start(){

        closeCode.SetActive (true);
        openCode.SetActive (false);

        currentTime = startingTime;
    }

    void Update(){

        if(randomNumber == ""){
            randomNumber = number.text;

            Debug.Log (randomNumber+ "this is the text");
        }

        cutWire();

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("00");

        if(currentTime <=0 ){
            currentTime = 0;
        }

        if (currentTime<=10){
           countdownText.color = Color.red;
        }
        
    
   
    }

    public void cutWire(){
        // Text txt = transform.Find("Text").GetComponent<Text>();
        // txt.text = text + number;   

        switch (randomNumber) {
            case "1":
                // three wires 
                // blue wire (last wire) to unlock 

                //if the user says blue wire or presses the "b" button 
                //therefore fail
                if(Input.GetKeyDown(KeyCode.B)){
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
                    this.currentTime -= 100;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);
                }else{
                    //Debug.Log ("not working correctly");
                }


                break;
            case "2":
                //four wires 
                //cut the first wire (white wire)
                
                 //if the user says white wire or presses the "w" button 
                //therefore fail
                if(Input.GetKeyDown(KeyCode.W)){
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
                    this.currentTime -= 100;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);

                }else{
                    //Debug.Log ("not working correctly");
                }

                Debug.Log (isCodeAvailable);
                break;
            case "3":
                //five wires 
                // cut the second wire (red wire)

                 //if the user says red wire or presses the "r" button 
                //therefore fail
                if(Input.GetKeyDown(KeyCode.R)){
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
                    this.currentTime -= 20 ;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);
                }else{
                    //Debug.Log ("not working correctly");
                }
               // Debug.Log (isCodeAvailable);
                break;
            case "4":
                // six wires 
                // cut the fourth wire (blue wire)

                 //if the user says blue wire or presses the "b" button 
                //therefore fail
                if(Input.GetKeyDown(KeyCode.B)){
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
                    this.currentTime -= 100;
                    countdownText.color = Color.red;
                    Debug.Log ("timer speed up "+ currentTime);

                }else{
                    //Debug.Log ("not working correctly");
                }
                Debug.Log (isCodeAvailable);
                break;
        }
    
    }

}
