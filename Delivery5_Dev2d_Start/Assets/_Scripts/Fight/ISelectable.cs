using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    public interface ISelectable
    {
        void HighlightGood();
        void HighlightBad();

        void UnSelect();

        void ClickedGood();
        void ClickedBad();

    }
}
