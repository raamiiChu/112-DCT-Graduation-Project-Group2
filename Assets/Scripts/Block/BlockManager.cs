using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private static BlockManager instance;
    public GameObject[] blockTypes;
    public GameObject blocks;

    private bool spawning = true;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Block Manager in the scene");
        }

        instance = this;
    }

    public static BlockManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        int sanity = StatusManager.GetInstance().sanity;
        float repeatRate = (sanity / 100f) + 0.05f;
        print(repeatRate);

        InvokeRepeating("spawnBlocks", 1f, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnBlocks()
    {
        if (!spawning)
        {
            return;
        };

        int blockTypeIndex = Random.Range(0, blockTypes.Length - 1);
        GameObject newBlock = Instantiate(blockTypes[blockTypeIndex]);
        newBlock.transform.SetParent(blocks.transform, false);
        newBlock.transform.position = new Vector3(Random.Range(100f, 1820f), Random.Range(100f, 980f), 0f);
    }

    public void StopSpawnBlocks()
    {
        spawning = false;

        CancelInvoke("SpawnBlocks");

        // Destroy all child objects of 'blocks'
        foreach (Transform child in blocks.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
