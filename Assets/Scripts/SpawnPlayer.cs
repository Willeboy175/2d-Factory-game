using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject spawn;
    public Rigidbody2D rbSpawn;
    public GameObject player;
    public GameObject cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        rbSpawn = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(spawn.transform.position, new Vector2(0, 1), 0.4f);

        //Move rbSpawn up so player dont spawn in water
        if (hit)
        {
            rbSpawn.transform.position += new Vector3(0, 1, 0);
            print("hit");
        }
        else
        {
            player.transform.position = spawn.transform.position;
            player.SetActive(true);
            cameraObject.SetActive(false);
            Destroy(spawn);
        }
    }
}
