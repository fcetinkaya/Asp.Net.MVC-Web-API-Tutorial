using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.DAL
{
    public class LanguageDAL : BaseDAL
    {
        //  LangEntities db = new LangEntities();
        public IEnumerable<Language> GetLanguages()
        {
            return db.Languages;
        }

        public Language GetLanguageId(int id)
        {
            return db.Languages.Find(id);
        }
        public Language CreateLanguage(Language language)
        {
            db.Languages.Add(language);
            db.SaveChanges();
            return language;
        }

        public Language UpdateLanguge(int id, Language language)
        {
            db.Entry(language).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return language;
        }

        public void DeleteLanguage(int id)
        {
            db.Languages.Remove(db.Languages.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyLanguage(int id)
        {
            return db.Languages.Any(x => x.ID == id);
        }
    }
}
