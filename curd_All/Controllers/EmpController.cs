
using curd_All.Datacon;
using curd_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace curd_All.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            NeetuEntities obj = new NeetuEntities();
            var res = obj.emps.ToList();
            List<EmpModel> list = new List<EmpModel>();
            foreach (var item in res)
            {
                list.Add(new EmpModel
                {
                    id = item.id,
                    ename = item.ename,
                    Email = item.Email,
                    edept = item.edept,
                });
            }
            return View(list);
        }
        public ActionResult Delete(int id)
        {
            NeetuEntities neetuEntities=new NeetuEntities();
            var rr=neetuEntities.emps.Where(x => x.id == id).First();
            neetuEntities.emps.Remove(rr);
            neetuEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmp(EmpModel obj)
        {
            NeetuEntities objcon=new NeetuEntities();
            emp empModel=new emp();
            empModel.id = obj.id;
            empModel.ename = obj.ename;
            empModel.Email = obj.Email;
            empModel.edept = obj.edept;
            if (obj.id == 0)
            {
                objcon.emps.Add(empModel);
                objcon.SaveChanges();
            }
            else
            {
                objcon.Entry(empModel).State=System.Data.Entity.EntityState.Modified;
                objcon.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            NeetuEntities obj = new NeetuEntities();
            var res=obj.emps.Where(x => x.id == id).First();    
            EmpModel empMode=new EmpModel();
            empMode.id = res.id;
            empMode.ename = res.ename;
            empMode.Email = res.Email;
            empMode.edept=res.edept;

            return View( "AddEmp",empMode);
        }
       
            
        
    }
}