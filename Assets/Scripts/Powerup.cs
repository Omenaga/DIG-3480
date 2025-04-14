using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject shieldVisual;
    //private bool shieldActive = false;
    public AudioClip shieldPowerUpClip;
    public AudioClip shieldPowerDownClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip shieldPowerUpClip;
    public AudioClip shieldPowerDownClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ActivateShield(float duration)
    {
        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }

        // Play shield power-up sound
        if (audioSource != null && shieldPowerUpClip != null)
        {
            audioSource.PlayOneShot(shieldPowerUpClip);
        }

        //shieldActive = true;
        Invoke("DeactivateShield", duration);
    }

    private void DeactivateShield()
    {
        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        //shieldActive = false;

        // Play shield power-down sound
        if (audioSource != null && shieldPowerDownClip != null)
        {
            audioSource.PlayOneShot(shieldPowerDownClip);
        }
    }
}
