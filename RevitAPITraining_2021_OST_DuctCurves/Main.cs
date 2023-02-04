using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_2021_OST_DuctCurves
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //ElementCategoryFilter ductCurvesCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_DuctCurvesDrop);
            //ElementClassFilter ductCurvesInstancesFilter = new ElementClassFilter(typeof(FamilyInstance));  // выберет только те, которые являются экземплярами симейств(без типов)
            //LogicalAndFilter ductCurvesFilter = new LogicalAndFilter(ductCurvesCategoryFilter, ductCurvesInstancesFilter);

            //var ductCurves = new FilteredElementCollector(doc)
            //    .WherePasses(ductCurvesFilter)
            //    .Cast<FamilyInstance>()
            //    .ToList();


            List<Duct> ductCurves = new FilteredElementCollector(doc)
                .OfClass(typeof(Duct))
                .WhereElementIsNotElementType()
                .Cast<Duct>()
                .ToList();


            TaskDialog.Show("Количество воздуховодов:", ductCurves.Count.ToString());
            return Result.Succeeded;
        }
    }
}
