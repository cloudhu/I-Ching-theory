using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BehaviourScriptOfStart : MonoBehaviour
{
    /// <summary>
    /// 生两仪
    /// </summary>
    GameObject ArrowTwo, ArrowFour,ArrowEight;

    private Transform transformBtn64,transform8;

    bool bRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        transform8 = transform.Find("ArrowEight/8");
        transformBtn64 = transform.Find("ArrowEight/Button64");
        ArrowTwo = transform.Find("ArrowTwo").gameObject;
        ArrowFour = transform.Find("ArrowFour").gameObject;
        ArrowEight = transform.Find("ArrowEight").gameObject;
        IndexDispatcher.Instance.AddEventListener("ShowArrowTwo", ShowArrowTwo);
        IndexDispatcher.Instance.AddEventListener("OnMoveUpComplete", OnMoveUpComplete);
        transform.Find("ArrowTwo/ButtonNe").GetComponent<Button>().onClick.AddListener(ShowArrowFour);
        transform.Find("ArrowTwo/ButtonPo").GetComponent<Button>().onClick.AddListener(ShowArrowFour);
    }

    private void OnMoveUpComplete(int index)
    {
        if (index == 1)
        {
            ArrowFour.SetActive(true);
        }
        else
        {
            ArrowFour.SetActive(false);
        }
    }

    private void ShowArrowFour()
    {
        ArrowTwo.transform.DOLocalMoveY(200f, 2f);
        IndexDispatcher.Instance.Dispatch("ShowArrowFour", 1);
    }

    private void ShowArrowTwo(int index)
    {
        if (index==1)
        {
            ArrowTwo.SetActive(true);
        }
        else
        {
            ArrowTwo.SetActive(false);
        }
    }

    public void MoveUp()
    {
        ArrowTwo.transform.DOLocalMoveY(580f, 2f);
        ArrowFour.transform.DOLocalMoveY(200f, 2f).OnComplete(()=> {
            ArrowEight.SetActive(true);
            StringDispatcher.Instance.Dispatch("ShowSubtitle", "伏羲：四象生八卦。");
            bRotate = true;
        });
    }

    private void OnDestroy()
    {
        bRotate = false;
        IndexDispatcher.Instance.RemoveEventListener("ShowArrowTwo", ShowArrowTwo);
        transform.Find("ArrowTwo/ButtonNe").GetComponent<Button>().onClick.RemoveListener(ShowArrowFour);
        transform.Find("ArrowTwo/ButtonPo").GetComponent<Button>().onClick.RemoveListener(ShowArrowFour);
        IndexDispatcher.Instance.RemoveEventListener("OnMoveUpComplete", OnMoveUpComplete);
    }

    public void NextLevel()
    {

        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (bRotate)
        {
            transformBtn64.Rotate(-Vector3.forward * 300f * Time.deltaTime);
            transform8.Rotate(-Vector3.forward * 100f * Time.deltaTime);
        }
    }
}
