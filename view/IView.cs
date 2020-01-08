using System;
using System.Collections.Generic;

namespace view
{
    interface IView
    {
        void Start();

        void GetTicker();

        void GetTimeSeries();

        void GetOption();

        Dictionary<String, String> GetData();

        void Finish(Dictionary<String, String> output);
    }
}
