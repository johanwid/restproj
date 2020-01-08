using System;
using System.Collections.Generic;

namespace model
{
    interface IModel
    {
        void ParseInput();

        void GetSentiment();

        void Calculate();

        void ConstructResult();

        void GetData(Dictionary<String, String> data);

        void Start(Dictionary<String, String> data);
    }
}