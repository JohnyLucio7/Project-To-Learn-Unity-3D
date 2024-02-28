using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    GameController gameController;

    public RawImage compassImage;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        float x = gameController.PlayerBody.localEulerAngles.y / 360;
        float y = 0f;
        float width = 1f;
        float height = 1f;

        compassImage.uvRect = new Rect(x, y, width, height);
    }
}
