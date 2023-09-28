using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public Transform raycastOrigin;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        print("ObjectDestroyer");
        raycastOrigin = GetComponent<Transform>();

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, new Vector2(1, 0), 0.4f, layerMask);
        if (hit.transform != null)
        {
            Destroy(hit.transform.gameObject);
        }
        Destroy(raycastOrigin.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
