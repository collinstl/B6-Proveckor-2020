using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonMovement : MonoBehaviour
{
    //St. Ledger
    #region Variables
    public float floatSpeed;
    public float nextSpawn;
    public float destroy;
    public float spawnHeight;
    public float spawnX;
    bool hasSpawned = false;
    #endregion Variables

    private void Update()
    {
        BalloonMove();
        BalloonSpawner();
        BalloonDestroyer();
        Debug.Log(transform.position.y);
    }

    private void BalloonMove()
    {
        transform.Translate(Vector2.up * Time.deltaTime * floatSpeed);
    }

    private void BalloonSpawner()
    {
        if(transform.position.y > nextSpawn &&!hasSpawned)
        {
            Debug.Log("Aaaanddd Spawn!");
            GameObject.Instantiate(gameObject, new Vector3(spawnX, spawnHeight, 0), Quaternion.identity, transform.parent);
            hasSpawned = true;
        }
    }

    private void BalloonDestroyer()
    {
        if(transform.position.y > destroy)
        {
            Destroy(gameObject);
        }
    }
    
}
