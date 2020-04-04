using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;


namespace code {

	public class CodePanel : MonoBehaviour {

		SymbolsPanel code = new SymbolsPanel ();

		 //speech recognitiojn
		private KeywordRecognizer keywordRecognizer;
		private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    	public ConfidenceLevel confidence = ConfidenceLevel.Low;

		[SerializeField]
		Text codeText;
		[SerializeField]
		Text symbCode;

		string codeTextValue = "0000";

		string str = "";

		public string number = "";

		//voice recognition methods for didgits 
		void Start () {

			Debug.Log ("This is it " + symbCode.text);
			//voice recognition
			actions.Add("one", one);
			actions.Add("two", two);
			actions.Add("three", three);
			actions.Add("four", four);
			actions.Add("five", five);
			actions.Add("six", six);
			actions.Add("seven", seven);
			actions.Add("eight", eight);
			actions.Add("nine", nine);
			
			keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), confidence);
			keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
			keywordRecognizer.Start();
		}

		private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
			Debug.Log(speech.text);
			actions[speech.text].Invoke();
		}

		void one(){
			this.number = "1";
			AddDigitVR();
		}
		
		void two(){
			this.number = "2";
			AddDigitVR();
		}
		
		void three(){
			this.number = "3";
			AddDigitVR();
		}
		
		void four(){
			this.number = "4";
			AddDigitVR();
		}
		
		void five(){
			this.number = "5";
			AddDigitVR();
		}
		
		void six(){
			this.number = "6";
			AddDigitVR();
		}
		
		void seven(){
			this.number = "7";
			AddDigitVR();
		}
		
		void eight(){
			this.number = "8";
			AddDigitVR();
		}
		
		void nine(){
			this.number = "9";
			AddDigit(this.number);
		}

		void Update () {
			codeText.text = codeTextValue;
			// if users imput is the same as the hidden in the background code
			//user entered right code take him to win
			if (codeTextValue == symbCode.text) {
				SceneManager.LoadScene("Win");
			}
			// to lose code has to be at least 4
			// annd not equal to answer
			// and also not equal t 0000
			if (codeTextValue.Length >= 4 && (codeTextValue != symbCode.text) && (codeTextValue != "0000" )){
				SceneManager.LoadScene("lose");

			}
		}

		// add digit through speech
		public void AddDigitVR () {
			if((codeTextValue == "0000" ))
				codeTextValue ="";
			codeTextValue += this.number;
		}

		//add digit with mouse
		public void AddDigit (string digit) {
			if((codeTextValue == "0000" ))
				codeTextValue ="";
			codeTextValue += digit;
		}

	}
}