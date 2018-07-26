using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour {

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeScene);
    }


    public void ChangeScene()
    {
        SceneManager.LoadScene("mission_menu", LoadSceneMode.Single);
    }

}
