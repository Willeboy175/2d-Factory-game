using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacingSystem : MonoBehaviour
{
    Vector3 mousePos;
    public float x;
    public float y;
    public float z;
    int list;

    public GameObject[] placeables;
    public GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        x = mousePos.x;
        y = mousePos.y;
        z = mousePos.z;

        if (buttons[0] == true)
        {
            print("button1");
        }
        if (buttons[1] == true)
        {
            print("button2");
        }
    }
}
