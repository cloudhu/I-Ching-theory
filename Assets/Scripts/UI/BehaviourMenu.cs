using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BehaviourMenu : MonoBehaviour
{
    private Transform transformSymbol, transformCircle;

    // Start is called before the first frame update
    void Start()
    {
        transformSymbol = transform.Find("Logo/Symbol8");
        transformCircle = transform.Find("Logo/ImageCircle");
        transform.Find("Menu/Button8").GetComponent<Button>().onClick.AddListener(OnButton8Click);
        transform.Find("Menu/Button64").GetComponent<Button>().onClick.AddListener(OnButton64Click);
        transform.Find("Menu/ButtonTao").GetComponent<Button>().onClick.AddListener(OnButtonTaoClick);
        transform.Find("Menu/ButtonDivination").GetComponent<Button>().onClick.AddListener(OnButtonDivinationClick);
        transform.Find("Menu/ButtonAbout").GetComponent<Button>().onClick.AddListener(OnButtonAboutClick);
        transform.Find("Menu/ButtonQuit").GetComponent<Button>().onClick.AddListener(OnButtonQuitClick);
    }

    private void OnButtonQuitClick()
    {
        Application.Quit();
    }

    private void OnButtonAboutClick()
    {
        SceneManager.LoadScene(3);
    }

    private void OnButtonDivinationClick()
    {
        StringDispatcher.Instance.Dispatch("ShowSubtitle", "正在研发……");
    }

    private void OnButtonTaoClick()
    {
        StringDispatcher.Instance.Dispatch("ShowSubtitle", "正在研发……");
    }

    private void OnButton64Click()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// 八卦
    /// </summary>
    private void OnButton8Click()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        transformSymbol.Rotate(-Vector3.forward * 200f * Time.deltaTime);
        transformCircle.Rotate(-Vector3.forward * 100f * Time.deltaTime);
    }

    void OnDestroy()
    {
        transform.Find("Menu/Button8").GetComponent<Button>().onClick.RemoveListener(OnButton8Click);
        transform.Find("Menu/Button64").GetComponent<Button>().onClick.RemoveListener(OnButton64Click);
        transform.Find("Menu/ButtonTao").GetComponent<Button>().onClick.RemoveListener(OnButtonTaoClick);
        transform.Find("Menu/ButtonDivination").GetComponent<Button>().onClick.RemoveListener(OnButtonDivinationClick);
        transform.Find("Menu/ButtonAbout").GetComponent<Button>().onClick.RemoveListener(OnButtonAboutClick);
        transform.Find("Menu/ButtonQuit").GetComponent<Button>().onClick.RemoveListener(OnButtonQuitClick);
    }
}
