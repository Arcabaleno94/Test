using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float SpeedPlayerVectical;
    public float SpeedPlayerHorizontal;
    
    public Rigidbody player;

    private GameManager _gameManager;
    
    public void PlayerInputSpeed()
    {
        
        if (Input.GetMouseButton(0) || _gameManager.isDead == true)
        {
            player.velocity = new Vector3(SpeedPlayerHorizontal, SpeedPlayerVectical, 0);
        }
        else
        {
            player.velocity = new Vector3(SpeedPlayerHorizontal, -SpeedPlayerVectical, 0);
        }
    }
    
    void Start()
    {
        StartCoroutine(SpeedLevel());
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    
    void Update()
    {
       
       PlayerInputSpeed();
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Damage") || collision.gameObject.CompareTag("Pipe"))
        {
            _gameManager.isDead = true;
            player.velocity = new Vector3(SpeedPlayerVectical, 0, 0);
            
            Debug.Log("Stop");
        }
    }
    IEnumerator SpeedLevel()
    {
        yield return new WaitForSecondsRealtime(15f);

        SpeedPlayerVectical = SpeedPlayerVectical + 0.5f;

        StartCoroutine(SpeedLevel());
    }

    public void StandartLevel()
    {
        SpeedPlayerVectical = 3f;
    }
    public void MediumLevel()
    {
        SpeedPlayerVectical = 4.5f;
    }
    public void MaximumLevel()
    {
        SpeedPlayerVectical = 6f;
    }
}
