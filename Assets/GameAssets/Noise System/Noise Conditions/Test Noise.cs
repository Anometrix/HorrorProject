using UnityEngine;

public class TestNoise : MonoBehaviour
{
    float timer;
    [SerializeField] float maxtimerlength;
    [SerializeField] NoiseProfile noiseprofile;
    [SerializeField] bool showGizmo = true;

    private void Awake()
    {
        timer = maxtimerlength;

    }

    void Update()
    {
        if (timer <= 0f)
        {
            Debug.Log("Emitted Noise");
            NoiseSystemManager.manInstance.EmitSound(noiseprofile, transform.position);
            timer = maxtimerlength;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        if (noiseprofile != null && showGizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, noiseprofile.radius);
        }
    }
}
