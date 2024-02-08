using UnityEngine;

[CreateAssetMenu(fileName = "Objeto Interativo", menuName = "Objeto Interativo/Novo")]
public class InteractableItem : ScriptableObject
{
    public string msgInteraction;
    public string msgOnInteraction;
}
