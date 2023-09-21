using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int direction = 1;
    public Rigidbody2D item;
    public Transform raycast;
    public Transform spawnPos;
    public float cooldown = 1;
    public float timer = 0;

    int layerMask;


    // Start is called before the first frame update
    void Start()
    {
        raycast = GetComponent<Transform>();
        layerMask = ~(LayerMask.GetMask("Conveyor"));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(raycast.transform.position, new Vector2(1, 0), 0.5f, layerMask);

        if (timer > cooldown && hit.transform.gameObject != null)
        {
            print(hit.transform.name);
            if (hit.transform.CompareTag("Conveyor") == true)
            {
                print("Conveyor");
                Instantiate(item, spawnPos.transform.position, raycast.transform.rotation);
                timer = 0;
            }
        }
        else if (timer > cooldown * 2)
        {
            timer = 1;
        }
    }
}
