 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;

 using UnityEngine.SceneManagement;


public class IntroScreen : MonoBehaviour
{
 	public Button yourButton;
    void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

    public void TaskOnClick()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
