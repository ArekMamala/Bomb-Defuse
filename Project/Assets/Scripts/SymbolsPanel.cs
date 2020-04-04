using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace code {
	public class SymbolsPanel : MonoBehaviour {

		[SerializeField]
		Text codeText;

		[SerializeField]
		Text numberText;
		string codeTextValue = "";
		string numberTextValue = "";

		public string[] code = { "" };
		public string result = "";


		//symbols for the game 
		//1= 诶 2= 比 3= 西 4= 迪 5= 伊 6= 艾 7= 吉 8= 艾 9= 尺 
		//10= 杰 11= 开 12= 勒 13= 马 14= 娜 15= 哦 16= 屁 17= 丝 
		//18= 儿 19= 伊 20 = 吾 21= 提 22= 吉 23= 吾 24= 豆 25= 贝 26= 尔 27= 维

		//array for the symbols
		string[] symbols = { "诶", "比", "比", "西", "迪","伊",  "艾", "吉", "艾", "杰", "尺", "开", "勒", "马", "娜", "哦", "屁", "丝", "伊", "儿", "吾", "提", "吾", "豆",  "贝", "尔", "维" };
		string[] symbolWorth =  { "1",  "2",  "3", "4",  "5", "6",  "7",  "8",  "9",  "1",  "2", "3",  "4",  "5", "6",  "7",  "8", "9",  "1",  "2",  "3", "4",  "5",  "6",  "7",  "8",  "9" };
		// Start is called before the first frame update
		void Start () {

			result = "";
			System.Random rand = new System.Random ();
			int indexOne = rand.Next (symbols.Length);
			string val1 = symbolWorth[indexOne];
			int indexTwo = rand.Next (symbols.Length);
			string val2 = symbolWorth[indexTwo];
			int indexThree = rand.Next (symbols.Length);
			string val3 = symbolWorth[indexThree];
			int indexFour = rand.Next (symbols.Length);
			string val4 = symbolWorth[indexFour];

			// Adding elements to the array for the code to be the same as the random buttons 
			Array.Resize (ref code, code.Length + 1);
			code[code.Length - 1] = val1;
			Array.Resize (ref code, code.Length + 1);
			code[code.Length - 1] = val2;
			Array.Resize (ref code, code.Length + 1);
			code[code.Length - 1] = val3;
			Array.Resize (ref code, code.Length + 1);
			code[code.Length - 1] = val4;
			//code.add(val1);
			//code.add(val2);		
			//code.add(val3);		
			//code.add(val4);
			result = string.Concat (code);
			numberTextValue = ($"{result}");
			val1 = "";
			val2 = "";
			val3 = "";
			val4 = "";
			//System.Console.WriteLine($"Randomly selected author is {symbols[index]}");
			codeTextValue = ($"{symbols[indexOne]}" + $"{symbols[indexTwo]}" + $"{symbols[indexThree]}" + $"{symbols[indexFour]}");
			Debug.Log ("This is the code" + symbols[indexOne]);
			codeText.text = codeTextValue;

			numberText.text = ("" + $"{result}");
			result = "";
		}
	}
}