using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DialogueTrigger : MonoBehaviour
{
    private GameObject player;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Params")]
    public bool lookAtPlayer = false;
    [SerializeField] private bool autoTrigger = false;
    [SerializeField] private bool alwaysAutoTrigger = false;

    [Header("Camera Movement")]
    public bool needSwitchCamera = false;
    public bool justZoomInCamera = false;
    public bool zoomInAndMove = true;

    [Header("trigger objects after dialogue")]
    public GameObject[] targetGameObjects;

    [Header("Get / Remove Items by NPC")]
    public Item[] pickUpItem;
    public Item[] removeItem;

    private bool playerInRange;
    private bool autoTriggerIsFinished;

    private Transform gameObjectTransform;

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObjectTransform = gameObject.transform;

        // can not interact with theses objects before conditions are met
        if (targetGameObjects.Length != 0)
        {
            foreach (GameObject targetGameObject in targetGameObjects)
            {
                GameObject trigger = targetGameObject.transform.Find("Trigger").gameObject;
                trigger.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // avoid to trigger dialogue again until the current dialogue is finished
        // make sure not to trigger dialogue twice, when waiting for scene-changing
        if (
            playerInRange &&
            !DialogueManager.GetInstance().dialogueIsPlaying &&
            !GameManager.GetInstance().isChangingScene
        )
        {
            player = GameManager.GetInstance().player;

            // auto trigger once
            if (autoTrigger && !autoTriggerIsFinished)
            {
                EnterDialogue();
                autoTriggerIsFinished = true;
            }
            // keep auto trigger
            else if (alwaysAutoTrigger)
            {
                EnterDialogue();
            }
            else
            {
                visualCue.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) && !CameraManager.GetInstance().isChangingCamera)
                {
                    EnterDialogue();
                }
            }

        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void EnterDialogue()
    {
        if (lookAtPlayer)
        {
            // player position;
            float x = player.transform.position.x;
            float y = gameObject.transform.position.y;
            float z = player.transform.position.z;

            // self position
            float selfX = gameObject.transform.position.x;
            float selfY = player.transform.position.y;
            float selfZ = gameObject.transform.position.z;

            // toward player
            gameObject.transform.parent.DODynamicLookAt(new Vector3(x, y, z), 0.5f);
            player.transform.DODynamicLookAt(new Vector3(selfX, selfY, selfZ), 0.5f);
        }

        CameraManager.GetInstance().SwitchCamera(gameObject);

        // connect to DialogueManager
        // record which game object trigger dialogue 
        DialogueManager.GetInstance().SetTriggerGameObject(gameObject, gameObjectTransform);
        // start dialogue 
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
