using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Transform gameObjectTransform;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Enemy can see you");

            StatusManager.GetInstance().ModifySanity(-1);
            StatusManager.GetInstance().ModifyMelancholy(1);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Enemy can not see you");
        }
    }
}
