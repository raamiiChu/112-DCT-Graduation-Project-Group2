using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AuditoryHallucinations : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float startTime = 45f;
    [SerializeField] private float repeatTime = 30f;
    [Range(1f, 5f)][SerializeField] private float minDuration = 2.5f;
    [Range(5f, 15f)][SerializeField] private float maxDuration = 5f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Interruption", startTime, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Interruption()
    {
        player = GameManager.GetInstance().player;
        gameObject.transform.Find("Trigger").gameObject.SetActive(false);

        int dice = Random.Range(1, 7);

        if (dice >= 4)
        {
            GameManager.GetInstance().BlurScreen(true);
            StatusManager.GetInstance().setDebuffImage(0);
            HintManager.GetInstance().ShowMission("一陣昏沉疲勞，頭痛，看不清眼前的東西……");
        }
        else
        {
            GameManager.GetInstance().ShakeCamera(5f);
            StatusManager.GetInstance().setDebuffImage(1);
            HintManager.GetInstance().ShowMission("一時間身體無法平衡，有種天旋地轉的感覺，好像有點想吐……");
        }

        gameObject.transform.position = player.transform.position;

        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            gameObject.transform.Find("Trigger").gameObject.SetActive(true);
        }

        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(Random.Range(minDuration, maxDuration));

        GameManager.GetInstance().BlurScreen(false);
        StatusManager.GetInstance().debuffUI.SetActive(false);
    }
}
