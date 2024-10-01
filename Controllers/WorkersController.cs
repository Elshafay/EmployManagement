using AutoMapper;
using Demo.BLL.interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Entities;
using Demo.PL.Helper;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Demo.PL.Controllers
{
    public class WorkersController : Controller
    {
        private readonly IUnitOfWork _UntitOfWorker;
        private readonly IMapper _mapper;
        private readonly IMapper _mapper2;

        public WorkersController(IUnitOfWork unitOfWork , IMapper mapper) 
        {
            _UntitOfWorker = unitOfWork;
            _mapper = mapper; 
        }
        public IActionResult Index(string SearchValue = "" )

        {
            IEnumerable<Workers> workers;
            IEnumerable<WorkersViewModel> MappedWorker;

            if (string.IsNullOrEmpty(SearchValue))
            {
                workers = _UntitOfWorker.WorkersRepository.GetAll();
                MappedWorker = _mapper.Map<IEnumerable<WorkersViewModel>>(workers);  

            }
            else
            {
                workers = _UntitOfWorker.WorkersRepository.Search(SearchValue);
                MappedWorker = _mapper.Map<IEnumerable<WorkersViewModel>>(workers);
            }
            return View(MappedWorker);
        }
        public IActionResult Create()
        {
            ViewBag.Departments = _UntitOfWorker.DepartmentRepository.GetAll();
            return View(new WorkersViewModel());
        }

        [HttpPost]
        public IActionResult Create(WorkersViewModel workersVM)
        {
            //ModelState["Department"].ValidationState = ModelValidationState.Valid;

                ViewBag.Departments = _UntitOfWorker.DepartmentRepository.GetAll();

            if (ModelState.IsValid)
            {
                var Workers = _mapper.Map<Workers>(workersVM);

                     Workers.ImagesUrl = DocumentSettings.UploudFiles(workersVM.Images, "Images");

                     _UntitOfWorker.WorkersRepository.add(Workers);

                    return RedirectToAction("Index");

            }
            return View(workersVM);




        }
        

        public IActionResult Details(int? id)
        {

            if (id is null)

            { return NotFound(); }

            else
            {
                
                var Wor = _UntitOfWorker.WorkersRepository.GetById(id);              
                 var Workers = _mapper.Map<WorkersViewModel>(Wor);
              

                if (Wor is null)

                { return NotFound(); }

                return View(Workers);
            }
        }
        public IActionResult Update(int? id)
        {
            if (id is null)
            { return NotFound(); }
            else
            {
                var Worr = _UntitOfWorker.WorkersRepository.GetById(id);
                var Workers = _mapper.Map<WorkersViewModel>(Worr);
                if (Worr is null)
                { return NotFound(); }
                return View(Workers);
            }
        }
        [HttpPost]
        public IActionResult Update(int id, WorkersViewModel WVM)
        {         

            if (id != WVM.Id)

                return NotFound();
            try
            {
                if (ModelState.IsValid)
                {

                    var Worker = _mapper.Map<Workers>(WVM);

                    Worker.ImagesUrl = DocumentSettings.UploudFiles(WVM.Images, "Images");

                    _UntitOfWorker.WorkersRepository.update(Worker);

                    return RedirectToAction("Index");
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                                           .Where(y => y.Count > 0)
                                           .ToList();

                }
            }

            catch (Exception ez)
            {

                throw new Exception(ez.Message);
            }
            return View(WVM);

        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
            { return NotFound(); }
            else
            {
                var Wor = _UntitOfWorker.WorkersRepository.GetById(id);
                var DVM = _mapper.Map<Workers>(Wor);

                if (DVM is null)

                { return NotFound(); }

                _UntitOfWorker.WorkersRepository.delete(DVM);

                return RedirectToAction("Index");
            }
        }
    }
}
