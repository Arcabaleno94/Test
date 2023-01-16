using UnityEngine;

public class CameraMovemen : MonoBehaviour
{
    
    public Transform _playerTarget;
    



    void LateUpdate()
    {
        transform.position = new Vector3(_playerTarget.position.x, transform.position.y, -10);

    }
}
