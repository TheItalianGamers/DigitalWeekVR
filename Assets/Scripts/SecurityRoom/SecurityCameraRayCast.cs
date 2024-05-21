using UnityEngine;

public class SecurityCameraRayCast : MonoBehaviour
{
    public Transform startingPoint;
    public Transform directionPoint;

    public GameObject detectionArea;
    private GameObject previousArea;

    void Update()
    {
        if (Physics.Raycast(startingPoint.position, directionPoint.InverseTransformDirection(Vector3.back), out RaycastHit hit, 15f))
        {
            if (previousArea != null) Destroy(previousArea);

            Debug.DrawLine(startingPoint.position, hit.point, Color.red);
            Debug.Log(hit.collider.name);

            if(hit.collider.gameObject.name == "Floor")
                previousArea = Instantiate(detectionArea, hit.point, Quaternion.identity);

        }
        
    }
}
