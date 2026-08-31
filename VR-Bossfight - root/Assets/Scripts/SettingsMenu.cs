using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    public InputActionReference openSettingsAction;

    private bool isSettingsOpen = false;



    private void OnEnable()
    {
        openSettingsAction.action.Enable();
        openSettingsAction.action.performed += ToggleSettings;
    }

    private void OnDisable()
    {
        openSettingsAction.action.performed -= ToggleSettings;
        openSettingsAction.action.Disable();
    }


    private void Start()
    {
        settingsPanel.SetActive(false);
    }


    private void ToggleSettings(InputAction.CallbackContext context)
    {
        isSettingsOpen = !isSettingsOpen;
        settingsPanel.SetActive(isSettingsOpen);

        Time.timeScale = isSettingsOpen ? 0f : 1f;
    }



    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }


}
