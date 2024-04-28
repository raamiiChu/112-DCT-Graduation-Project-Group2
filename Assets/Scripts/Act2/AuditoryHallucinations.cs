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
        }
        else
        {
            GameManager.GetInstance().ShakeCamera(5f);
        }

        gameObject.transform.position = player.transform.position;

        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            gameObject.transform.Find("Trigger").gameObject.SetActive(true);
        }

        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(minDuration, maxDuration));

        GameManager.GetInstance().BlurScreen(false);
    }
}
