using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Esta función se llamará cuando se presione el botón "Start".
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
