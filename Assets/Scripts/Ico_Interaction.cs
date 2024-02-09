using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ico_Interaction : MonoBehaviour
{
    GameController gameController;
    public Image ico;
    public Text txtDistance;
    public GameObject canvas;

    private bool isBehind;
    public bool isShowDistance;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        txtDistance.text = "";
        txtDistance.gameObject.SetActive(false);
        canvas.SetActive(false);
    }

    void Update()
    {

        if (isShowDistance == false)
        {
            if (Vector3.Distance(transform.position, gameController.PlayerBody.position) <= gameController.icoInteractionDistance)
            {
                canvas.SetActive(true);

                UpdateCanvas();
            }
            else
            {
                canvas.SetActive(false);
            }
        }
        else
        {
            canvas.SetActive(true);
            UpdateCanvas();
        }
    }

    void UpdateCanvas()
    {
        Vector3 toOther = transform.position - gameController.PlayerBody.position;
        Vector3 forward = gameController.PlayerBody.forward;

        isBehind = Vector3.Dot(toOther, forward) < 0;

        float distance = Vector3.Distance(transform.position, gameController.PlayerBody.position);

        if (isShowDistance)
        {
            if (distance > 2)
            {
                txtDistance.gameObject.SetActive(true);
            }
            else
            {
                txtDistance.gameObject.SetActive(false);
            }
        }

        txtDistance.text = distance.ToString("N0") + "m";

        if (isBehind == false)
        {
            Vector2 icoPos = Camera.main.WorldToScreenPoint(transform.position);
            ico.transform.position = icoPos;
        }
    }
}
