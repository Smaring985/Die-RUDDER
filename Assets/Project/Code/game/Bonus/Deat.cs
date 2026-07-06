using UnityEngine;

public class Deat : Bonus
{
    public GameObject Spike;
    private void FixedUpdate()
    {

        if (coll != null && !isActive)
        {
            Active();
            Debug.Log("одины");
        }

    }

    public override void Active()
    {
        base.Active();

        if (isActive)
        {
            Spike.GetComponent<Animator>().SetBool("Active",true);
        }
        else
        {
            Spike.GetComponent<Animator>().SetBool("Active", false);

        }
    }

  
  
}
