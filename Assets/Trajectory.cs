using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing;

    Transform[] dotsList;
    Vector2 pos;
    float timeStamp;
    void Start()
    {
        Hide();
        PrepareDots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        for(int i = 0; i<dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParent.transform;
        }
    }
    public void UdpateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        timeStamp = dotSpacing;
        for(int i = 0; i<dotsNumber; i++)
        {
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;
            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }
    public void Show()
    {
        dotsParent.SetActive(true);
    }
    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
