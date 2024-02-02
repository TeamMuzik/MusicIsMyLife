using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string targetScene;
    private FadeController fadeController;
    private DayBehavior dayBehavior;

    public void ChangeScene()
    {
        // 행동 저장
        dayBehavior = gameObject.GetComponent<DayBehavior>();
        if (dayBehavior != null)
        {
            dayBehavior.SaveTodayBehavior();
        }
        // 페이드인&아웃
        fadeController = FindObjectOfType<FadeController>();
        if (fadeController != null)
        {
            fadeController.RegisterCallback(OnFadeOutComplete); // 페이드아웃 후 진행할 액션 등록
            fadeController.FadeOut(); // FadeOut 호출
        }
        else
        {
            SceneManager.LoadScene(targetScene); //해당 씬으로 이동
        }
    }

    void OnFadeOutComplete()
    {
        Debug.Log("Fade Out이 완료되어 씬을 이동합니다.");
        SceneManager.LoadScene(targetScene); //해당 씬으로 이동
    }
}
