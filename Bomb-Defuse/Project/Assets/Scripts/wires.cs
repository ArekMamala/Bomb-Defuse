using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class wires : MonoBehaviour {

    public GameObject wires3, wires4, wires5, wires6;

    public GameObject[] wiresArr;

    int whichWires = 0;
    // wiresArr[yellow, green, white, blue, red];
    //public int randomNumber;
    [SerializeField]
    Text numberText;

    void Start () {
        var panel = GameObject.Find ("wires");

        Array.Resize (ref wiresArr, wiresArr.Length + 1);
        wiresArr[wiresArr.Length - 1] = wires3;

        Array.Resize (ref wiresArr, wiresArr.Length + 1);
        wiresArr[wiresArr.Length - 1] = wires4;

        Array.Resize (ref wiresArr, wiresArr.Length + 1);
        wiresArr[wiresArr.Length - 1] = wires5;

        Array.Resize (ref wiresArr, wiresArr.Length + 1);
        wiresArr[wiresArr.Length - 1] = wires6;

        Vector3 pos = transform.position;
        pos.x = 190;
        pos.y = 270;
        whichWires = Random.Range (1, 5);
        Debug.Log (whichWires);
        int randomNumber;
        randomNumber = whichWires;

        switch (whichWires) {
            case 1:
                GameObject threeWires = Instantiate<GameObject> (wires3);
                threeWires.transform.SetParent (panel.transform);
                threeWires.transform.position = pos;
                break;
            case 2:
                //Instantiate (green);
                GameObject fourWires = Instantiate<GameObject> (wires4);
                fourWires.transform.SetParent (panel.transform);
                fourWires.transform.position = pos;

                break;
            case 3:
                GameObject fiveWires = Instantiate<GameObject> (wires5);
                fiveWires.transform.SetParent (panel.transform);
                //Instantiate (white);
                fiveWires.transform.position = pos;

                break;
            case 4:
                GameObject sixWires = Instantiate<GameObject> (wires6);
                sixWires.transform.SetParent (panel.transform);
                //Instantiate (blue);
                sixWires.transform.position = pos;

                break;
        }

        numberText.text = ("" + $"{whichWires}");
    }

}