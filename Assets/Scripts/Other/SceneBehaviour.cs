using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBehaviour : MonoBehaviour
{
    [SerializeField] private bool _commentReset;
    private AtsumaruManager _atsumaruManager;

    public AtsumaruManager AtsumaruManager
    {
        get
        {
            return _atsumaruManager;
        }
    }

    protected virtual void Awake()
    {
        _atsumaruManager = GetComponent<AtsumaruManager>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        _atsumaruManager.Comment.ChangeScene(sceneName, _commentReset);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
}
