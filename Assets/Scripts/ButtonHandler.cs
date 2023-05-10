using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button myButton; // 이 버튼이 클릭되면 씬이 변경됩니다.
    public string sceneName; // 이동할 씬의 이름입니다.

    public void ChangeSceneOnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}