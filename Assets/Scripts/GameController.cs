using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private PlayerFPS playerFPS;
    public Transform PlayerBody;

    public float icoInteractionDistance = 3.5f;

    private void Awake()
    {
        playerFPS = FindObjectOfType<PlayerFPS>();
        PlayerBody = playerFPS.transform;
    }
}
