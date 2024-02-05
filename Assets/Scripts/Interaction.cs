using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    private Transform mainCamera;

    private Ray ray;
    private RaycastHit hitInfo;

    public float rayRange = 1f;
    public LayerMask interactionLayer;

    [SerializeField] GameObject objInteraction;

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
        }
        else
        {
            objInteraction = null;
        }

        if (Input.GetKeyDown(KeyCode.F) && objInteraction != null)
        {
            objInteraction.SendMessage("Interaction", SendMessageOptions.DontRequireReceiver);
        }

        Debug.DrawRay(ray.origin, ray.direction * rayRange, Color.red, 1);
    }
}
