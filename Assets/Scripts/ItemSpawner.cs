using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int direction = 1;
    public Rigidbody2D item;
    public Transform spawnPos;
    public float cooldown = 1;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            Instantiate(item, spawnPos);
            timer = 0;
        }
    }
}
