//===================================================
//
//创建时间：2021-05-02 23:33:25
//备    注：
//===================================================
using System;
using System.Collections.Generic;

/// <summary>
/// 派发员
/// </summary>
/// <typeparam name="T">类</typeparam>
/// <typeparam name="P">委托参数</typeparam>
/// <typeparam name="X">监听消息Key</typeparam>
public class DispatcherBase<T, P, X> : IDisposable
    where T : new()
    where P : class
{
    #region 单例
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    public virtual void Dispose()
    {

    }
    #endregion

    //按钮点击事件委托原型
    public delegate void OnActionHandler(P p);
    public Dictionary<X, List<OnActionHandler>> dic = new Dictionary<X, List<OnActionHandler>>();

    #region AddEventListener 添加监听
    /// <summary>
    /// 添加监听
    /// </summary>
    /// <param name="key"></param>
    /// <param name="handler"></param>
    public void AddEventListener(X key, OnActionHandler handler)
    {
        if (dic.ContainsKey(key))
        {
            dic[key].Add(handler);
        }
        else
        {
            List<OnActionHandler> lstHandler = new List<OnActionHandler>();
            lstHandler.Add(handler);
            dic[key] = lstHandler;
        }
    }
    #endregion

    #region RemoveEventListener 移除监听
    /// <summary>
    /// 移除监听
    /// </summary>
    /// <param name="key"></param>
    /// <param name="handler"></param>
    public void RemoveEventListener(X key, OnActionHandler handler)
    {
        if (dic.ContainsKey(key))
        {
            List<OnActionHandler> lstHandler = dic[key];
            lstHandler.Remove(handler);
            if (lstHandler.Count == 0)
            {
                dic.Remove(key);
            }
        }
    }
    #endregion

    #region Dispatch 派发
    /// <summary>
    /// 派发
    /// </summary>
    /// <param name="key"></param>
    /// <param name="p"></param>
    public void Dispatch(X key, P p)
    {
        if (dic.ContainsKey(key))
        {
            List<OnActionHandler> lstHandler = dic[key];
            if (lstHandler != null && lstHandler.Count > 0)
            {
                for (int i = 0; i < lstHandler.Count; i++)
                {
                    if (lstHandler[i] != null)
                    {
                        lstHandler[i](p);
                    }
                }
            }
        }
    }

    public void Dispatch(X key)
    {
        Dispatch(key, null);
    }
    #endregion
}