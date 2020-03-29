using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{
  private keywordRecognizer keywordRecognizer;
  private Dicitonary<string, Action> actions = new Dicitonary<string, Action>();

  void Start(){
    actions.Add("Start", StartGame);
    actions.Add("Quit", Quit);
    actions.Add("Setting", Setting);
    actions.Add("Manual", Manual);

    keywordRecognizer = new keywordRecognizer(actions.Keys.ToArray());
    keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
  }

  private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
    Debug.Log(speech.text);
    actions[speech.text].Invoke();
  }
  
  private void StartGame(){
    // Code to here on windows 
  }

  private void Quit(){
    // Code to here on windows 
  }
  private void Setting(){
    // Code to here on windows 
  }
  private void Manual(){
    // Code to here on windows 
  }

}
