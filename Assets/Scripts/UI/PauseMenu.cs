using UnityEngine;

namespace Platformer.UI
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!pauseMenu.activeSelf)
                {
                    Time.timeScale = 0f;
                    pauseMenu.SetActive(true);
                    Cursor.visible = true;
                }
                else
                {
                    Resume();
                }
            }
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            Cursor.visible = false;
        }
    }
}
