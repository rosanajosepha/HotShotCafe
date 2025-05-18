using UnityEngine;

public class SettingsMenuToggle : MonoBehaviour
{
    public GameObject settingsPanel;  // Drag the Settings Panel here

    public void ToggleSettingsMenu()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);  // Toggle visibility
    }
}
