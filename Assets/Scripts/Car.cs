using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = .2f;
    [SerializeField] private float turnSpeed = 200f;
    
    private int _steerValue;
    
    private void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;
        transform.Rotate(0, _steerValue * turnSpeed * Time.deltaTime, 0);
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    public void Steer(int value)
    {
        _steerValue = value;
    }
}
