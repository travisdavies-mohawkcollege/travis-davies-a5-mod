using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource background;
    public AudioSource XWingSFX;
    public AudioSource hyperSpaceSFX;
    public GameManager gameManager;
    public AudioSource gameOver;
    private bool musicPlaying = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        background.Play(0);
        musicPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            XWingSFX.Play(0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            hyperSpaceSFX.Play(0);
        }
        if (gameManager.IsGameOver())
        {
            background.Stop();
            if (musicPlaying == false)
            {
                gameOver.PlayOneShot(gameOver.clip);
                musicPlaying = true;
            }
            
        }
    }
}
