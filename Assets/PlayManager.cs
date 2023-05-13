using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
   [SerializeField] BallControler ballControler;
   [SerializeField] CameraController camController;


   public void Update(){
    var inputActive = Input.GetMouseButton(0) && ballControler.IsMove() == false;
    camController.SetInputActive(inputActive);
   }
}
