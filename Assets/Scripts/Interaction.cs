using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

    private Transform mainCamera;

    private Ray ray;
    private RaycastHit hitInfo;

    public float rayRange = 1.3f;
    public LayerMask interactionLayer;

    [SerializeField] GameObject objInteraction;
    public InteractableItem objeto;

    public Image crossHair;
    public Sprite point;
    public Sprite hand;
    public Text textInteraction;
    private bool isInteraction;

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
            if (isInteraction == false)
            {
                objInteraction = hitInfo.collider.gameObject;
                objInteraction.SendMessage("StartInteraction", SendMessageOptions.DontRequireReceiver);
                crossHair.sprite = hand;
                isInteraction = true;
            }
        }
        else
        {
            objInteraction = null;
            crossHair.sprite = point;
            SetTextInteraction("");
            objeto = null;
            isInteraction = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && objInteraction != null)
        {
            StopCoroutine("eraseText");
            textInteraction.text = objeto.msgOnInteraction;
        }

        Debug.DrawRay(ray.origin, ray.direction * rayRange, Color.red, 1);
    }

    public void StartInteraction(InteractableItem item)
    {
        objeto = item;
        textInteraction.text = objeto.msgInteraction;
    }

    public void SetTextInteraction(string text)
    {
        textInteraction.text = text;
    }
}
