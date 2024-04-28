using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Ink.Runtime;
using DG.Tweening;
using System;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.025f;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    private Animator layoutAnimator;
    [SerializeField] private GameObject continueIcon;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Sound")]
    [SerializeField] public AudioClip[] soundClips;

    [Header("Audio")]
    [SerializeField] public AudioClip[] dialogueTypingSoundClips;
    [Range(1, 5)][SerializeField] private int frequencyLevel = 3;
    [Range(-3, 3)][SerializeField] private float minPitch = 0.5f;
    [Range(-3, 3)][SerializeField] private float maxPitch = 2.0f;
    [SerializeField] private bool makePredictable;
    private bool stopAudioSource = true;
    public AudioSource audioSource { get; private set; }

    [Header("Background Music")]
    public AudioClip[] endingClips;

    [Header("CG")]
    public GameObject CGBackground;
    public Sprite[] CGImages;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }  // read only outside script
    private bool canContinueToNextLine = false;
    private bool isChoosing;
    private Coroutine displayLineCoroutine;
    private bool canSkip = false;
    private bool submitSkip = false;
    private bool justAfterChoosing = false;
    private GameObject triggerGameObject;
    private UnityEngine.Vector3 originToward;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

    private DialogueVariables dialogueVariables;
    private InkExternalFunctions InkExternalFunctions;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }

        instance = this;

        dialogueVariables = new DialogueVariables(loadGlobalsJSON);

        audioSource = this.gameObject.AddComponent<AudioSource>();

        InkExternalFunctions = new InkExternalFunctions();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueIsPlaying = false;
        isChoosing = false;
        dialoguePanel.SetActive(false);
        CGBackground.SetActive(false);

        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        // get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];

        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // return right away if dialogue is not playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            submitSkip = true;
        }

        // handle continue to the next line in the dialogue when submit is press
        // condition: 
        // 1. press space or click left mouse 
        // 2. there is no choices
        // 3. player is not choosing
        // 4. dialogue is not typing
        if (
            (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            && currentStory.currentChoices.Count == 0
            && !isChoosing
            && canContinueToNextLine
        )
        {
            ContinueStory();
        }
        else
        {
            isChoosing = false;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        // hint UI move up
        HintManager.GetInstance().MoveUp();

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        // bind function
        InkExternalFunctions.Bind(currentStory, triggerGameObject);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        CameraManager.GetInstance().ResetCamera();

        dialogueVariables.StopListening(currentStory);

        // unbind function
        InkExternalFunctions.Unbind(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        CGBackground.SetActive(false);
        dialogueText.text = "";

        if (triggerGameObject)
        {
            // hint UI move down
            if (triggerGameObject.activeSelf)
            {
                HintManager.GetInstance().MoveDown();
            }

            bool lookAtPlayer = triggerGameObject.GetComponent<DialogueTrigger>().lookAtPlayer;
            // reset toward
            if (triggerGameObject.transform.parent.tag != "Enemy" && triggerGameObject.transform.parent.tag != "Rotation" & lookAtPlayer)
            {
                triggerGameObject.transform.parent.DODynamicLookAt(originToward, 0.5f);
            }
        }
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // set text for the current dialogue line
            string nextLine = currentStory.Continue();
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            // handle case where the last line is an external function
            if (nextLine.Equals("") && !currentStory.canContinue)
            {
                StartCoroutine(ExitDialogueMode());
            }
            else
            {
                // handle tags
                HandleTags(currentStory.currentTags);
                displayLineCoroutine = StartCoroutine(DisplayLine(nextLine));

            }
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        // loop through each tag and handle it accordingly
        foreach (string tag in currentTags)
        {
            // parse the tag
            string[] splitTag = tag.Split(':');

            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            // handle the tag
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    // Debug.Log("speaker: " + tagValue);
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    if (tagValue == "Layne")
                    {
                        int melancholyIndex = StatusManager.GetInstance().melancholyIndex;
                        portraitAnimator.Play($"Layne{melancholyIndex}");
                    }
                    else
                    {
                        portraitAnimator.Play(tagValue);
                    }
                    break;
                case LAYOUT_TAG:
                    // Debug.Log("layout: " + tagValue);
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        // set the text to the full line, but set the visible characters to 0
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;

        // hide items while text is typing
        continueIcon.SetActive(false);
        HideChoices();

        submitSkip = false;
        canContinueToNextLine = false;
        bool isAddingRichTextTag = false;

        StartCoroutine(CanSkip());

        // display each letter one at time
        foreach (char letter in line.ToCharArray())
        {
            // if player press space or click left mouse, finish up the displaying line 
            if (canSkip && submitSkip)
            {
                submitSkip = false;
                dialogueText.maxVisibleCharacters = line.Length;
                break;
            }

            // check for rich text tag, if found, add it without waiting
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;

                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            // if not rich text, add the next letter and wait a small time
            else
            {
                // PlayDialogueSound(dialogueText.maxVisibleCharacters, letter);
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        // actions to take after the entire line has finished displaying
        continueIcon.SetActive(true);

        // display choices for the dialogue line
        DisplayChoices();

        canContinueToNextLine = true;
        canSkip = false;
        justAfterChoosing = false;
    }

    private IEnumerator CanSkip()
    {
        canSkip = false; // Making sure the variable is false.
        yield return new WaitForSeconds(0.05f);

        if (justAfterChoosing)
        {
            submitSkip = false;
        }

        canSkip = true;
    }

    private void PlayDialogueSound(int currentDisplayedCharacterCount, char currentCharacter)
    {
        if (currentDisplayedCharacterCount % frequencyLevel == 0)
        {
            if (stopAudioSource)
            {
                audioSource.Stop();
            }

            AudioClip soundClip = null;
            // create predictable audio from hashing 
            if (makePredictable)
            {
                int hashCode = currentCharacter.GetHashCode();

                // sound clip
                int predictableIndex = hashCode % dialogueTypingSoundClips.Length;

                if (predictableIndex < 0)
                {
                    predictableIndex *= -1;
                }

                soundClip = dialogueTypingSoundClips[predictableIndex];

                // pitch
                int minPitchInt = (int)minPitch * 100;
                int maxPitchInt = (int)maxPitch * 100;
                int pitchRangeInt = maxPitchInt - minPitchInt;

                // can not divide by 0, so if there is no range then skip the selection
                if (pitchRangeInt == 0)
                {
                    audioSource.pitch = minPitch;
                }
                else
                {
                    int predictablePitchInt = (hashCode % pitchRangeInt) + minPitchInt;
                    float predictablePitch = predictablePitchInt / 100f;
                    audioSource.pitch = predictablePitch;
                }
            }
            // otherwise, randomize the audio
            else
            {
                // sound clip
                int randomIndex = UnityEngine.Random.Range(0, dialogueTypingSoundClips.Length);
                soundClip = dialogueTypingSoundClips[randomIndex];

                // pitch
                audioSource.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
            }

            // play sound
            audioSource.PlayOneShot(soundClip);
        }
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in 
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError(
                "More choices were given than the UI can support. Number of choices given "
                + currentChoices.Count
            );
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choices[index].gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);
            choicesText[index].text = choice.text;
            index++;
        }

        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        };

        // you can select by arrow button
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, 
        // than wait for at least 1 frame before we set the current selected object
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            isChoosing = true;
            justAfterChoosing = true;

            string playerChoice = choicesText[choiceIndex].text;

            // print(playerChoice);

            ContinueStory();
        }
    }

    public void SetTriggerGameObject(GameObject otherGameObject, Transform gameObjectTransform)
    {
        // record which game object trigger dialogue 
        triggerGameObject = otherGameObject;

        originToward = gameObjectTransform.position + gameObjectTransform.forward;
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);

        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }

        return variableValue;
    }
}
