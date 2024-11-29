using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField]
    private float interactionDistance = 4.0f;

    private bool interacting;

    private Transform cameraTr;
    private Interactable currentInteractable;
    // Start is called before the first frame update
    void Start()
    {
        cameraTr = GetComponentInChildren<Camera>().gameObject.transform;
        interacting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!interacting) CheckInteractable();

        interacting = false;
        for (int i = 0; i < 2; i++)
        {
            if (Input.GetMouseButton(i) && currentInteractable != null)
            {
                interacting = true;
                currentInteractable.onInteract(i);
            }
        }
    }

    private void CheckInteractable()
    {
        if (Physics.Raycast(cameraTr.position, cameraTr.forward, out RaycastHit hit, interactionDistance))
        {
            if (currentInteractable && currentInteractable.gameObject.GetInstanceID() != hit.collider.gameObject.GetInstanceID())
            {
                currentInteractable.onLostFocus();
                currentInteractable = null;
            }
            if (currentInteractable == null && hit.collider.gameObject.layer == 9)
            {
                hit.collider.TryGetComponent(out currentInteractable);
                if (currentInteractable)
                {
                    currentInteractable.onFocus();
                }
            }
        }
        else if (currentInteractable)
        {
            currentInteractable.onLostFocus();
            currentInteractable = null;
        }
    }
}
