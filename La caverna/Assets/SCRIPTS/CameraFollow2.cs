using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f; //aqui se define el tiempo que llevará de la cámara al target 
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target; //se indica que el target a seguir (artur) se define en Unity
    
    //La actualización es llamada una vez por cada frame
    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
