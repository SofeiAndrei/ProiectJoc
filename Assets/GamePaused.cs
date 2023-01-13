using UnityEngine;

public class GamePaused : MonoBehaviour
{
    public GameObject ui;
    void Update () {
        if (Input.GetKeyDown(KeyCode.P)) {
            Toggle();
        }
    }

    public void Toggle () {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf) {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
    }
}
