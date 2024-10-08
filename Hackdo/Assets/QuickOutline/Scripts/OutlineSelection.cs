//MIT License
//Copyright (c) 2023 DA LAB (https://www.youtube.com/@DA-LAB)
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    public Transform vrHeadset; // VR 헤드셋의 Transform을 연결해주세요.
    public string alwaysVisibleTag = "YourTag"; // 항상 아웃라인을 보이게 할 태그

    private Transform highlight;




    public void Highlight(Transform newHighlight)
    {
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        highlight = newHighlight;
        if (highlight.CompareTag(alwaysVisibleTag))
        {
            if (highlight.gameObject.GetComponent<Outline>() != null)
            {
                highlight.gameObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                Outline outline = highlight.gameObject.AddComponent<Outline>();
                outline.enabled = true;
                highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
                highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
            }
        }
        else
        {
            highlight = null;
        }
    }
}
