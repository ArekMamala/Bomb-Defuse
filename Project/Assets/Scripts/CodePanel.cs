using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace code {

	public class CodePanel : MonoBehaviour {

		SymbolsPanel code = new SymbolsPanel ();

		[SerializeField]
		Text codeText;
		[SerializeField]
		Text symbCode;

		string codeTextValue = "";

		string str = "";

		void Start () {

			Debug.Log ("This is it " + symbCode.text);

		}

		void Update () {
			codeText.text = codeTextValue;

			if (codeTextValue == symbCode.text) {
				//Cat.isSafeOpened = true;
				codeTextValue = "";
			}

			if (codeTextValue.Length > 4)
				codeTextValue = "";
		}

		public void AddDigit (string digit) {
			codeTextValue += digit;
		}

	}
}