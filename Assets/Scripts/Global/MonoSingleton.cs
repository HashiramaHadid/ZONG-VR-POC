using UnityEngine;

namespace Global
{
	public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
	{
		public static T Instance => m_Instance;
	
		private static T m_Instance = null;
	
		private void Awake()
		{
			if (m_Instance == null)
			{
				m_Instance = this as T;
				DontDestroyOnLoad(gameObject);
				Init();
			}
			else if (m_Instance != this)
			{
				Destroy(this);
			}
		}
	
		public virtual void Init()
		{
		
		}

		/// Make sure the instance isn't referenced anymore when the user quit, just in case.
		private void OnApplicationQuit()
		{
			m_Instance = null;
		}
	}
}