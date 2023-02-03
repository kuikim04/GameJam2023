using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10f);
    private Vector3 verocity = Vector3.zero;
    private float smoothTime = 0.25f;

    [SerializeField] private Transform target;
    private void Awake()
    {
        if (target == null) GameObject.FindGameObjectsWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 targetPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position,
            targetPosition, ref verocity, smoothTime);

       
    }
}
