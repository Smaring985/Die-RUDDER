using UnityEngine;

public class DeatZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                Debug.Log("Мертв");

         }
    }
}
