using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Interaction interaction;
    public string text = "Call door interaction function!";
    public InteractableItem objeto;

    private void Awake()
    {
        interaction = FindObjectOfType<Interaction>();
    }
    private void Interaction()
    {
        interaction.SetTextInteraction(text);
    }

    private void StartInteraction()
    {
        interaction.StartInteraction(objeto);
    }
}
