using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform target;
    
    public float distance = 6f;
    public float height = 3f;
    

    public float positionSmoothSpeed = 5f;
    public float rotationSmoothSpeed = 5f;

    void LateUpdate()
    {

        if (target == null) return;

        Vector3 desiredPosition = target.position - (target.forward * distance) + (Vector3.up * height);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, positionSmoothSpeed * Time.deltaTime);

        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed * Time.deltaTime);
    }
}