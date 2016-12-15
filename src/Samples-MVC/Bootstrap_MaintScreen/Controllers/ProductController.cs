using System.Web.Mvc;
using SamplesData;




namespace DemoProduct.Controllers
{
    public class ProductController : Controller
    {

        [HttpGet]
        public ActionResult SearchAndGrid()
        {
            MaintenanceViewModel01 vm = new MaintenanceViewModel01();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult SearchAndGrid(MaintenanceViewModel01 vm)
        {
            vm.HandleRequest();

            // NOTE: Must clear the model state in order to bind
            //       the @Html helpers to the new model values
            ModelState.Clear();

            return View(vm);
        }

        //********************************************************
        //* Detail and Validation
        //********************************************************
        [HttpGet]
        public ActionResult Detail()
        {
            MaintenanceViewModel02 vm = new MaintenanceViewModel02();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Detail(MaintenanceViewModel02 vm)
        {
            if (!ModelState.IsValid && vm.EventCommand == "save")
            {
                vm.IsValid = false;
                vm.SetModeAfterValidation();
            }
            else
            {
                vm.HandleRequest();

                // NOTE: Must clear the model state in order to bind
                //       the @Html helpers to the new model values
                ModelState.Clear();
            }

            return View(vm);
        }

        //********************************************************
        //* Editing
        //********************************************************
        [HttpGet]
        public ActionResult Edit()
        {
            ProductMaintenanceViewModel vm = new ProductMaintenanceViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(ProductMaintenanceViewModel vm)
        {
            if (!ModelState.IsValid && vm.EventCommand == "save")
            {
                vm.IsValid = false;
                vm.SetModeAfterValidation();
            }
            else
            {
                vm.HandleRequest();

                // NOTE: Must clear the model state in order to bind
                //       the @Html helpers to the new model values
                ModelState.Clear();
            }

            return View(vm);
        }

        //********************************************************
        //* Complete Maintenance Page
        //********************************************************
        [HttpGet]
        public ActionResult Maintenance()
        {
            ProductMaintenanceViewModel vm = new ProductMaintenanceViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Maintenance(ProductMaintenanceViewModel vm)
        {
            if (!ModelState.IsValid && vm.EventCommand == "save")
            {
                vm.IsValid = false;
                vm.SetModeAfterValidation();
            }
            else
            {
                vm.HandleRequest();

                // NOTE: Must clear the model state in order to bind
                //       the @Html helpers to the new model values
                ModelState.Clear();
            }

            return View(vm);
        }
    }
}