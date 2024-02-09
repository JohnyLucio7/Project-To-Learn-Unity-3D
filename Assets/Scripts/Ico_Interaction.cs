using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ico_Interaction : MonoBehaviour
{
    GameController gameController;
    public Image ico;
    public GameObject canvas;

    private bool isBehind;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, gameController.PlayerBody.position) <= gameController.icoInteractionDistance)
        {
            canvas.SetActive(true);

            Vector3 toOther = transform.position - gameController.PlayerBody.position;
            Vector3 forward = gameController.PlayerBody.forward;

            isBehind = Vector3.Dot(toOther, forward) < 0;

            if (isBehind == false)
            {
                Vector2 icoPos = Camera.main.WorldToScreenPoint(transform.position);
                ico.transform.position = icoPos;
            }
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}
