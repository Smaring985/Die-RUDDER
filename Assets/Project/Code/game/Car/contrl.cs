using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody RB;
    public Whell[] WhellObj;
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
                Whell.WheelCollider.brakeTorque = InputBreake * BreakeForce * 0.3f;
            }
            else
            {
                Whell.WheelCollider.brakeTorque = InputBreake * BreakeForce * 15f;
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
        float handbrake = Input.GetKey(KeyCode.Space) ? 1f : 0f;

        foreach (Whell wheel in WhellObj)
        {
            if (!wheel.IsWorfart) // только задние
            {
                wheel.WheelCollider.brakeTorque = handbrake * BreakeForce * 1000f; // можно даже сильнее
            }
        }
    }
    public void Rotation()
    {
        float Steer = Horizontal * 25;
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