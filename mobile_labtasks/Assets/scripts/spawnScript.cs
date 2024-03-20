using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public float positionX_start, positionX_end, positionY, positionZ;
    private float positionX;
    public GameObject prefabMissile;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnMissile", 1, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnMissile()
    {
        positionX = Random.Range(positionX_start, positionX_end);

        //positionY = 0;
        //positionZ = 0;
        var spawnPosition = new Vector3(positionX, positionY, positionZ);
        Instantiate(prefabMissile, spawnPosition, transform.rotation);
    }
}
