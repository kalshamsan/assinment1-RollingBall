using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public float speed;
    public Text counterText, winText;
    private int counter;
    private Rigidbody playerRb;



    void Start()
    { playerRb = GetComponent<Rigidbody>();
        audioSource.clip = audioClip;
        counter = 0; 
        winText.text = "";
        CounterTextUpdate();
    }

    void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        playerRb.AddForce(playerMovement * speed);
	}

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("collect"))
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            counter = ++counter;
            CounterTextUpdate();
        }
    }

    void CounterTextUpdate()
    {
        counterText.text = "Points: " + counter.ToString();
        if (counter >= 10) { winText.text = "You Won!!"; }

    }
}