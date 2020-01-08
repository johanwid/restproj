using System;

namespace model
{
    public class Company
    {
        string _name;
        string _symbol;
        string _category;

        public Company(string name, string symbol, string category)
        {
            this._name = name;
            this._symbol = symbol;
            this._category = category;
        }
    }
}