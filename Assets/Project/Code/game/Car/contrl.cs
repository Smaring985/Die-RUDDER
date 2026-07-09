using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody RB;

    public Whell[] WhellObj;

    public int Steet;
    public float vertivcal;
    public float Horizontal;

    [SerializeField] private int _force;
    [SerializeField] private int BreakeForce;
    [SerializeField] public float _maxSpeed;
    [SerializeField] private float InputBreake;
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Breake();
        CheckBreak();
        sdift();
    }

    public void CheckBreak()
    {
        vertivcal = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        float movingdirectional = Vector3.Dot(transform.forward, RB.linearVelocity);

        InputBreake = (movingdirectional < -0.5f && vertivcal > 0) || (movingdirectional > 0.5f && vertivcal < 0) ? Mathf.Abs(vertivcal) : 0;
    }

    public void Breake()
    {
        foreach (Whell Whell in WhellObj)
        {
            if (Whell.IsWorfart)
            {
                Whell.WheelCollider.brakeTorque = InputBreake * BreakeForce * 0.7f;
            }
            else
            {
                Whell.WheelCollider.brakeTorque = InputBreake * BreakeForce * 0.3f;
            }
        }

    }
    public void Move()
    {
        _maxSpeed = Vector3.Dot(transform.forward, RB.linearVelocity);
      
        foreach (Whell Whell in WhellObj)
        {
            Whell.WheelCollider.motorTorque = _force * vertivcal;

         
            Whell.Update();
        }


        Rotation();
    }


    public void sdift()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (Whell Whell in WhellObj)
            {
                if (!Whell.IsWorfart )
                {
                    Debug.Log(Whell);
                    Whell.WheelCollider.brakeTorque = BreakeForce;
                }
            }
        }
    }

    public void Rotation()
    {
        float Steer = Horizontal * Steet;

        foreach (Whell Whell in WhellObj)
        {
            if (Whell.IsWorfart)
            {
                Whell.WheelCollider.steerAngle = Steer;
            }
        }
    }
   
}
[System.Serializable]
public struct Whell
{
    public Transform _transformWhell;
    public WheelCollider WheelCollider;
    public bool IsWorfart;

    public void Update()
    {
        Vector3 position;
        Quaternion rotation;

        WheelCollider.GetWorldPose(out position, out rotation);


        _transformWhell.position = position;
        _transformWhell.rotation = rotation;
    }

}