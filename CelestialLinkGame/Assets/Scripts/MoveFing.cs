using UnityEngine;
using System.Collections;

public class MoveFing : MonoBehaviour {
    public GameObject FingAsset;
    public Transform plpos;
    public GameObject currlink;
    public Vector3 startlink;

	// Use this for initialization
    void OnMouseDrag()
    {
        Vector3 pos =Camera.main.ScreenToWorldPoint( Input.mousePosition);
      //  Debug.Log(pos);
        pos.x = pos.x > 9f ? 9f : pos.x;
        pos.x = pos.x < -9f ? -9f : pos.x;
        pos.y = pos.y > 11f ? 11f : pos.y;
        pos.y = pos.y < -11f ? -11f : pos.y;
        plpos.position = new Vector2( pos.x,pos.y);
        if (currlink!= null)
        {
            LineDraw(currlink, startlink, plpos.position,false);
        }

    }

    public void LineDraw(GameObject Line, Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ)
    {
        Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        Line.transform.position = centerPos;
        Vector3 direction = _finalPosition - _initialPosition;
        direction = Vector3.Normalize(direction);
        Line.transform.right = direction;
        if (_mirrorZ) Line.transform.right *= -1f;
        Vector3 scale = new Vector3(1, 1, 1);
        scale.x = Vector3.Distance(_initialPosition, _finalPosition);
        scale.x = scale.x * 6;
        Line.transform.localScale = scale;
    }

    void OnMouseUp()
    {
        Debug.Log("Up");
        FingAsset.GetComponent<Player>().levprop.NextS();
    }
}
