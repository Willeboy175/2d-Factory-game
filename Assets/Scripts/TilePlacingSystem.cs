using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacingSystem : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public GameObject[] itemPreviews;
    public GameObject currentPrefab;
    public GameObject currentPreview;

    public LayerMask layerMask;
    public static int list = 1;
    public float mouseWheelRotation;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPrefab != null)
        {
            CurrentPreviewPos();
            RotateCurrentPreview();
            DeselectCurrentPrefab();
            PlaceCurrentPrefab();
        }
    }

    public void SelectCurrentPrefab()
    {
        //Destroys current preview and selects a new prefab and preview object
        if (currentPreview != null)
        {
            Destroy(currentPreview);
        }
        currentPrefab = itemPrefabs[list - 1];
        currentPreview = Instantiate(itemPreviews[list - 1]);
    }

    void DeselectCurrentPrefab()
    {
        //Destroys and deselects current prefab and preview when RMB is pressed
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(currentPreview);
            currentPrefab = null;
            currentPreview = null;
        }
    }

    void CurrentPreviewPos()
    {
        //Moves the current preview to the rounded x and y-values of the mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPreview.transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
    }

    void RotateCurrentPreview()
    {
        //Rotates the preview by either using the scrollwheel or by pressing R or LeftShift+R
        mouseWheelRotation += Input.mouseScrollDelta.y;
        if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift) == false)
        {
            mouseWheelRotation--;
        }
        else if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
        {
            mouseWheelRotation++;
        }
        
        currentPreview.transform.Rotate(Vector3.forward, mouseWheelRotation * 90f);
        mouseWheelRotation = 0;
    }

    void PlaceCurrentPrefab()
    {
        //Instantiates current prefab on the position of the preview and checks so that it doesnt collide with anyting
        RaycastHit2D hit = Physics2D.Raycast(currentPreview.transform.position, new Vector2(0, 1), 0.4f);
        if (Input.GetMouseButton(0) && hit.transform == null)
        {
            Instantiate(currentPrefab, currentPreview.transform.position, currentPreview.transform.rotation);
        }
    }
}
