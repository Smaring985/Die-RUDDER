using UnityEngine;

public class Defent : Bonus
{

    private void FixedUpdate()
    {

        if (coll != null&& !isActive)
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
            Managerscene.GetCoreDefent(1);
        }
    }
}
