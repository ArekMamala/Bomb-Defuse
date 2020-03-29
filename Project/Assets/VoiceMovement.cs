using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{
  private keywordRecognizer keywordRecognizer;
  private Dicitonary<string, Action> actions = new Dicitonary<string, Action>();

  void Start(){
      actions.Add("Start", Start);
      actions.Add("Quit", Quit);
      actions.Add("Setting", Setting);
      actions.Add("Start Game", Manual);
  }

}
