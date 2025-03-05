using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToPosition : MonoBehaviour
{
     public Transform correctPosition; // Assign in Inspector: Where this piece should snap
    private XRGrabInteractable grabInteractable; // The XR grab component
    private bool isLocked = false; // Prevents further movement when snapped


    // Start is called before the first frame update
    void Start()
    {
         grabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if (!isLocked && other.CompareTag("SnapZone")) // Ensure it snaps only to valid zones
        {
            if (other.transform == correctPosition) // Check if it's the correct snap zone
            {
                SnapIntoPlace();
            }
        }
    }

    private void SnapIntoPlace()
    {
        isLocked = true;
        transform.position = correctPosition.position; // Move to the exact position
        transform.rotation = correctPosition.rotation; // Align rotation
        grabInteractable.enabled = false; // Disable further grabbing
        GetComponent<Rigidbody>().isKinematic = true; // Lock in place

        Debug.Log(gameObject.name + " snapped correctly!");
    }
}
