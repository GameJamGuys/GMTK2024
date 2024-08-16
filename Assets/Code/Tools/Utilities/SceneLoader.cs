using UnityEngine.SceneManagement;

namespace Tools
{
    // Class for easy scene managment
    public static class SceneLoader
    {
        public static int GetScene() => SceneManager.GetActiveScene().buildIndex;

        public static void Load(int scene) => SceneManager.LoadScene(scene);
        public static void Load(string scene) => SceneManager.LoadScene(scene);

        public static void LoadNext() => SceneManager.LoadScene(GetScene() + 1);
        public static void LoadPrev() => SceneManager.LoadScene(GetScene() - 1);

        public static void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
