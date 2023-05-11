using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BallControler : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook look;

    private void Update(){
        look.enabled = Input.GetMouseButton(0);
    }

 
}

