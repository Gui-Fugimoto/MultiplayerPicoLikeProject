using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerEmotes : MonoBehaviour
{
    public Image stopImage;
    public Image pushImage;
    public Image followImage;
    public Image jumpImage;
    void Start()
    {
        stopImage.enabled = false;
        pushImage.enabled = false;
        followImage.enabled = false;
        jumpImage.enabled = false;
    }
    void ResetEmotes()
    {
        stopImage.enabled = false;
        pushImage.enabled = false;
        followImage.enabled = false;
        jumpImage.enabled = false;
    }

    public IEnumerator StopEmote()
    {
        ResetEmotes();
        yield return new WaitForSeconds(.1f);
        stopImage.enabled = true;
        Debug.Log("foi");
        yield return new WaitForSeconds(5f);
        stopImage.enabled = false;
    }
    public IEnumerator PushEmote()
    {
        ResetEmotes();
        yield return new WaitForSeconds(.1f);
        pushImage.enabled = true;
        yield return new WaitForSeconds(5f);
        pushImage.enabled = false;
    }
    public IEnumerator FollowEmote()
    {
        ResetEmotes();
        yield return new WaitForSeconds(.1f);
        followImage.enabled = true;
        yield return new WaitForSeconds(5f);
        followImage.enabled = false;
    }
    public IEnumerator JumpEmote()
    {
        ResetEmotes();
        yield return new WaitForSeconds(.1f);
        jumpImage.enabled = true;
        yield return new WaitForSeconds(5f);
        jumpImage.enabled = false;
    }

}
