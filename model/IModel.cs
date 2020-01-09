using System;
using System.Collections.Generic;

namespace model
{
    interface IModel
    {
        void GetPrices();

        void GetSentiment();

        void Calculate();

        void ConstructOutput();

        void GetInputData(Dictionary<String, String> data);

        void Start(Dictionary<String, String> data);

        Dictionary<String, String> GetOutput();
    }
}