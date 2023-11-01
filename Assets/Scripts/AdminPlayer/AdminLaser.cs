using System.Collections;
using UnityEngine;

public class AdminLaser : MonoBehaviour
{
    public Camera adminCamera;
    public Transform laserOrigin;
    public float laserMaxLength = 50f;
    public float laserDuration = 0.05f;
    
    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    
    void Update()
    {
        if(Input.GetMouseButton(0)) ShootLaser();
        else lineRenderer.enabled = false;
    }

    private void ShootLaser()
    {
        lineRenderer.enabled = true;
        
        lineRenderer.SetPosition(0, laserOrigin.position);
        Vector3 rayOrigin = adminCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        
        if(Physics.Raycast(rayOrigin, adminCamera.transform.forward, out hit, laserMaxLength))
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else lineRenderer.SetPosition(1, rayOrigin + (adminCamera.transform.forward * laserMaxLength));

    }
}