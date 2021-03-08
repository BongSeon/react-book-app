﻿using BookApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Apis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")] // 없어도됨
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly ILogger _logger;

        public BooksController(IBookRepository repository, ILoggerFactory loggerFactory)
        { 
            this._repository = repository ?? 
                throw new ArgumentNullException(nameof(BooksController));
            // 리파지토리 주입된게 없다면 예외처리
            this._logger = loggerFactory.CreateLogger(nameof(BooksController));
        }

        #region 출력
        // 출력
        // GET api/Books
        [HttpGet] // [HttpGet("action")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _repository.GetAllAsync();
                if(!models.Any()) // 집합 안에 요소가 하나도 없다면
                {
                    return new NoContentResult(); // 참고용 코드
                }
                return Ok(models); // 200 OK
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
        #endregion

        #region 상세
        // 상세
        // GET api/Books/123
        [HttpGet("{id:int}", Name = "GetBookById")] // Name 속서으로 RouteName 설정
        public async Task<IActionResult> GetById([FromRoute] int id) // 라우트에서 /id값 가져옴
        {
            try
            {
                var model = await _repository.GetByIdAsync(id);
                if (model == null) // 요소가 null 이라면
                {
                    //return new NoContentResult(); // 204 No Content
                    return NotFound();
                }
                return Ok(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
        #endregion

        #region 입력
        // 입력
        // POST api/Books
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Book dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // <>
            var temp = new Book();
            temp.Title = dto.Title;
            temp.Description = dto.Description;
            temp.Created = DateTime.Now;
            // </>

            try
            {
                var model = await _repository.AddAsync(temp);
                if (model == null)
                {
                    return BadRequest();
                }

                //[!] 다음 항목 중 원하는 방식 사용
                if (DateTime.Now.Second % 60 == 0)
                {
                    return Ok(model); // 200 OK
                }
                else if (DateTime.Now.Second % 3 == 0)
                {
                    return CreatedAtRoute("GetBookById", new { id = model.Id }, model);
                }
                else if (DateTime.Now.Second % 2 == 0)
                {
                    var uri = Url.Link("GetBookById", new { id = model.Id });
                    return Created(uri, model); // 201 Created
                }
                else
                {
                    // GetById 액션 이름 사용해서 입력된 데이터 반환
                    return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
        #endregion

        #region 수정
        // 수정
        // PUT api/Books/123
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Book dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                dto.Id = id;
                var status = await _repository.UpdateAsync(dto);
                if (!status)
                {
                    return BadRequest();
                }

                // 204 No Content
                return NoContent(); // 이미 전송된 정보에 모든 값 가지고 있기에...
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
        #endregion
    }
}