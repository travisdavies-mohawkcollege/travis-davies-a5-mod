using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]public ParticleSystem jumpParticles1;
    [SerializeField] public ParticleSystem jumpParticles2;
    [SerializeField] public ParticleSystem jumpParticles3;
    [SerializeField] public ParticleSystem jumpParticles4;
    [SerializeField] public ParticleSystem endParticle1;
    [SerializeField] public ParticleSystem endParticle2;
    [SerializeField] public ParticleSystem endParticle3;
    [SerializeField] public ParticleSystem endParticle4;

    public void Start()
    {
        // Initialize particles if needed
        jumpParticles1.Stop();
        jumpParticles2.Stop();
        jumpParticles3.Stop();
        jumpParticles4.Stop();
        endParticle1.Stop();
        endParticle2.Stop();
        endParticle3.Stop();
        endParticle4.Stop();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            jumpParticles1.Play();
            jumpParticles2.Play();
            jumpParticles3.Play();
            jumpParticles4.Play();
            Invoke("StopParticles", 1.5f);
            Invoke("EndParticles", 1.5f);
            Invoke("StopEndParticles", 3.2f);
        }

    }

    private void EndParticles()
    {
        endParticle1.Play();
        endParticle2.Play();
        endParticle3.Play();
        endParticle4.Play();
    }

    private void StopParticles()
    {
        jumpParticles1.Stop();
        jumpParticles2.Stop();
        jumpParticles3.Stop();
        jumpParticles4.Stop();
    }

    private void StopEndParticles()
    {
        endParticle1.Stop();
        endParticle2.Stop();
        endParticle3.Stop();
        endParticle4.Stop();
    }
}
