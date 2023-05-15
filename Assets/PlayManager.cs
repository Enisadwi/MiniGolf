 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
   [SerializeField] BallControler ballControler;
   [SerializeField] CameraController camController;
   [SerializeField] GameObject finishWindow;
   [SerializeField] TMP_Text finishText;
   [SerializeField] TMP_Text shootCountText;

   bool isBallOutSide;
   bool isGoal;
   bool isBallTeleporting;
 
   Vector3 lastBallPosition;

   private void OnEnable(){
      ballControler.onBallShooted.AddListener(UpdateShootCount);
   }
   private void OnDisable(){
      ballControler.onBallShooted.RemoveListener(UpdateShootCount);
   }

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
   public void OnBallGoalEnter()
   {
      isGoal=true;
      ballControler.enabled = false;
      // TODO PLAYER WIN WINDOW POPUP
   
      finishWindow.gameObject.SetActive(true);
      finishText.text ="Finished!! \n" + "Shoot Count: "+ ballControler.ShootCount;
   }
      public void OnBallOutSide()
   {
      if (isGoal)
      return;

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
   public void UpdateShootCount(int shootCount)
   {
      shootCountText.text = shootCount.ToString();
   }
}