using EFdemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFdemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructorController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Instructor> Get()
        {
            //仅做demo使用，实际情况是不可能都用get的，正常您应该Get下面有几个，Post下面有几个等等
            //由于浏览器预览只能做get请求，所以这里只采用get请求作为测试，测试其他http请求可采用postman进行截断

            using (var context = new ModelContext())
            {

                //get all instructors，其他稀奇古怪的查询就是EF core的用法了
                //return context.Instructors.ToList();

                //增，请注意数据库约束
                /* Instructor instructor = new Instructor();
                 instructor.Id = "10203";
                 instructor.Name = "Maria";
                 instructor.Salary = 90000;
                 instructor.DeptName = "Finance";
                 context.Instructors.Add(instructor);
                 context.SaveChanges();

                 return context.Instructors.ToList();*/

                //改
                //Instructor instructor = context.Instructors.Where(inst => inst.Id == "10203").FirstOrDefault();
                //instructor.Name = "Mary";
                //context.SaveChanges();

                //return context.Instructors.ToList();

                //删
                Instructor instructor = context.Instructors.Where(inst => inst.Id == "10203").FirstOrDefault();
                context.Instructors.Remove(instructor);
                //这是controller做的事情
                context.SaveChanges();
                //在数据库中保存变化
                return context.Instructors.ToList();
            }
        }
    }
}
