using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, new Vector2(0, 1), 0.25f);

        if (hit.transform.gameObject != null && hit.transform.CompareTag("Water"))
        {
            print("Water");

        }

        player.SetActive(true);
        cameraObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
