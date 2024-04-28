using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager : MonoBehaviour
{
    private static StatusManager instance;

    [Header("Params")]
    [Range(3f, 60f)][SerializeField] float checkSanityCoolDown = 30f;
    [Range(3f, 60f)][SerializeField] float debuffDuration = 5f;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI sanityText;
    [SerializeField] TextMeshProUGUI melancholyText;
    [SerializeField] GameObject avatar;
    [SerializeField] GameObject sanitySlider;
    [SerializeField] GameObject debuffUI;

    [Header("Player Material")]
    [SerializeField] Material playerMat;

    [Header("Avatars")]
    [SerializeField] Sprite[] avatars;

    [Header("debuffImages")]
    [SerializeField] Sprite[] debuffImages;

    public int sanity { get; private set; } = 100;
    public int melancholy { get; private set; } = 0;
    public int melancholyIndex { get; private set; } = 0;

    private Color32[] colors = new Color32[] {
        new Color32(254, 254, 254, 255),
        new Color32(235, 235, 235, 255),
        new Color32(198, 197, 202, 255),
        new Color32(170, 169, 174, 255),
        new Color32(146, 145, 151, 255),
        new Color32(107, 105, 110, 255),
        new Color32(82, 80, 84, 255),
        new Color32(59, 58, 60, 255),
        new Color32(43, 41, 44, 255),
    };

    private bool isSuffering = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Status Manager in the scene");
        }

        instance = this;
    }

    public static StatusManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        // var sanity = DialogueManager.GetInstance().GetVariableState("sanity");
        sanityText.text = $"Sanity {sanity}";
        melancholyText.text = $"Melancholy {melancholy}";
        sanitySlider.GetComponent<Slider>().value = sanity;

        debuffUI.SetActive(false);

        InvokeRepeating("CheckSanity", 1f, checkSanityCoolDown);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ModifySanity(int diff)
    {
        sanity = Math.Min(Math.Max(sanity + diff, 0), 100);
        sanityText.text = $"Sanity {sanity}";
        sanitySlider.GetComponent<Slider>().value = sanity;
    }

    public void ModifyMelancholy(int diff)
    {
        melancholy = Math.Min(Math.Max(melancholy + diff, 0), 100);
        melancholyText.text = $"Melancholy {melancholy}";

        CheckMelancholy();
    }

    public void CheckSanity()
    {
        bool dialogueIsPlaying = DialogueManager.GetInstance().dialogueIsPlaying;

        if (dialogueIsPlaying || isSuffering || sanity >= 90)
        {
            return;
        }

        int needDebuff = sanity - UnityEngine.Random.Range(-20, 20); ;

        if (needDebuff >= 70)
        {
            return;
        }

        isSuffering = true;

        int debuffDice = UnityEngine.Random.Range(1, 7);

        if (debuffDice <= 2)
        {
            GameManager.GetInstance().BlurScreen(true);
            setDebuffImage(0);
        }
        else if (3 <= debuffDice && debuffDice <= 4)
        {
            GameManager.GetInstance().ShakeCamera(3f);
            setDebuffImage(1);
        }
        else if (5 <= debuffDice && debuffDice <= 6)
        {
            GameManager.GetInstance().SetReverseInput(true);
            setDebuffImage(2);
        }

        StartCoroutine(Reset(debuffDuration));
    }
    public void CheckMelancholy()
    {
        // 0 ~ 8
        melancholyIndex = Math.Min((int)(melancholy / 10), 8);

        // change avatar
        avatar.GetComponent<Image>().sprite = avatars[melancholyIndex];

        // change material
        playerMat.color = colors[melancholyIndex];
    }

    private IEnumerator Reset(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        GameManager.GetInstance().BlurScreen(false);
        GameManager.GetInstance().SetReverseInput(false);
        debuffUI.SetActive(false);

        isSuffering = false;
    }

    public void setDebuffImage(int debuffImageIndex)
    {
        Image debuffUIImage = debuffUI.GetComponent<Image>();

        debuffUIImage.sprite = debuffImages[debuffImageIndex];
        debuffUI.SetActive(true);
    }
}
