using System.Collections;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject Pipe;
    public GameObject Parent;
    public float MinPipeHeight = -1.79f, MaxPipeHeight = 1.79f;
    public GameObject SpawnPos;
    
    
    

    private void Start()
    {
        StartCoroutine(InstantiatePipe());
    }

    IEnumerator InstantiatePipe()
    {
        yield return new WaitForSecondsRealtime(Random.Range(2f, 4f));

        Instantiate(Pipe, new Vector3(15 + SpawnPos.transform.position.x, Random.Range(MinPipeHeight, MaxPipeHeight)), Quaternion.identity, Parent.transform);

        StartCoroutine(InstantiatePipe());
    }
    
    
}
