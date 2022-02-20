using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lix.Core
{
  public abstract class Singletonn<T> : MonoBehaviour where T : Component
  {
    public bool DontDestroy = false;

    #region Fields

    /// <summary>
    /// The instance.
    /// </summary>
    private static T instance;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {
      get
      {
        if (instance == null)
        {
          Debug.LogWarning("GET SINGLETON NULL Instance of " + typeof(T));
        }

        return instance;
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    protected virtual void Awake()
    {
      if (instance == null)
      {
        instance = this as T;
        if (DontDestroy)
        {
          DontDestroyOnLoad(gameObject);
        }
      }
      else
      {
        Destroy(gameObject);
      }
    }

    #endregion

  }
}