using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    public Canvas gameCanvas;
    public GameObject notificationPrefab;
    public Text score;

    public readonly string[] congratulationMessages = {
        "Nice!",
        "Congratulations!",
        "Great!",
        "Cool!",
        "Super!",
        "Sweet!",
        "Excellent!",
        "Eggcellent!",
        "Dude!",
        "Noice!",
        "Incredible!",
        "Amazing!",
        "OMG!",
        "en.Messages.Congratulate!",
        "Good!",
        "Pretty good!",
        "Not bad!",
        "Life has no intrinsic meaning!",
        "NullReferenceException"
    };

    private GameObject lastNotification = null;

    public string RandomCongratulationMessage() {
        return congratulationMessages[Random.Range(0, congratulationMessages.Length)];
    }

    public void ShowNotification(string text) {
        if (lastNotification != null) {
            Destroy(lastNotification);
        }

        GameObject notificationObject = Instantiate(notificationPrefab);
        lastNotification = notificationObject;
        notificationObject.transform.SetParent(gameCanvas.transform);

        notificationObject.GetComponent<Text>().text = text;
        notificationObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 100);
        notificationObject.GetComponent<NotificationFade>().SetupAnimation();
    }

    public void SetScore(int s) {
        score.text = s.ToString();
    }
}
