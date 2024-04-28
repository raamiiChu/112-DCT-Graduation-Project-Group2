using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int melancholy;
    // Start is called before the first frame update
    void Start()
    {
        melancholy = StatusManager.GetInstance().melancholy;
        StartCoroutine("Kill");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Kill()
    {
        // 0 => 0.5f
        // 100 => 7.5f

        // m / 100 * 7 + 0.5 
        // yield return new WaitForSeconds(Random.Range(7.5f, 15f));
        float spawnRate = melancholy / 100f * 7f + 0.5f;

        yield return new WaitForSeconds(Random.Range(spawnRate, spawnRate + 2.5f));
        Destroy(gameObject);
    }
}
