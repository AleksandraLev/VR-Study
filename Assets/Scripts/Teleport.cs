//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Teleport : MonoBehaviour
//{
//    public GameObject pointer;
//    public LineRenderer lineRenderer;
//    public int lineSegments = 10;
//    public float parabolaHeight = 1f;

//    private void OnEnable()
//    {
//        TestInputSystem.TeleportTriggered.AddListener(TeleportToPointer);
//    }

//    private void OnDisable()
//    {
//        TestInputSystem.TeleportTriggered.RemoveListener(TeleportToPointer);
//    }

//    private void TeleportToPointer()
//    {
//        transform.parent.position = pointer.transform.position + Vector3.up*0.01f;
//    }

//    private void Update()
//    {
//        RaycastHit hit;
//        if (Physics.Raycast(transform.position, transform.forward, out hit))
//        {
//            pointer.SetActive(true);
//            pointer.transform.position = hit.point;
//            DrawParabola(lineRenderer.transform.position, hit.point);
//        }
//        else
//        {
//            pointer.SetActive(false);
//            lineRenderer.positionCount = 0;
//        }
//    }

//    private void DrawParabola(Vector3 start, Vector3 end)
//    {
//        lineRenderer.positionCount = lineSegments + 1;
//        Vector3 diff = end - start;
//        for (int i = 0; i <= lineSegments; i++)
//        {
//            float t = i / (float)lineSegments;
//            Vector3 point = start + t * diff;
//            point.y += parabolaHeight * t * (1 - t);
//            lineRenderer.SetPosition(i, point);
//        }
//    }
//}
