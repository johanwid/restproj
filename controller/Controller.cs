using System;
using System.Collections.Generic;
using model;
using view;
using logger;

namespace controller
{
    public class Controller
    {
        private static IModel _model;
        private static IView _view;
        ILogger _logger = new logger.Logger("logtest.db3");

        public Controller()
        {
            _model = new Model(_logger);
            _view = new View(_logger);
        }

        public void Start()
        {
            _view.Start();
            Dictionary<String, String> input = _view.GetData();
            _model.Start(input);
            Dictionary<String, String> output = _model.GetOutput();
            _view.Finish(output);
        }
    }
}
