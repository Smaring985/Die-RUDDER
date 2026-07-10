using UnityEngine;
using TMPro; 

public class Speed : MonoBehaviour
{
    public CarController car;
    public TMP_Text SpeedTMP;
   

    // Update is called once per frame
    void Update()
    {
        SpeedTMP.text = car._maxSpeed.ToString("F0");
    }
}
