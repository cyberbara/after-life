using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public LayerMask groundLayer;
    public AudioClip defaultFootstepSound;
    public AudioClip concreteFootstepSound;
    public AudioClip grassFootstepSound;
    public AudioClip mudFootstepSound;
    public float footstepVolume = 1.0f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = footstepVolume;
    }

    private void PlayFootstepSound(string surfaceTag)
    {
        AudioClip footstepSound = defaultFootstepSound;

        switch (surfaceTag)
        {
            case "Stone":
                footstepSound = concreteFootstepSound;
                break;
            case "Grass":
                footstepSound = grassFootstepSound;
                break;
        }

        audioSource.clip = footstepSound;
        audioSource.Play();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f, groundLayer))
        {
            string surfaceTag = hit.collider.gameObject.tag;
            if (surfaceTag != null)
            {
                PlayFootstepSound(surfaceTag);
            }
        }
    }
}
