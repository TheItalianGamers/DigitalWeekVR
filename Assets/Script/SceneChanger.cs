using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void prova(string dio) {
      Debug.Log("porco dio");
      changeScene(dio);
    }
  
    public void changeScene(string sceneName) {
     
      SceneManager.LoadScene(sceneName);

    }


}
