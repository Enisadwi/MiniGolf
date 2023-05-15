using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
   public void LEVEL1()
    {
        SceneManager.LoadScene("Level 1");
    }
     public void LEVEL2()
    {
        SceneManager.LoadScene("Level 2");
    }

}
