using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class GenerateMissions : MonoBehaviour {
 
    public GameObject MissionButton;
    public RectTransform ButtonContainer;
 
    void Start ()
    {

        string[] buttonText = {"These", "Buttons", "Are", "Generated", "By", "Script"};
        for(int i = 0; i < buttonText.Length; i++)
        {
            GameObject missionButton = Instantiate(MissionButton);
            missionButton.GetComponent<Button>().GetComponentInChildren<Text>().text=buttonText[i];
            missionButton.transform.SetParent(ButtonContainer, false);
            missionButton.transform.localScale = new Vector3(1, 1, 1);
 
            Button tempButton = missionButton.GetComponent<Button>();
            int tempInt = i;
 
            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
 
     
    }
 
    void ButtonClicked(int buttonNo)
    {
        Debug.Log ("Button clicked = " + buttonNo);
    }
 
}