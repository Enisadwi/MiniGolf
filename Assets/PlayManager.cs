using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
   [SerializeField] BallControler ballControler;
   [SerializeField] CameraController camController;
   bool isBallOutSide;
   bool isBallTeleporting;
   Vector3 lastBallPosition;

   public void Update(){
      if (ballControler.ShootingMode)
      {
         lastBallPosition = ballControler.transform.position;
      }

    var inputActive = Input.GetMouseButton(0) 
    && ballControler.IsMove() == false
    && ballControler.ShootingMode == false
    && isBallOutSide == false;

    camController.SetInputActive(inputActive);
   }
   public void OnBallOutSide()
   {
      if(isBallTeleporting == false)
      Invoke("TeleportBallLastPosition", 3);

      ballControler.enabled = false;
      isBallOutSide = true;
      isBallTeleporting = true;
    

   }
   public void TeleportBallLastPosition()
   {
      TeleportBall(lastBallPosition);
   }

   public void TeleportBall(Vector3 targetPosition)
   {
      var rb = ballControler.GetComponent<Rigidbody>();
      rb.isKinematic = true;
      ballControler.transform.position = lastBallPosition;
      rb.isKinematic = false;

      ballControler.enabled = true;
      isBallOutSide = false;
      isBallTeleporting = false;
   }
}
