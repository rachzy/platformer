using UnityEngine;

namespace Platformer.Mechanics
{
    public class CameraController : MonoBehaviour
    {
        public GameObject target;
        public float y;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            y = target == null ? transform.position.y : target.transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(target.transform.position.x + 10, y, -10);
        }

        public void setY(float newY)
        {
            y = Mathf.Lerp(y, newY, Time.deltaTime * 2f);
        }
    }
}
