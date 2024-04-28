using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AskForPassword : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var completePillars = DialogueManager.GetInstance().GetVariableState("completePillars").ToString();

        if (completePillars == "1" && Input.GetKeyDown(KeyCode.P))
        {
            player = GameManager.GetInstance().player;
            gameObject.transform.Find("Trigger").gameObject.SetActive(false);

            gameObject.transform.position = player.transform.position;
            gameObject.transform.Find("Trigger").gameObject.SetActive(true);
        }
    }
}
