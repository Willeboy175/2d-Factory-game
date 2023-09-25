using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public Rigidbody2D item;
    public Transform raycastOrigin;
    public float cooldown = 1;
    public float timer = 0;
    public LayerMask layerMaskConveyor;
    public LayerMask layerMaskItem;


    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        RaycastHit2D getRotation = Physics2D.Raycast(item.position, item.transform.right, 0.4f, layerMaskConveyor);
        if (timer > cooldown && getRotation.transform != null)
        {
            item.transform.rotation = getRotation.transform.rotation;

            RaycastHit2D hitItem = Physics2D.Raycast(raycastOrigin.position, item.transform.right, 0.2f, layerMaskItem);
            if (hitItem.transform == null)
            {
                RaycastHit2D hitConveyor = Physics2D.Raycast(raycastOrigin.position, item.transform.right, 0.4f, layerMaskConveyor);
                if (hitConveyor.transform != null)
                {
                    item.transform.position = hitConveyor.transform.position;
                    timer = 0;
                }
            }
            
        }
    }
}
