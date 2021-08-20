using System;
using System.Collections.Generic;

public class IndexDispatcher : IDisposable
{
	#region ����
	private static IndexDispatcher instance;

	public static IndexDispatcher Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new IndexDispatcher();
			}
			return instance;
		}
	}

	public virtual void Dispose()
	{

	}
	#endregion

	//��ť����¼�ί��ԭ��

	public delegate void OnActionHandler(int index);
	public Dictionary<string, List<OnActionHandler>> dic = new Dictionary<string, List<OnActionHandler>>();

	#region AddEventListener ��Ӽ���
	/// <summary>
	/// ��Ӽ���
	/// </summary>
	/// <param name="key"></param>
	/// <param name="handler"></param>
	public void AddEventListener(string key, OnActionHandler handler)
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

	#region RemoveEventListener �Ƴ�����
	/// <summary>
	/// �Ƴ�����
	/// </summary>
	/// <param name="key"></param>
	/// <param name="handler"></param>
	public void RemoveEventListener(string key, OnActionHandler handler)
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

	#region Dispatch �ɷ�
	/// <summary>
	/// �ɷ�
	/// </summary>
	/// <param name="key"></param>
	/// <param name="param"></param>
	public void Dispatch(string key, int param)
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
						lstHandler[i](param);
					}
				}
			}
		}
	}
	#endregion
}
