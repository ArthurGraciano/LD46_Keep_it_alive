using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusItem_Spawner : MonoBehaviour
{
    private bool spawnAllowed;
    [SerializeField]
    private GameObject bonusItem;
    private GameObject bonusItemClone;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnAllowed == true && planet.healthAmount > 0)
        {
            StartCoroutine(RespawnControl());
            
        }
    }
    IEnumerator RespawnControl()
    {
        int randomTime = Random.Range(3, 10);
        bonusItemClone = Instantiate(bonusItem);
        Destroy(bonusItemClone, 15f);
        spawnAllowed = false;

        yield return new WaitForSeconds(randomTime);
        spawnAllowed = true;
    }
}
