using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    Canvas minimap;
    [SerializeField]
    RectTransform pointer;
    [SerializeField]
    Transform playePos;
    [SerializeField]
    RectTransform[] doorPointers;
    [SerializeField]
    DoorController[] doors;
    [SerializeField]
    GameObject[] texts;
    // Start is called before the first frame update
    void Start()
    {
        minimap = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        minimap.enabled = Input.GetKey(KeyCode.Tab);
        pointer.localPosition = new Vector3(playePos.position.x * 5.0f, playePos.position.z * 5.0f, 0);
        pointer.localRotation = Quaternion.Euler(Vector3.back * playePos.eulerAngles.y);
        for (int i = 0; i < doorPointers.Length; i++) {
            doorPointers[i].localRotation = Quaternion.Euler(Vector3.back * doors[i].getApperture() * -100.0f);  
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            foreach(GameObject text in texts)
            {
                text.SetActive(!text.activeSelf);
            }
        }
    }
}
