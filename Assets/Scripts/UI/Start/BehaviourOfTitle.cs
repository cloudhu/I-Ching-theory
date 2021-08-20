using Coffee.UIEffects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourOfTitle : MonoBehaviour
{
    /// <summary>
    /// 开始按钮
    /// </summary>
    Transform transformBtnStart;

    /// <summary>
    /// 旋转速度
    /// </summary>
    private const float rotateSpeeed = 300f;

    /// <summary>
    /// 是否旋转
    /// </summary>
    bool bRotate = false;

    /// <summary>
    /// 0度旋转
    /// </summary>
    Quaternion quaternion0;

    // Start is called before the first frame update
    void Start()
    {
        transformBtnStart = transform.Find("ButtonStart");
        transformBtnStart.GetComponent<Button>().onClick.AddListener(OnStartClick);
        quaternion0 = transformBtnStart.rotation;
        bRotate = true;
        IndexDispatcher.Instance.AddEventListener("ShowArrowFour", ShowArrowFour);
    }

    private void ShowArrowFour(int index)
    {
        if (index==1)
        {
            transformBtnStart.DOLocalMoveY(380f, 2f).OnComplete(() => {
                IndexDispatcher.Instance.Dispatch("OnMoveUpComplete", 1);
                StringDispatcher.Instance.Dispatch("ShowSubtitle", "伏羲：两仪生四象。");
            });
        }
    }

    private void OnStartClick()
    {
        if (bRotate)
        {
            bRotate = false;
            transformBtnStart.DOLocalRotateQuaternion(quaternion0, 1f).OnComplete(ShowTwo);
            transform.Find("TextTitle").GetComponent<UIDissolve>().Play();
        }
    }

    private void ShowTwo()
    {
        transformBtnStart.DOLocalMoveY(260f, 2f).OnComplete(()=> {
            IndexDispatcher.Instance.Dispatch("ShowArrowTwo", 1);
            StringDispatcher.Instance.Dispatch("ShowSubtitle", "伏羲：太极生两仪。");
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (bRotate)
        {
            transformBtnStart.Rotate(-Vector3.forward * rotateSpeeed * Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        IndexDispatcher.Instance.RemoveEventListener("ShowArrowTwo", ShowArrowFour);
        transformBtnStart.GetComponent<Button>().onClick.RemoveListener(OnStartClick);
    }
}
