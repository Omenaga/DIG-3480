using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject shieldVisual;
    //private bool shieldActive = false;

    public void ActivateShield(float duration)
    {
        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }

        //shieldActive = true;
        Invoke("DeactivateShield", duration);
    }

    private void DeactivateShield()
    {
        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        //shieldActive = false;
    }
}
