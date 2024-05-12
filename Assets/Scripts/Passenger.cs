using DG.Tweening;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public Type type;

    public GameObject vfxCorrect;

    public GameObject vfxIncorrect;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (!GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].canPlay)
            return;

        Bus bus = GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].GetCurrentBus();

        transform.DOMove(bus.transform.position, 1f).OnComplete(() => {
            bus.AddPassenger(this);
        });

    }

    public void IncorrectTypePassenger()
    {
        PlayVfx(vfxIncorrect);

        transform.position = startPos;
    }

    public void CorrectType()
    {
        PlayVfx(vfxCorrect);
        transform.DOScale(0, 1f);
        GetComponent<BoxCollider2D>().enabled = false;

    }

    private void PlayVfx(GameObject vfxToPlay)
    {
        GameObject vfx = Instantiate(vfxToPlay, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);
    }
}
