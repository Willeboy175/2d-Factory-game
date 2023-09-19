using System;
using System.Collections;
using UnityEngine;

public class TilePlacingSystem : MonoBehaviour
{
    Vector3 mousePos;
    int list = 1;

    public GameObject currentPlaceableObject;
    public GameObject[] placeableObjects;
    public GameObject[] buttons;

    public KeyCode newObjectHotkey = KeyCode.E;

    public float mouseWheelRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceableObjectSelector();
        HandleNewObjectHotkey();
        if (currentPlaceableObject != null)
        {
            CurrentPlaceableObjectPos();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    private void PlaceableObjectSelector()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            list = 1;
            print("button1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            list = 2;
            print("button2");
        }
    }

    private void HandleNewObjectHotkey()
    {
        if (Input.GetKeyDown(newObjectHotkey))
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(placeableObjects[list - 1]);
            }
        }
    }

    private void CurrentPlaceableObjectPos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPlaceableObject.transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
    }

    private void RotateFromMouseWheel()
    {
        Debug.Log(Input.mouseScrollDelta);
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.forward, mouseWheelRotation * 90f);
        mouseWheelRotation = 0;
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
            print("removed prefab");
        }
    }
}
