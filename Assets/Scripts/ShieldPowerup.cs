using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float lifetime = 3f;
    public float shieldDuration = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Powerup shield = col.GetComponent<Powerup>();
            if (shield != null)
            {
                shield.ActivateShield(shieldDuration);
            }

            Destroy(gameObject);
        }
    }
}
