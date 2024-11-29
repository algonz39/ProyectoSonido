using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class DoorController : Interactable
{
    [SerializeField]
    private float openingSpeed = 1.0f;
    private float aperture;
    private Transform hinge;

    private Material objectMaterial;
    private Color originalColor;
    [SerializeField]
    private Color highlightColor = new Color(0.65f, 0.65f, 0.7f);

    private void Start()
    {
        hinge = transform.parent;
        objectMaterial = GetComponent<Renderer>().material;
        originalColor = objectMaterial.GetColor("_EmissionColor");
        aperture = 0.0f;
    }
    public override void onFocus()
    {
        objectMaterial.SetColor("_EmissionColor", highlightColor);
    }

    public override void onLostFocus()
    {
        objectMaterial.SetColor("_EmissionColor", originalColor);
    }

    public override void onInteract(int mouseButton)
    {
        int direction = 1 - 2 * mouseButton;
        aperture += direction * Time.deltaTime * openingSpeed;
        aperture = Mathf.Clamp01(aperture);
        hinge.localRotation = Quaternion.Euler(0, -100 * aperture, 0);
    }


}
