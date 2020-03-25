using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace code {

	public class CodePanel : MonoBehaviour {

		SymbolsPanel code = new SymbolsPanel ();

		[SerializeField]
		Text codeText;
		[SerializeField]
		Text symbCode;

		string codeTextValue = "0000";

		string str = "";

		void Start () {

			Debug.Log ("This is it " + symbCode.text);

		}

		void Update () {
			codeText.text = codeTextValue;

			if (codeTextValue == symbCode.text) {
				SceneManager.LoadScene("Win");
			}

			if (codeTextValue.Length >= 4 && (codeTextValue != symbCode.text) && (codeTextValue != "0000" )){
				SceneManager.LoadScene("lose");

			}
		}

		public void AddDigit (string digit) {
			if((codeTextValue == "0000" ))
				codeTextValue ="";
			codeTextValue += digit;
		}

	}
}