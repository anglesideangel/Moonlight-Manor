using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorClosed : MonoBehaviour
{
    public TMP_Text text;
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        text.gameObject.SetActive(false);
    }

}