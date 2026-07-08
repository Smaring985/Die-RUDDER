using System.Collections;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject ActiveBonus;
    public GameObject DisActiveBonus;
    public Collider coll;
    public float TimeActive = 5f;
      public bool isActive;
    public Manager Managerscene;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
            {
                coll = collision;

            }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             coll = null; 

        }
    }

    public virtual void Active()
    {
        StartCoroutine(StateActive());
    }

    IEnumerator StateActive()
    {
        ActiveBonus.SetActive(true);
        DisActiveBonus.SetActive(false);
        isActive = true;
         yield return (isActive) ;

        yield return new WaitForSeconds(TimeActive);
        isActive = false;

        ActiveBonus.SetActive(false);
        DisActiveBonus.SetActive(true);


        yield break ;
    }
}
