using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

    private Transform mainCamera;

    private Ray ray;
    private RaycastHit hitInfo;

    public float rayRange = 1f;
    public LayerMask interactionLayer;

    [SerializeField] GameObject objInteraction;

    public Image crossHair;
    public Sprite point;
    public Sprite hand;
    public Text textInteraction;

    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        ray.origin = mainCamera.position;
        ray.direction = mainCamera.forward;

        if (Physics.Raycast(ray, out hitInfo, rayRange, interactionLayer))
        {
            objInteraction = hitInfo.collider.gameObject;
            crossHair.sprite = hand;
        }
        else
        {
            objInteraction = null;
            crossHair.sprite = point;
            StartCoroutine("eraseText");
        }

        if (Input.GetKeyDown(KeyCode.F) && objInteraction != null)
        {
            StopCoroutine("eraseText");
            objInteraction.SendMessage("Interaction", SendMessageOptions.DontRequireReceiver);
        }

        Debug.DrawRay(ray.origin, ray.direction * rayRange, Color.red, 1);
    }

    public void SetTextInteraction(string text)
    {
        textInteraction.text = text;
    }

    IEnumerator eraseText()
    {
        yield return new WaitForSeconds(1f);
        SetTextInteraction("");
    }
}
