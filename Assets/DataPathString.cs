using TMPro;
using UnityEngine;

public class DataPathString : MonoBehaviour
{
    public TextMeshProUGUI persistentDataPathText;
    [Tooltip("Tags: {DATAPATH} = Persistent Data Path")][TextArea(2,5)] public string stringToShow = "Your save data will be stored in {DATAPATH}.";

    private void Start()
    {
        string editedStringToShow = stringToShow.Replace("{DATAPATH}", Application.persistentDataPath);
        persistentDataPathText.text = editedStringToShow;
    }
}
