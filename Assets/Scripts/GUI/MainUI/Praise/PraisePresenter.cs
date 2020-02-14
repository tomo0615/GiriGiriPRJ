using UnityEngine;

public class PraisePresenter : MonoBehaviour
{
    [SerializeField]
    private PraiseView _praiseView = null;

    [SerializeField]
    private PraiseWordTable _praiseWordTable = null;

    private PraiseModel _praiseModel = null;

    private void Awake()
    {
        _praiseModel = new PraiseModel();
    }

    public void OnPraisePlayer()
    {
        string word = _praiseModel.GetPraiseWord(_praiseWordTable.praiseList);
        _praiseView.ViewPraiseWord(word);
    }
}
