using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Interactable : MonoBehaviour
{
    private void Awake()
    {
        gameObject.layer = 9;
    }
    public abstract void onFocus();
    public abstract void onLostFocus();
    public abstract void onInteract(int mouseButton);
}
