using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class HintManager : MonoBehaviour
{
    private static HintManager instance;
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject missionHint;
    [SerializeField] private GameObject controlHints;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Hint Manager in the scene");
        }

        instance = this;
    }

    private void Start()
    {
        missionHint.SetActive(false);
    }

    public static HintManager GetInstance()
    {
        return instance;
    }

    public void MoveDown()
    {
        // hint UI move down
        hint.transform.DOLocalMoveY(465f, 0.5f);
    }

    public void MoveUp()
    {
        // hint UI move up
        hint.transform.DOLocalMoveY(615f, 0.5f);
    }

    public void ShowMission(string missionText)
    {
        StartCoroutine(ShowMissionHint(missionText));
    }

    public void ShowControl()
    {
        StartCoroutine(ShowControlHints());
    }

    private IEnumerator ShowMissionHint(string missionText)
    {
        var missionHintText = missionHint.GetComponent<TextMeshProUGUI>();
        missionHintText.text = missionText;
        missionHint.SetActive(true);

        yield return new WaitForSeconds(7f);

        missionHint.SetActive(false);
    }

    private IEnumerator ShowControlHints()
    {
        controlHints.transform.DOLocalMoveX(740f, 1f);

        yield return new WaitForSeconds(15f);

        controlHints.transform.DOLocalMoveX(1185f, 1f);
    }
}
