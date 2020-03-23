using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class navigation : MonoBehaviour
{
    public void sceneChange(string level){
        SceneManager.LoadScene(level);
        
    }

    
}
