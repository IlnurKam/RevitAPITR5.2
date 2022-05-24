using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevitAPITrainingLibrary;

namespace RevitAPITR5._2
{
    public class MainViewViewModel
    {
        private ExternalCommandData _commandData;

        public DelegateCommand SaveCommand { get; }
        public List<Element> PickedObject { get; } = new List<Element>();
        public List<WallsSystemType> WallsSystems { get; } = new List<WallsSystemType>();
       
        public WallsSystemType SelectedWallSystem { get; set; }

        public MainViewViewModel(ExternalCommandData commandData)
        {
            _commandData = commandData;
            SaveCommand = new DelegateCommand(OnSaveCommand);
            PickedObject = SelectionUtil.PickObject(commandData);
            WallsSystems = WallsUtils.GetWallsSystems(commandData);
        }

        private void OnSaveCommand()
        {
            UIApplication uiapp = _commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            if (PickedObjects.Count == 0 || SelectedWallSystem == null)
                return;

            using (var ts=new Transaction(doc, "Set system type"))
            {
                ts.Start();

                foreach (var pickedObject is Wall)
                {
                    if (pickedObject is Wall)
                    {
                        var oWall = pickedObject as Wall;
                        oWall.SetSystemType(SelectedWallSystem.Id);
                    }
                }

                ts.Commit();
            }
        }

        public event EventHandler CloseRequest;
        private void RaiseCloseRequest()
        {
            CloseRequest?.Invoke(this, EventArgs.Empty);
        }
    }
}
