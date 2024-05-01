using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private GameObject Managers;

    public GameObject player { get; private set; }
    public GameObject playerCamera { get; private set; }
    public Vector3 spawnPoint = new Vector3(-90f, 5f, -7.5f);
    public Vector3 spawnRotation = new Vector3(0f, 50f, 0f);

    [Header("Scene Transition")]
    [SerializeField] Animator transition;

    [Header("UI")]
    [SerializeField] GameObject UICanvas;
    [SerializeField] GameObject EventSystem;
    public GameObject inventory;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Cheat;
    [SerializeField] GameObject Credits;

    private Animator playerAnimator;
    private bool inventoryIsOpen;
    private bool reverseInput = false;
    private bool isPause = false;
    private bool isCheat = false;
    private bool isChangingScene = false;

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;

        if (instance != null)
        {
            Debug.LogWarning("Found more than one Game Manager in the scene");
        }


        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = player.transform.Find("Player Camera").gameObject;
        playerAnimator = player.GetComponent<Animator>();

        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        Managers = gameObject.transform.parent.gameObject;
        DontDestroyOnLoad(Managers);
        DontDestroyOnLoad(UICanvas);
        DontDestroyOnLoad(EventSystem);

        Pause.SetActive(false);
        Cheat.SetActive(false);
        Credits.SetActive(false);

        DOTween.SetTweensCapacity(200, 50);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;  // cursor invisible
        inventoryIsOpen = inventory.activeSelf;

        if (player)
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();

            // player & camera movement 
            // 1. inventory is opening 
            // 2. game is pausing
            // 3. player is cheating
            // 4. player cam is not enabled 
            // 5. dialogue is playing
            if (
                inventoryIsOpen || isPause || isCheat ||
                !playerCamera.GetComponent<Camera>().enabled ||
                DialogueManager.GetInstance().dialogueIsPlaying
            )
            {
                // cursor visible
                Cursor.visible = true;

                // unable to move player and camera
                player.GetComponent<BasicBehaviour>().enabled = false;
                player.GetComponent<MoveBehaviour>().enabled = false;
                playerCamera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = false;

                // lock rigidbody constraints
                RigidbodyConstraints constraints = RigidbodyConstraints.FreezeAll;
                playerRigidbody.constraints = constraints;

                // set player animation as default
                playerAnimator.Play("Idle");
            }
            else if (StatusManager.GetInstance().isShakingCamera)
            {
                playerCamera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = false;
            }
            else
            {
                // able to move player and camera
                player.GetComponent<BasicBehaviour>().enabled = true;
                player.GetComponent<MoveBehaviour>().enabled = true;
                playerCamera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = true;

                // unlock rigidbody constraints
                RigidbodyConstraints constraints = playerRigidbody.constraints;
                constraints &= ~RigidbodyConstraints.FreezePosition;
                playerRigidbody.constraints = constraints;
            }
        }

        if (!isChangingScene)
        {
            // inventory
            if (Input.GetKeyDown(KeyCode.I))
            {
                // open inventory UI
                inventory.SetActive(!inventoryIsOpen);

                // list items in your inventory
                InventoryManager.GetInstance().ListItem();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }

            if (
                (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) &&
                Input.GetKeyDown(KeyCode.M) &&
                !DialogueManager.GetInstance().dialogueIsPlaying
            )
            {
                CheatGame();
            }
        }

        if (reverseInput)
        {
            BasicBehaviour.GetInstance().inputRatio = -1f;
        }
        else
        {
            BasicBehaviour.GetInstance().inputRatio = 1f;
        }

        if (
            (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) &&
            Input.GetKeyDown(KeyCode.R)
        )
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            print("find you!!!");
        }
    }

    public void PauseGame()
    {
        isPause = !isPause;
        Pause.gameObject.SetActive(isPause);

        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void CheatGame()
    {
        isCheat = !isCheat;
        Cheat.gameObject.SetActive(isCheat);

        if (isCheat)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void Respawn()
    {
        Transform playerTransform = player.gameObject.transform;
        playerTransform.rotation = Quaternion.Euler(spawnRotation);
        playerTransform.position = spawnPoint;
    }

    public void ChangeScene(string sceneName)
    {
        isChangingScene = true;
        Time.timeScale = 1;
        StopAllCoroutines();

        if (sceneName == "Credits")
        {
            StartCoroutine(ShowCredits());
            return;
        }

        if (sceneName == "Start")
        {
            ToStartScene();
            return;
        }

        StartCoroutine(SceneTransition(sceneName));
    }

    IEnumerator ShowCredits()
    {
        transition.SetTrigger("BlackScreen");

        Credits.SetActive(true);

        yield return new WaitForSeconds(8f);

        ToStartScene();
    }

    public void ToStartScene()
    {
        SceneManager.LoadScene("Start");

        Time.timeScale = 0;
        Cursor.visible = true;
        Destroy(UICanvas);
        Destroy(EventSystem);
        Destroy(Managers);
        playerCamera.SetActive(false);
        Time.timeScale = 1;

        isChangingScene = false;
    }

    private IEnumerator SceneTransition(string sceneName)
    {
        // play animation
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneName);

        Time.timeScale = 0;
        yield return new WaitForSeconds(0f);
        ResetPlayer(sceneName);
        Time.timeScale = 1;

        yield return new WaitForSeconds(0f);
        transition.SetTrigger("End");
        isChangingScene = false;
    }

    private void ResetPlayer(string sceneName)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerAnimator = player.GetComponent<Animator>();

        switch (sceneName)
        {
            case "CreateSystem":
                break;
            case "City":
                spawnPoint = new Vector3(-90f, 5f, -7.5f);
                spawnRotation = new Vector3(0f, 50f, 0f);
                break;
            case "Factory":
                spawnPoint = new Vector3(5.3f, -0.7f, 0.55f);
                spawnRotation = new Vector3(0f, -86f, 0f);
                break;
            case "Pray":
                spawnPoint = new Vector3(-4f, 0f, 2f);
                spawnRotation = new Vector3(0f, 0f, 0f);
                break;
            case "Church":
                spawnPoint = new Vector3(-6f, 0.25f, -0.5f);
                spawnRotation = new Vector3(0f, 0f, 0f);
                break;
            case "Home":
                spawnPoint = new Vector3(7f, 0.475f, 12.5f);
                spawnRotation = new Vector3(0f, -90f, 0f);
                break;
            default:
                spawnPoint = new Vector3(0f, 0f, 0f);
                spawnRotation = new Vector3(0f, 0f, 0f);
                break;
        }

        isCheat = false;
        Cheat.gameObject.SetActive(isCheat);
    }

    public void BlurScreen(bool blurScreen)
    {
        PostProcessVolume ppVolume = playerCamera.gameObject.GetComponent<PostProcessVolume>();
        ppVolume.enabled = blurScreen;
    }

    public void ShakeCamera(float duration)
    {
        playerCamera.GetComponent<Camera>().DOShakePosition(duration, new Vector3(0.5f, 0, 0.5f));
    }

    public void SetReverseInput(bool value)
    {
        reverseInput = value;
    }

    // Act 2 - Pray
    // Act 2 - Church
    public void DeleteStone()
    {
        GameObject stone = GameObject.FindGameObjectWithTag("Stone");
        stone.SetActive(false);
    }

    // Act 2 - Church
    public void ShowParticleThenRene()
    {
        StartCoroutine(ShowParticle());
    }

    public IEnumerator ShowParticle()
    {
        GameObject particle = GameObject.FindGameObjectWithTag("Particle").transform.Find("Particle").gameObject;
        particle.SetActive(true);

        yield return new WaitForSeconds(4f);

        ShowRene();
    }

    public void ShowRene()
    {
        GameObject Rene = GameObject.FindGameObjectWithTag("Rene").transform.Find("Body").gameObject;
        Rene.SetActive(true);
    }

    public void ShowPlayer()
    {
        foreach (Transform child in player.transform)
        {
            if (child.tag == "MainCamera")
            {
                continue;
            }

            child.gameObject.SetActive(true);
        }
    }

    public void HidePlayer()
    {
        foreach (Transform child in player.transform)
        {
            if (child.tag == "MainCamera")
            {
                continue;
            }

            child.gameObject.SetActive(false);
        }
    }
}
