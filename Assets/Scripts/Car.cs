using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = .2f;
    
    private void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
