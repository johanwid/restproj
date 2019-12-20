using System;

namespace controller
{
    public class Controller
    {
        private Model _model;

        private View _view;

        public Controller() 
        {
            _model = new Model(new IModel2ViewAdapter() {

            }

            _view = new View(new IView2ModelAdapter() {

            }
        }

        public void Start()
        {

        }
        
        public static void Main()
        {
            
        }
    }
}
