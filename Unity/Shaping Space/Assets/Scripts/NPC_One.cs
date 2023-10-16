using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_One : NPC
{
    protected override void SetText()
    {
        // Customize the text for this object.
        textMeshPro.text = "Custom Text 1";
    }
}
