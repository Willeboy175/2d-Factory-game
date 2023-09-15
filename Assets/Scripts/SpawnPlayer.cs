using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(true);
        cameraObject.SetActive(false);

        if (Physics2D.Raycast(player.transform.position, new Vector2(0, 1), 0.25f) && gameObject.CompareTag("Water"))
        {
            print("Water");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
