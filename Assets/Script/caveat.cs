using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class caveat : MonoBehaviour
{
    public Text caveatText;
    public void SetText(String text)
    {
        caveatText.text = text;
    }
}
