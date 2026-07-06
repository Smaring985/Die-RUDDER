using UnityEngine;

public class Manager : MonoBehaviour
{
    public UIPlauer Canvas;


    public void GetCoreDefent(int Count)
    {
        Canvas.CountDefent += Count;
        Canvas.CountDefentTMP.text = Canvas.CountDefent.ToString();

    }

    public void GetCoreSword(int Count)
    {
        Canvas.CountSword += Count;
        Canvas.CountSwordTMP.text = Canvas.CountSword.ToString();
    }
}
