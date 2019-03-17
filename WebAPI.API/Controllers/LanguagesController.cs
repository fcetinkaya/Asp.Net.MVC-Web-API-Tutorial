using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using WebAPI.API.Attributes;
using WebAPI.API.Security;
using WebAPI.DAL;

namespace WebAPI.API.Controllers
{
    //  [APIAuthorize(Roles = "A")] // All Method authorize.
    //   [ApiExceptionAttribute]  // Only control method...
    public class LanguagesController : ApiController
    {
        LanguageDAL languageDAL = new LanguageDAL();
        //HttpResponseMessage
        [ResponseType(typeof(IEnumerable<Language>))]
        //  [HttpGet] // Optional, methot name ain't Get world, use httpget..
        //  [ApiExceptionAttribute]  // Only method...
        [APIAuthorize(Roles = "A")] // Doesn't writte Attribute
                                    // Only Role "A" (DB Users Table)
        public IHttpActionResult Get()
        {
            var languages = languageDAL.GetLanguages();
            return Ok(languages);
            // return Request.CreateResponse(HttpStatusCode.OK, languages);
        }
        //HttpResponseMessage
        [ResponseType(typeof(Language))]
        public IHttpActionResult Get(int id)
        {
            var language = languageDAL.GetLanguageId(id);
            if (language == null)
            {
                return NotFound();
                //  return Request.CreateResponse(HttpStatusCode.NotFound, "Sistemde kayıt bulunamadı.");
            }
            else
            {
                return Ok(language);
                //  return Request.CreateResponse(HttpStatusCode.OK, language);
            }
        }

        //HttpResponseMessage
        [ResponseType(typeof(Language))]
        public IHttpActionResult Post(Language language)
        {
            if (ModelState.IsValid)
            {
                var createLang = languageDAL.CreateLanguage(language);
                // DefaultApi and ID=> web.config route settings..
                return CreatedAtRoute("DefaultApi", new { id = createLang.ID }, createLang);
                //  return Request.CreateResponse(HttpStatusCode.Created, createLang);
            }
            else
            {
                //   return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return BadRequest(ModelState);
            }
        }


        //HttpResponseMessage
        [ResponseType(typeof(Language))]
        public IHttpActionResult Put(int id, Language language)
        {
            if (languageDAL.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
                //  return Request.CreateResponse(HttpStatusCode.NotFound, "Sistemde kayıt bulunamadı.");
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
                // return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                // var updateLang = languageDAL.UpdateLanguge(id, language);
                // return CreatedAtRoute("DefaultApi", new { id = updateLang.ID }, updateLang);
                return Ok(languageDAL.UpdateLanguge(id, language));
            }
        }

        //HttpResponseMessage
        public IHttpActionResult Delete(int id)
        {
            if (languageDAL.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
                //  return Request.CreateResponse(HttpStatusCode.NotFound, "Sistemde kayıt bulunamadı.");
            }
            else
            {
                languageDAL.DeleteLanguage(id);
                return Ok();
                //   return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }


        // WepAPI.DAL => web.config connection code copy
        // This project web.config paste
        // This project add referance from WebAPI.DAL to in EntityFramework and EntityFramework.SqlServer dll
    }
}