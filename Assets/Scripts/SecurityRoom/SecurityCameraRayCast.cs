using UnityEngine;

public class SecurityCameraRayCast : MonoBehaviour
{
    public Transform targetStartPoint;
    public Transform rotatingVector;

    public GameObject detectionArea;
    private GameObject previousArea;
    
    void Update()
    {
        targetStartPoint.localEulerAngles = rotatingVector.localEulerAngles;

        if (Physics.Raycast(targetStartPoint.position, targetStartPoint.TransformDirection(Vector3.down), out RaycastHit hit, 15f))
        {
            if (previousArea != null) Destroy(previousArea);

            Debug.DrawLine(targetStartPoint.position, hit.point, Color.red);
            Debug.Log(hit.collider.name);

            if(hit.collider.gameObject.name == "Floor")
                previousArea = Instantiate(detectionArea, hit.point, Quaternion.identity);

        }
        
    }

}
