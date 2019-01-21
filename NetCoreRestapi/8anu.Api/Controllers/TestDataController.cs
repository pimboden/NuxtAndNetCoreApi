using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]/{id?}")]
    public class TestModelsController : Controller
    {
        private ITestModelsManager _testModelsManager;
        public TestModelsController(ITestModelsManager testModelsManager)
        {
            _testModelsManager = testModelsManager;
        }
        
        [HttpGet]
        public List<TestModel> GetAll()
        {
            
            return _testModelsManager.GetAll();
        }

        [HttpGet(Name = "GetTest")]
        public TestModel Get(int id)
        {
            return _testModelsManager.Get(new object[] { id });
        }

        [HttpPost]
        public IActionResult Create([FromBody]TestModel item)
        {
            _testModelsManager.SaveNew(item);
            return CreatedAtRoute("GetTest", new { id = item.Id }, item);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody]TestModel item)
        {
            var test = _testModelsManager.Get(new object[] { id });
            if (test == null) 
            {
                return NotFound();    
            }

            test.Message = item.Message;
            _testModelsManager.Update(test);
            return NoContent();
        }
        
        
    }
}