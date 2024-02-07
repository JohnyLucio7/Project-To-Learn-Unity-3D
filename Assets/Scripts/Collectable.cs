using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    Interaction interaction;
    public string text = "Call collectable interaction function!";

    private void Awake()
    {
        interaction = FindObjectOfType<Interaction>();
    }

    private void Interaction()
    {
        interaction.SetTextInteraction(text);
    }
}
