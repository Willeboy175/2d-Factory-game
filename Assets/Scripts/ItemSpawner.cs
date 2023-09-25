using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Rigidbody2D item;
    public Transform spawnPos;
    public Transform raycastOrigin;
    public float cooldown = 1;
    public float timer = 0;
    public LayerMask layerMaskConveyor;
    public LayerMask layerMaskItem;


    // Start is called before the first frame update
    void Start()
    {
        raycastOrigin = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        RaycastHit2D hitItem = Physics2D.Raycast(raycastOrigin.position, raycastOrigin.right, 1, layerMaskItem);
        if (timer > cooldown && hitItem.transform == null)
        {
            RaycastHit2D hitConveyor = Physics2D.Raycast(raycastOrigin.position, raycastOrigin.right, 1, layerMaskConveyor);
            if (hitConveyor.transform != null)
            {
                Instantiate(item, spawnPos.position, raycastOrigin.rotation);
                timer = 0;
            }
            
        }
    }
}
