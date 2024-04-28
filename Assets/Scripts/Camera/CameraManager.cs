using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;

    [Header("Player Camera")]
    private Camera playerCam;

    public bool isChangingCamera { get; private set; } = false;
    private GameObject otherCam;
    private bool needSwitchCamera;
    private bool justZoomInCamera;
    private bool zoomInAndMove;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Camera Manager in the scene");
        }

        instance = this;
    }

    public static CameraManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // public void SwitchCamera(CinemachineVirtualCamera selfVirtualCam)
    public void SwitchCamera(GameObject triggerGameObject)
    {
        isChangingCamera = true;

        DialogueTrigger dialogueTrigger = triggerGameObject.GetComponent<DialogueTrigger>();
        needSwitchCamera = dialogueTrigger.needSwitchCamera;
        justZoomInCamera = dialogueTrigger.justZoomInCamera;
        zoomInAndMove = dialogueTrigger.zoomInAndMove;

        playerCam = GameManager.GetInstance().playerCamera.GetComponent<Camera>();

        if (needSwitchCamera)
        {
            otherCam = triggerGameObject.transform.parent.Find("Camera").gameObject;
            otherCam.SetActive(true);
        }
        else if (justZoomInCamera)
        {
            playerCam.DOFieldOfView(40f, 1f);
        }
        else if (zoomInAndMove)
        {
            float selfY = playerCam.transform.position.y;

            float otherX = triggerGameObject.transform.parent.Find("Visual").transform.position.x;
            float otherY = triggerGameObject.transform.parent.Find("Visual").transform.position.y;
            float otherZ = triggerGameObject.transform.parent.Find("Visual").transform.position.z;

            playerCam.transform.DOLocalMoveY(selfY + 6f, 1f);
            playerCam.transform.DODynamicLookAt(new Vector3(otherX, otherY, otherZ), 1f);
            playerCam.DOFieldOfView(40f, 1f);
        }

        isChangingCamera = false;
    }

    public void ResetCamera()
    {
        isChangingCamera = true;

        playerCam = GameManager.GetInstance().playerCamera.GetComponent<Camera>();

        if (needSwitchCamera)
        {
            otherCam.SetActive(false);
        }
        else if (justZoomInCamera)
        {
            playerCam.DOFieldOfView(60f, 1f);
        }
        else if (zoomInAndMove)
        {
            playerCam.DOFieldOfView(60f, 0.5f);
        }

        isChangingCamera = false;
    }
}