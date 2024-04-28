using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using Cinemachine;
using DG.Tweening;

public class CameraTrigger : MonoBehaviour
{
    private GameObject playerCam;

    // [Header("Virtual Camera")]
    // private CinemachineVirtualCamera playerVirtualCam, selfVirtualCam;

    private bool playerInRange;
    private Camera playerCamEnable;

    // Start is called before the first frame update
    void Start()
    {
        // playerCam = GameManager.GetInstance().playerCamera;
        // playerCamEnable = playerCam.GetComponent<Camera>();
        // playerVirtualCam = playerCam.GetComponent<CinemachineVirtualCamera>();
        // selfVirtualCam = gameObject.transform.parent.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        // can interact if close enough, then press E to interact
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerCam = GameManager.GetInstance().playerCamera;
            playerCamEnable = playerCam.GetComponent<Camera>();

            // switch camera
            if (playerCamEnable.enabled && !CameraManager.GetInstance().isChangingCamera)
            {
                // zoom in camera
                // CameraManager.GetInstance().SwitchCamera(selfVirtualCam);
                // CameraManager.GetInstance().SwitchCamera();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;

            // hint UI move down
            HintManager.GetInstance().MoveDown();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;

            // hint UI move up
            HintManager.GetInstance().MoveUp();
        }
    }
}