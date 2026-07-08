using UnityEngine;

public class Sword : Bonus
{
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
            Managerscene.GetCoreSword(1);
        }
    }
}
