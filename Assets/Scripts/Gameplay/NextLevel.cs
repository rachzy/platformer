using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    public class FinishLine : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}
