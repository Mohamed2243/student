using Exam.Data;
using Exam.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
       
    {
        private readonly StudentDbContextcsDb studentDbContextcsDb;
        public StudentController(StudentDbContextcsDb studentDbContextcsDb)
        {
            studentDbContextcsDb = studentDbContextcsDb;
        }

        //Get all data student
        [HttpGet]
        public async Task< IActionResult> GetAllStudents()
        {
         var students = await  studentDbContextcsDb.students.ToListAsync();
            return Ok(students);
        }
        //Get single data
        [HttpGet]
        [Route ("{id:int}")]
        [ActionName("GetStudent")]
        public async Task<IActionResult> GetStudents([FromRoute] Guid id)
        {
            var student = await studentDbContextcsDb.students.FirstOrDefaultAsync(y => y.Id == id);
            if (student != null)
            {
                return Ok(student);

            }
            return NotFound("not found");
        }
        //Get single data
        [HttpPost]
        public async Task<IActionResult> AddData([FromBody] Student student)
        {
            student.Id = Guid.NewGuid();
            await studentDbContextcsDb.students.AddAsync(student);
            await studentDbContextcsDb.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudents),student.Id,student);
        }
        //Updating A card
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateData([FromRoute] Guid id , Student student)
        {
            var exsistingStudent =await studentDbContextcsDb.students.FirstOrDefaultAsync(y => y.Id == id);
            if(exsistingStudent != null)
            {
                exsistingStudent.Id = id;
                exsistingStudent.number = student.number;
                exsistingStudent.Name = student.Name;
                await studentDbContextcsDb.SaveChangesAsync();
                return Ok(exsistingStudent);
            }
            return NotFound("ID Not Found");
        }

        //DeleteData
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteData([FromRoute] Guid id)
        {
            var exisstingStudent = await studentDbContextcsDb.students.FirstOrDefaultAsync(y => y.Id == id);
            if(exisstingStudent != null)
            {
                studentDbContextcsDb.students.Remove(exisstingStudent);
                await studentDbContextcsDb.SaveChangesAsync();
                return Ok(exisstingStudent);
            }
            return NotFound("Id Not Found");
        }




    }




}
