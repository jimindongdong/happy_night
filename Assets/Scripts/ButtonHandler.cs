using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button myButton; // �� ��ư�� Ŭ���Ǹ� ���� ����˴ϴ�.
    public string sceneName; // �̵��� ���� �̸��Դϴ�.

    public void ChangeSceneOnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}