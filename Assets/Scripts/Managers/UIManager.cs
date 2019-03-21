using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moveCountValue;
    [SerializeField]
    private TextMeshProUGUI finishedMoveCountValue;
    [SerializeField]
    private TextMeshProUGUI minimumMoveCountValue;
    [SerializeField]
    private GameObject pausedPanel;
    [SerializeField]
    private GameObject finishedPanel;

    public void ChangeMoveCountText(string value) {
        moveCountValue.text = value;
    }

    public void PauseGame() {
        pausedPanel.SetActive(true);
        Globals.instance.gameIsPaused = true;
        FindObjectOfType<Globals>().Play("UIClick");
    }

    public void ResumeGame() {
        pausedPanel.SetActive(false);
        FindObjectOfType<Globals>().Play("UIClick");
        Globals.instance.gameIsPaused = false;
    }

    public void BackToMainMenu() {
        FindObjectOfType<Globals>().Play("UIClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GameFinished(string moveCount, string minimumMoveCount) {
        finishedPanel.SetActive(true);
        finishedMoveCountValue.text = moveCount;
        minimumMoveCountValue.text = minimumMoveCount;
        FindObjectOfType<Globals>().Play("Finish");
    }
}
