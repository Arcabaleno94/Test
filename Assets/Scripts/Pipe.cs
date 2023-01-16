using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float SpeedPipe;
    public bool canMove = true;

    private void FixedUpdate()
    {
        if(canMove)
        {
            transform.position -= new Vector3(SpeedPipe, 0, 0);
        }

       
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
