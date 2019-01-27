using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Interactable focus;
    Camera cam;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        RemoveFocus();
        //If we press right mouse
        if (Input.GetMouseButtonDown(1))
        {
            //Create Ray at mouse position
            // Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //Create Ray at player position
            var playerObject = GameObject.Find("Sphere");
            var playerPos = playerObject.transform.position;
      
            Ray ray = cam.ScreenPointToRay(playerPos);
            RaycastHit hit;

            // IF Ray Hits
            if (Physics.Raycast(ray, out hit, 200))
            {
                Debug.Log("Ray Hit");
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                // If we did set it as our focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                }

            }
        }
    }
    void SetFocus (Interactable newFocus)
    {
        focus = newFocus;

    }
    void RemoveFocus ()
    {
        focus = null;
    }
}
