using AutoMapper;
using Demo.BLL.interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
       
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public DepartmentController( IUnitOfWork  unitOfWork , IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<Department> department;
            IEnumerable<DepartmentsViewModel> Mappeddepartment;

             department = _UnitOfWork.DepartmentRepository.GetAll();
            var IVM = _mapper.Map<IEnumerable<DepartmentsViewModel>>(department); 
            return View(IVM);
        }
        public IActionResult Create()
        {

            return View(new DepartmentsViewModel());
        }
        [HttpPost]
        public IActionResult Create(DepartmentsViewModel department)
        {
            if (ModelState.IsValid)
            {
                var CVM = _mapper.Map<Department>(department);
                var CE =  _UnitOfWork.DepartmentRepository.add(CVM);
              
                return RedirectToAction("Index");
            }
            return View(department);
        }
        public IActionResult Details(int? id)
        {
            if (id is null)

            { return NotFound(); }

            else
            {
                
                var Depart = _UnitOfWork.DepartmentRepository.GetById(id);
               
               
              
               var DVM = _mapper.Map<DepartmentsViewModel>(Depart);
                
                if (Depart is null)

                { return NotFound(); }

                return View(DVM);
            }


        }
        public IActionResult Update(int? id)
        {
            if (id is null)

            { return NotFound(); }

            else
            {
                var Depart = _UnitOfWork.DepartmentRepository.GetById(id);
                var UVM = _mapper.Map<DepartmentsViewModel>(Depart);  

                if (Depart is null)

                { return NotFound(); }

                return View(UVM);
            }
        }
        [HttpPost]
        public IActionResult Update(int id, DepartmentsViewModel dept)
        {
            if (id != dept.Id)
                return NotFound();
            try
            {
                if (ModelState.IsValid)
                {   
                    
                    var UVM = _mapper.Map<Department>(dept);
                    var Depart =   _UnitOfWork.DepartmentRepository.update(UVM);
                   

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ez)
            {

                throw new Exception(ez.Message);
            }
            return View("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
            { return NotFound(); }
            else
            {
                var Depart = _UnitOfWork.DepartmentRepository.GetById(id);
                var DVM = _mapper.Map<Department>(Depart);

                if (Depart is null)
                { return NotFound(); }

                _UnitOfWork.DepartmentRepository.delete(DVM);

                return RedirectToAction("Index");
            }
        }
    }
}
